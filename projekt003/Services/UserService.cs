using LiteDB;
using projekt003.Buisness;
using projekt003.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projekt003.Services
{
    public class UserService : ServiceBase
    {
        public UserService(Database database) : base(database)
        {
            
        }

        public int DeleteUsers()
        {
            using (LiteDatabase db = Database.Initialize())
            {
                return db.GetCollection<User>().DeleteAll();
            }
        }

        public void InsertUser(User user)
        {
            using (LiteDatabase db = Database.Initialize())
            {
                var col = db.GetCollection<User>().Insert(user);
            }
        }

        public User GetUserById(string id)
        {
            using (LiteDatabase db = Database.Initialize())
            {
                var user = db.GetCollection<User>().FindById(id);
                return user;
            }
        }

        public User GetUserByLogin(string Login)
        {
            using (var db = Database.Initialize())
            {
                var user = db.GetCollection<User>().FindOne(Query.EQ("Login", Login));
                return user;
            }
        }

        public List<User> GetAllUsers()
        {
            var users = new List<User>();
            using (LiteDatabase db = Database.Initialize())
            {
                var col = db.GetCollection<User>().FindAll();
                foreach (var item in col)
                {
                    users.Add(item);
                }
            }
            return users;
        }
    }
}
