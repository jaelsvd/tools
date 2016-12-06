using App.Entities;
using System.Collections.Generic;
using System.Linq;

namespace App.DAL
{
    public class UserRepository
    {
        private TicketsDbContext _context;

        public UserRepository()
        {
            _context = new TicketsDbContext();
        }
        public void InsertUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetByNameAndId(int id, string name)
        {
            return _context.Users.FirstOrDefault(x => x.Name == name && x.Id != id);
        }
    }
}
