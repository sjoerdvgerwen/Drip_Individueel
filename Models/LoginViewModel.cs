using Drip.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drip.Webapp.Models
{
    public class LoginViewModel
    {
        public List<User> users { get; set; } = new List<User>();
    }
}
