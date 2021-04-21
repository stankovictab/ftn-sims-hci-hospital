using System;

namespace Classes
{
    public class User
    {
        private String Name;
        private String LastName;
        public String Username { get; set; }
        private String Password;
        private String Email;
        public String Jmbg { get; set; }
        private String Address;
        private Char Gender;
        private Boolean Active = false;
        private Roles Role;
		
        public User() { }

        public User(String jmbg)
        {
            this.Jmbg = jmbg;
        }

        // Za konstruktor su postavljene default vrednosti
        public User(string name = "", string lastName = "", string username = "", string password = "", string email = "", string jmbg = "", string address = "", char gender = 'N', bool active = false, Roles role = Roles.Patient)
        {
            // Ovo su seteri
            Name1 = name;
            LastName1 = lastName;
            Username1 = username;
            Password1 = password;
            Email1 = email;
            Jmbg1 = jmbg;
            Address1 = address;
            Gender1 = gender;
            Active1 = active;
            Role1 = role;
        }

        public string Name1 { get => Name; set => Name = value; }
        public string LastName1 { get => LastName; set => LastName = value; }
        public string Username1 { get => Username; set => Username = value; }
        public string Password1 { get => Password; set => Password = value; }
        public string Email1 { get => Email; set => Email = value; }
        public string Jmbg1 { get => Jmbg; set => Jmbg = value; }
        public string Address1 { get => Address; set => Address = value; }
        public char Gender1 { get => Gender; set => Gender = value; }
        public bool Active1 { get => Active; set => Active = value; }
        public Roles Role1 { get => Role; set => Role = value; }

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
    }
}