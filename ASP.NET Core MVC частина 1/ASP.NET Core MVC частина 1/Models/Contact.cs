using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Core_MVC_частина_1.Models
{
    public class Contact
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string AlternativePhone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        public Contact(string name, string phone, string altPhone, string email, string description)
        {
            Name = name;
            Phone = phone;
            AlternativePhone = altPhone;
            Email = email;
            Description = description;
        }
    }
}
