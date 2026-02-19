using ASP.NET_Core_MVC_частина_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Core_MVC_частина_1.Views
{
     public class ContactView
    {
        public void DisplayContact(Contact contact)
        {
            Console.WriteLine("===== КОНТАКТ =====");
            Console.WriteLine($"Ім'я: {contact.Name}");
            Console.WriteLine($"Телефон: {contact.Phone}");
            Console.WriteLine($"Альтернативний телефон: {contact.AlternativePhone}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Опис: {contact.Description}");
            Console.WriteLine();
        }
    }
}
