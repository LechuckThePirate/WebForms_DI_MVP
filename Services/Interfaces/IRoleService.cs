using ITCR.Domain.Entities;
using System;
using System.Linq;

namespace ITCR.Data.Interfaces
{
    public interface IRoleService
    {
        Role AddRole(string description);
        Role GetRole(Guid roleId);
        Role GetRoleByDescription(string description);
        IQueryable<Role> FindRoles(string partialFilter = null);
        bool DeleteRole(Guid roleId);
        IQueryable<Role> GetAllRoles();
        Role UpdateRole(Guid roleId, string description);
        IQueryable<Role> GetRolesForCombo(); 
        
    }
}
