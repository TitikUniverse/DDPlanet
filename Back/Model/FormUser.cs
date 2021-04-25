using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIApp.Model
{
    public class FormUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }
        public string TextMessage { get; set; }
        public string PhoneNumber { get; set; }
    }
}
