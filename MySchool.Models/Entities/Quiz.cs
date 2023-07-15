/*using System;
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
        // [Key]
        //public int QuizId { get; set; }


         
        
        [Key]
        [ForeignKey("TopicId")]
        public int topicId { get; set; }


        public virtual Topic Topic { get; set; }

        
    }
}
*/