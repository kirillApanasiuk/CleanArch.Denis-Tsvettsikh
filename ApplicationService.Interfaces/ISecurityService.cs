using System;

namespace ApplicationService.Interfaces
{
    public interface ISecurityService
    {
        bool IsCurrentUserAdmin { get; set; }
        string[] CurrentUserPermissions { get; set; }
    }
}
