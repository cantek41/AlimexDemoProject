using AlimexDAL.Entity;
using AlimexIdentity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlimexService
{
    public interface IUserService : IBaseService<User>
    {
        void createUser(LoginModel userModel);
        User login(LoginModel userModel);
    }
}
