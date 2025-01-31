using MainCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCode.Repository
{
    public abstract class LoginHandler
    {
        protected LoginHandler successor;

        public void SetSuccessor(LoginHandler successor)
        {
            this.successor = successor;
        }

        public abstract void Login(ref string username);
    }
}
