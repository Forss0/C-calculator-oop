using ASP.NET_Core_MVC_частина_1.Models;
using ASP.NET_Core_MVC_частина_1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Core_MVC_частина_1.Controllers
{
    public class ContactController
    {
        private Contact _contact;
        private ContactView _view;

        public ContactController(Contact contact, ContactView view)
        {
            _contact = contact;
            _view = view;
        }

        public void UpdateEmail(string email)
        {
            _contact.Email = email;
        }

        public void ShowContact()
        {
            _view.DisplayContact(_contact);
        }
    }
}