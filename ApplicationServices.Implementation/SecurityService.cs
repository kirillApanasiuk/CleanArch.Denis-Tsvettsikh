using ApplicationService.Interfaces;
using System;

namespace ApplicationServices.Implementation
{
    public class SecurityService : ISecurityService
    {
        public bool IsCurrentUserAdmin { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string[] CurrentUserPermissions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
