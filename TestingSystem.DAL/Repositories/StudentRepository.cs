using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.DAL.Models;

namespace TestingSystem.DAL.Repositories
{
    public class StudentRepository
    {
        private readonly TestingSystemContext _context;

        public StudentRepository(TestingSystemContext context)
        {
            _context = context;
        }

        public bool IsExists(Student student)
        {
            return _context.Students.Any(s => s.Login == student.Login);
        }

        public Student? FindAccount(Student student)
        {
            return _context.Students.Include(s=>s.Tests).Include(s=>s.Group).FirstOrDefault(s => s.Login == student.Login && s.Password == student.Password);
        }

        public void Add(Student student)
        {
            _context.Students.Add(student);
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
        }

        public void Delete(Student student)
        {
            _context.Students.Remove(student);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
