/*using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Models.Entities
{
    public class Quiz
    {
         [Key]
        public int QuizId { get; set; }
        public string Question { get; set; }
        public string AnswerType { get; set; }
        public string PreferedAnswer { get; set; }
        public string AddedById { get; set; }



        [Key]
        [ForeignKey("TopicId")]
        public int topicId { get; set; }
        public ICollection<QuizOption> QuizOptions { get; set; }

        public virtual Topic Topic { get; set; }


    }
}
*/