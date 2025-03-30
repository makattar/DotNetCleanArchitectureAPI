using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Dto.Account.Request
{
    public class AuthenticationRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
