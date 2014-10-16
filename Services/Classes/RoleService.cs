using System;
using System.Linq;
using ITCR.Data.Interfaces;
using ITCR.Domain.Entities;
using ITCR.Domain.Exceptions;

namespace ITCR.Services.Classes
{
    public class RoleService : IRoleService
    {

        private IDALContext _repo;
        protected IDALContext Repo { get { return _repo; } }

        public RoleService(IDALContext repo)
        {
            _repo = repo;
        }

        public Role AddRole(string description)
        {
            Role result = null;
            try
            {
                if (string.IsNullOrEmpty(description))
                    throw new ValidationException("This field is required");

                result = this.Repo.Roles.Add(new Role() { Description = description });
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }

        public Role GetRole(Guid roleId)
        {
            Role result = null;
            try
            {
                result = this.Repo.Roles.GetOne(o => o.RoleId.Equals(roleId));
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }

        public IQueryable<Role> FindRoles(string partialFilter = "")
        {
            IQueryable<Role> result = null;
            try
            {
                result = this.Repo.Roles
                    .Get(o => o.Description.ToUpper().Contains(partialFilter.ToUpper()));
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }

        public bool DeleteRole(Guid roleId)
        {
            bool result = false;
            try
            {
                var role = this.Repo.Roles.GetOne(o => o.RoleId.Equals(roleId));
                if (role == null)
                    throw new Exception("Role not found");
                result = this.Repo.Roles.Delete(role);
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }

        public IQueryable<Role> GetAllRoles()
        {
            IQueryable<Role> result = null;
            try
            {
                result = this.Repo.Roles.All();
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }

        public Role GetRoleByDescription(string description)
        {
            Role result = null;
            try
            {
                result = Repo.Roles.GetOne(o => o.Description.ToUpper() == description.ToUpper());
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }

        public Role UpdateRole(Guid roleId, string description)
        {
            Role result = null;
            try
            {
                var role = Repo.Roles.GetOne(o => o.RoleId.Equals(roleId));
                if (role == null)
                    throw new Exception("Role not found");
                role.Description = description;
                if (!Repo.Roles.Update(role))
                    throw new Exception("Error updating role");
                result = role;
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }

        public IQueryable<Role> GetRolesForCombo()
        {
            IQueryable<Role> result = null;
            try
            {
                result = Repo.Roles.All().OrderBy(o => o.Description);
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }


    }
}
