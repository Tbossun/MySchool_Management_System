using Microsoft.AspNetCore.Identity;
using MySchool.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Data
{
    public class Seeder
    {
        // <summary>
        /// Populates the Role and User Tables with Initial data
        /// </summary>
        /// <param name="roleManager"></param>
        /// <param name="userManager"></param>
        /// <param name="context"></param>
        public static async void SeedDataBase(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, MySchoolDbContext context)
        {
            try
            {
                await context.Database.EnsureCreatedAsync();
                if (!context.Teachers.Any())
                {
                    string roles = File.ReadAllText(@"JsonFiles/Roles.json");
                    List<IdentityRole> listOfRoles = JsonConvert.DeserializeObject<List<IdentityRole>>(roles);
                    //List<string> listOfRoles = new List<string> { "Admin", "Regular" };

                    foreach (var role in listOfRoles)
                    {
                        await roleManager.CreateAsync(role);
                    }

                    string users = File.ReadAllText(@"JsonFiles/Users.json");
                    List<User> listOfUsers = JsonConvert.DeserializeObject<List<User>>(users);
                    int i = 0;
                    foreach (var user in listOfUsers)
                    {
                        await userManager.CreateAsync(user, user.Password);

                        // Adds the first 5 users to the Admin role and the others to the regular role
                        if (i < 5)
                        {
                            await userManager.AddToRoleAsync(user, "Admin");
                            i++;
                        }
                        else
                            await userManager.AddToRoleAsync(user, "Regular");
                    }

                    // Create teachers
                    string teachers = File.ReadAllText(@"JsonFiles/Teachers.json");
                    List<Teacher> listOfTeachers = JsonConvert.DeserializeObject<List<Teacher>>(teachers);

                    foreach (var teacher in listOfTeachers)
                    {
                        await context.Teachers.AddAsync(teacher);
                    }

                    // Create schools
                    string schools = File.ReadAllText(@"JsonFiles/Schools.json");
                    List<School> listOfSchools = JsonConvert.DeserializeObject<List<School>>(schools);

                    foreach (var school in listOfSchools)
                    {
                        await context.Schools.AddAsync(school);
                    }

                    // Create students
                    string students = File.ReadAllText(@"JsonFiles/Students.json");
                    List<Student> listOfStudents = JsonConvert.DeserializeObject<List<Student>>(students);

                    foreach (var student in listOfStudents)
                    {
                        await context.Students.AddAsync(student);
                    }

                    // Create Class
                    string classes = File.ReadAllText(@"JsonFiles/Classes.json");
                    List<Class> listOfClasses = JsonConvert.DeserializeObject<List<Class>>(classes);

                    foreach (var studentClass in listOfClasses)
                    {
                        await context.Classes.AddAsync(studentClass); ;
                    }


                    // Create Subjects
                    string subjects = File.ReadAllText(@"JsonFiles/Subjects.json");
                    List<Subject> listOfSubjects = JsonConvert.DeserializeObject<List<Subject>>(subjects);

                    foreach (var subject in listOfSubjects)
                    {
                        // subject.ClassId = listOfClasses.Single(c => c.Name == subject.Class.Name).Id;
                        await context.Subjects.AddAsync(subject); ;
                    }


                    // Create Topics
                    string topics = File.ReadAllText(@"JsonFiles/Topics.json");
                    List<Topic> listOfTopics = JsonConvert.DeserializeObject<List<Topic>>(topics);

                    foreach (var topic in listOfTopics)
                    {
                        // topic.SubjectId = listOfSubjects.Single(s => s.Title == topic.Subject.Title).SubjectID;
                        await context.Topics.AddAsync(topic); ;
                    }
                }
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
