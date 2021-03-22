using Drip.Application.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Drip.Webapp.Models
{
    public class LoginViewModel
    {
        public List<User> users { get; set; } = new List<User>();

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }


    }
}
