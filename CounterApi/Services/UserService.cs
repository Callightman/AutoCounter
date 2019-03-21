using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CounterApi.Models;

namespace CounterApi.Services
{
    public class UserService
    {
        ApplicationContext _context;
        public UserService()
        {
            _context = new ApplicationContext();
        }
        public User ValidateUser(string username, string password)
        {
            return _context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
        }
        }
}