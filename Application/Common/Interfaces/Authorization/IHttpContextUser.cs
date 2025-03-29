using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Interfaces.Authorization
{
    public interface IHttpContextUser
    {
        string? Id { get; }
    }
}
