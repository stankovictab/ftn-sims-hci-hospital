/***********************************************************************
 * Module:  User.cs
 * Author:  stankovictab
 * Purpose: Definition of the Class User
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;

namespace Classes
{
    public class User
    {
        public Boolean Login()
        {
            // TODO: implement
            return null;
        }

        public Boolean Logout()
        {
            // TODO: implement
            return null;
        }

        public Boolean DeleteAccount()
        {
            // TODO: implement
            return null;
        }

        private String Name;
        private String LastName;
        private String Username;
        private String Password;
        private String Email;
        private String Jmbg;
        private String Address;
        private Char Gender;
        private Boolean Active = false;
        private Roles Role;

    }
}