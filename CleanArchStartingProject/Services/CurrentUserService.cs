using Infrastructure.Interfaces.WebApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public string Email { get => "test@mail.com"; set => Email = value; }
    }
}
