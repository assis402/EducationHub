using EducationHub.Business.Entities;
using System;
using System.Collections.Generic;
namespace EducationHub.Data.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>
            {
                new (Guid.NewGuid(), "batman", "batman", "manager"),
                new (Guid.NewGuid(), "robin", "robin", "student"),
            };

            return users.FirstOrDefault(x => 
                x.Username == username && 
                x.Password == password);
        }
    }
}
