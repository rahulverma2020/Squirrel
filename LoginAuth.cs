using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeploymentWithSquirrel
{
   public  static class LoginAuth
    {
        private static string username="admin";
        private static string password="admin";

        public static bool Authnticate(string usr,string Pwd)
        {
            if(username==usr && password==Pwd)
            {
                return true;
            }
            return false;
        }
    }
}
