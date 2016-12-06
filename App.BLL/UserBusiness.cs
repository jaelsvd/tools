using App.DAL;
using App.Entities;
using System.Collections.Generic;

namespace App.BLL
{
    public class UserBusiness
    {
        private UserRepository _userRepo;

        public UserBusiness()
        {
            _userRepo = new UserRepository();
        }
        public void AddUser(User user)
        {
            if(UserExists(user))
            {
                throw new UserAlreadyExistException();
            }

            _userRepo.InsertUser(user);
        }

        public List<User> GetAll()
        {
            return _userRepo.GetAll();
        }
        private bool UserExists(User user)
        {
            var userbLA = _userRepo.GetByNameAndId(user.Id, user.Name);
            return userbLA != null;
        }
    }
}
