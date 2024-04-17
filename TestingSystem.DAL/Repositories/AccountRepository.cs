using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.DAL.Models;

namespace TestingSystem.DAL.Repositories
{
    public class AccountRepository
    {
        private readonly TestingSystemContext _context;

        public AccountRepository(TestingSystemContext context)
        {
            _context = context;
        }

        public bool IsExists(string login)
        {
            return _context.Students.Any(s => s.Login == login) || _context.Teachers.Any(t => t.Login == login);
        }
    }
}
