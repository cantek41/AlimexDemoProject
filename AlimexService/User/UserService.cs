using AlimexDAL.Entity;
using AlimexDAL.Repository;
using AlimexIdentity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlimexService
{
    public class UserService : BaseService<User>, IUserService
    {
        private IRepository<User> userRepo;
        public UserService(IRepository<User> userRepo)
            :base(userRepo)
        {
            this.userRepo = userRepo;
        }

        public void createUser(LoginModel userModel)
        {
            User user=new User();
            user.Name=userModel.userName;
            user.Password = generatePassword(userModel.password);
            //user.Roles.Add(new Role())
            Insert(user);
        }
        private string generatePassword(string pass)
        {
            if (String.IsNullOrEmpty(pass))
                return String.Empty;

            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] textData = System.Text.Encoding.UTF8.GetBytes(pass);
                byte[] hash = sha.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }


        public User login(LoginModel userModel)
        {
            var user = GetAll().Where(x => x.Name == userModel.userName).FirstOrDefault();
            if (user.Password == generatePassword(userModel.password))
                return user;
            else
                return null;
        }
    }
}
