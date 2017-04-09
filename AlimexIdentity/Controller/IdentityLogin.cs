using AlimexIdentity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlimexIdentity.Controller
{
    public class IdentityLogin
    {
        public string loginFaileMessage { get; set; }
        public IdentityLogin()
        {
        }

        public bool Login(LoginModel model)
        {
            if (model == null)
                throw new NullReferenceException("Null model");
            //TODO:dbden user check yapılmalı

            Identity.setIdentity(new UserIdentiyModel()
            {
                userName = model.userName,
                userId = "dfsdfsd",
                timeOut = 10,
                role = new List<string>() { "Admin" }
            });
            return true;
        }
        
    }

}
