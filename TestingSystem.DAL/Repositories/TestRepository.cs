using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.DAL.Models;

namespace TestingSystem.DAL.Repositories
{
    public class TestRepository
    {
        private readonly TestingSystemContext _context;

        public TestRepository(TestingSystemContext context)
        {
            _context = context;
        }

        public void Add(Test test)
        {
            _context.Tests.Add(test);
        }

        public void Update(Test test)
        {
            _context.Tests.Update(test);
        }

        public void Delete(Test test)
        {
            _context.Tests.Remove(test);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
