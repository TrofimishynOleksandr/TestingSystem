using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.DAL.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public Group Group { get; set; }
        public int GroupId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<Test> Tests { get; set; }
    }
}
