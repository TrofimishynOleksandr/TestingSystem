using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.DAL.Models;

namespace TestingSystem.DAL.Repositories
{
    public class TeacherRepository
    {
        private readonly TestingSystemContext _context;

        public TeacherRepository(TestingSystemContext context)
        {
            _context = context;
        }

        public bool IsExists(Teacher teacher)
        {
            return _context.Teachers.Any(t => t.Login == teacher.Login);
        }

        public Teacher? FindAccount(Teacher teacher)
        {
            return _context.Teachers.Include(t=>t.Groups).FirstOrDefault(t => t.Login == teacher.Login && t.Password == teacher.Password);
        }

        public void Add(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
        }

        public void Update(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
        }

        public void Delete(Teacher teacher)
        {
            _context.Teachers.Remove(teacher);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
