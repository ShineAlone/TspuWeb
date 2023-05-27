using lab1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab1.Repositories
{
    public static class StaticUserRepository
    {
        private static List<User> Users { get; set; }
        private static int validId;

        public static User[] Get()
        {
            return Users.ToArray();
        }

        public static User? Get(int? id)
        {
            return Users.Find(x => x.Id == id);
        }

        public static void Add(User user)
        {
            user.Id = validId++;
            Users.Add(user);
        }

        public static bool Update(User user)
        {
            User? userInList = Get(user.Id);

            if (userInList != null)
            {
                userInList.Password = user.Password;
                userInList.Login = user.Login;
                return true;
            }
            return false;
        }

        public static bool Delete(int id)
        {
            User? user = Get(id);

            if (user != null)
            {
                Users.Remove(user);
                return true;
            }
            return false;
        }
    }
}
