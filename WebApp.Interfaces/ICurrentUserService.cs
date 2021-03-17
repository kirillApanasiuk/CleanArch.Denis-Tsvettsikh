using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces.WebApp
{
    public interface ICurrentUserService
    {
        string Email { get; set; }
    }
}
