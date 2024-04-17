using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestingSystem.DAL.Models
{
    public class Group
    {
        public Group()
        {
            Teachers = new List<Teacher>();
            Students = new List<Student>();
            Tests = new List<Test>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Student> Students { get; set; }
        public List<Test> Tests { get; set; }
    }
}
