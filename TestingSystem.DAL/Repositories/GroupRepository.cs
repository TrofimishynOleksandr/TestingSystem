using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.DAL.Models;

namespace TestingSystem.DAL.Repositories
{
    public class GroupRepository
    {
        private readonly TestingSystemContext _context;

        public GroupRepository(TestingSystemContext context)
        {
            _context = context;
        }

        public IEnumerable<Group> GetAll()
        {
            return _context.Groups.AsNoTracking().Include(g=>g.Tests).Include(g=>g.Students).Include(g=>g.Teachers).ToList();
        }

        public Group GetByName(string name)
        {
            return _context.Groups.AsNoTracking().FirstOrDefault(g => g.Name == name);
        }

        public void Add(Group group)
        {
            _context.Groups.Add(group);
        }

        public void Update(Group group)
        {
            _context.Groups.Update(group);
        }

        public void Delete(Group group)
        {
            _context.Groups.Remove(group);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
