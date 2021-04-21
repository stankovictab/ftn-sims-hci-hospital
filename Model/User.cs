/***********************************************************************
 * Module:  User.cs
 * Author:  stankovictab
 * Purpose: Definition of the Class User
 ***********************************************************************/

using Classes;
using System;

public class User
{
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
   private String Jmbg;
   private String Address;
   private Char Gender;
   private Boolean Active = false;
   private Roles Role;

}