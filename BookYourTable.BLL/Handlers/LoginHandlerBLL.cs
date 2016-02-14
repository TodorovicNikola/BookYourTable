using BookYourTable.BLL.Models;
using BookYourTable.DAL.Handlers;
using BookYourTable.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookYourTable.BLL.Handlers
{
    public class LoginHandlerBLL
    {
        LoginHandlerDAL _loginHandlerDAL = new LoginHandlerDAL();

        public UserBLL loginAttempt(string e_mail, string password, out string message)
        {
            UserBLL userBLL = null;

            UserDBReplica userDBReplica = _loginHandlerDAL.loginAttempt(e_mail, password, out message);
            if(userDBReplica != null)
            {
                userBLL = new UserBLL(userDBReplica);
            }

            return userBLL;
        }
    }
}
