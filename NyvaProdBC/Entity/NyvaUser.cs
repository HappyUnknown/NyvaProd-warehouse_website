using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NyvaProdBC.Entity
{
    [System.ComponentModel.DataAnnotations.Schema.Table("NyvaProdUsers")]
    public class NyvaUser
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int UserRole { get; set; }
        public NyvaUser() { }
        public NyvaUser(int id, string firstName, string lastName, string fatherName, string email, string phone, string password, int userRole)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            FatherName = fatherName;
            Email = email;
            Phone = phone;
            Password = password;
            UserRole = userRole;
        }
        public NyvaUser(string firstName, string lastName, string fatherName, string email, string phone, string password, int userRole)
        {
            FirstName = firstName;
            LastName = lastName;
            FatherName = fatherName;
            Email = email;
            Phone = phone;
            Password = password;
            UserRole = userRole;
        }
        public override string ToString()
        {
            return Email;
        }
    }
}