using Application.Common.Dto.Email;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Email
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequestDto request);
    }
}
