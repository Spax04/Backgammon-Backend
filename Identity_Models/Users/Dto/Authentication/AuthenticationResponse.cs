using Identity_Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity_Models.Authentication
{
    public class AuthenticationResponse : Response
    {
        public AuthenticationResponse() : base(true)
        {
        }

        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? ImgUrl { get; set; }
        public string? Token { get; set; }
        
    }
}
