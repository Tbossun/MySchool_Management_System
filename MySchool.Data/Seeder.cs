using Microsoft.AspNetCore.Identity;
using MySchool.Data.Context;
using MySchool.Models.Entities;
using Newtonsoft.Json;
using System.IO;

namespace MySchool.Data
{
    public class Seeder
    {
        /// <summary>
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
                if (!context.Users.Any())
                {
                    string rolesJson = File.ReadAllText(@"JsonFiles/Roles.json");
                    List<Role> listOfRoles = JsonConvert.DeserializeObject<List<Role>>(rolesJson);

                    foreach (var role in listOfRoles)
                    {
                        await roleManager.CreateAsync(new IdentityRole(role.Name));
                    }

                    string usersJson = File.ReadAllText(@"JsonFiles/Users.json");
                    List<User> listOfUsers = JsonConvert.DeserializeObject<List<User>>(usersJson);
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
                }

                // Add code to seed other tables using the corresponding JSON files
                string classesJson = File.ReadAllText(@"JsonFiles/Classes.json");
                List<Class> listOfClasses = JsonConvert.DeserializeObject<List<Class>>(classesJson);
                context.Classes.AddRange(listOfClasses);

                string quizzesJson = File.ReadAllText(@"JsonFiles/Quizzes.json");
                List<Quiz> listOfQuizzes = JsonConvert.DeserializeObject<List<Quiz>>(quizzesJson);
                context.Quizzes.AddRange(listOfQuizzes);

                string schoolsJson = File.ReadAllText(@"JsonFiles/Schools.json");
                List<School> listOfSchools = JsonConvert.DeserializeObject<List<School>>(schoolsJson);
                context.Schools.AddRange(listOfSchools);

                string studentsJson = File.ReadAllText(@"JsonFiles/Students.json");
                List<Student> listOfStudents = JsonConvert.DeserializeObject<List<Student>>(studentsJson);
                context.Students.AddRange(listOfStudents);

                string subjectsJson = File.ReadAllText(@"JsonFiles/Subjects.json");
                List<Subject> listOfSubjects = JsonConvert.DeserializeObject<List<Subject>>(subjectsJson);
                context.Subjects.AddRange(listOfSubjects);

                string teachersJson = File.ReadAllText(@"JsonFiles/Teachers.json");
                List<Teacher> listOfTeachers = JsonConvert.DeserializeObject<List<Teacher>>(teachersJson);
                context.Teachers.AddRange(listOfTeachers);

                string teacherAssignmentsJson = File.ReadAllText(@"JsonFiles/TeacherAssignments.json");
                List<TeacherAssignment> listOfTeacherAssignments = JsonConvert.DeserializeObject<List<TeacherAssignment>>(teacherAssignmentsJson);
                context.TeacherAssignments.AddRange(listOfTeacherAssignments);

                string topicsJson = File.ReadAllText(@"JsonFiles/Topics.json");
                List<Topic> listOfTopics = JsonConvert.DeserializeObject<List<Topic>>(topicsJson);
                context.Topics.AddRange(listOfTopics);

                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
