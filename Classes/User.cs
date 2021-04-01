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

        public User(String jmbg)
        {
            this.Jmbg = jmbg;
        }
        public Boolean Login()
        {
            // TODO: implement
            return false;
        }

        public Boolean Logout()
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteAccount()
        {
            // TODO: implement
            return false;
        }

        private String Name;
        private String LastName;
        private String Username;
        private String Password;
        private String Email;
        public String Jmbg { get; set; }
        private String Address;
        private Char Gender;
        private Boolean Active = false;
        private Roles Role;

    }
}