using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.DAL.Models
{
    public class Question
    {
        public Question() 
        {
            Answers = new List<Answer>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public Test Test { get; set; }
        public int TestId { get; set; }
        public List<Answer> Answers { get; set; }
        public double Value { get; set; }
    }
}
