using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.DAL.Models
{
    public class Test
    {
        public Test() 
        {
            Questions = new List<Question>();
            Groups = new List<Group>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Question> Questions { get; set; }
        public List<Group> Groups { get; set; }
        public Teacher Creator { get; set; }
        public int CreatorId { get; set; }
        public double Mark { get; set; }
    }
}
