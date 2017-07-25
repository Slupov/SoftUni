using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Client.Utilities;
using TeamBuilder.Models;

namespace TeamBuilder.Client.Core
{
    class AuthenticationManager
    {
        private static User currentUser;

        public static void Login(User user)
        {
            currentUser = user;
        }

        public static void Logout()
        {
            if (currentUser == null)
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LogoutFirst);
            }

            currentUser = null;
        }

        /// <summary>
        /// Checks weather there is a logged user and throws and exception if not
        /// </summary>
        public static void Authorize()
        {
            if (currentUser == null)
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LoginFirst);
            }
        }

        /// <summary>
        /// Returns weather there is a logged user
        /// </summary>
        public static bool IsAuthenticated()
        {
            return currentUser != null;
        }

        public static User GetCurrentUser()
        {
            if (currentUser == null)
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LoginFirst);
            }

            return currentUser;
        }
    }
}