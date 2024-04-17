using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.DAL.Models
{
    public class Teacher
    {
        public Teacher()
        {
            Groups = new List<Group>();
        }
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<Group> Groups { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
