using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ITCR.Data.Interfaces;
using ITCR.Domain.Exceptions;
using System.Linq;
using ITCR.Domain.Entities;

namespace Services.Test
{
    [TestClass]
    public class RoleServiceTests
    {
        DIContainer _container = new DIContainer();

        [TestMethod]
        public void RoleService_AddRole()
        {
            var service = _container.Resolve<IRoleService>();
            var role = service.AddRole("New Role");
            Assert.AreEqual("New Role", role.Description);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException), "This field is required")]
        public void RoleService_AddRoleWithEmptyDescription()
        {
            var service = _container.Resolve<IRoleService>();
            service.AddRole("");
        }

        [TestMethod]
        public void RoleService_GetRoleById()
        {
            var service = _container.Resolve<IRoleService>();
            var firstRole = service.GetAllRoles().First();
            // Find a known Id
            var byId = service.GetRole(firstRole.RoleId);
            Assert.AreEqual(firstRole.RoleId, byId.RoleId);
            // This shouldn't find any
            byId = service.GetRole(Guid.NewGuid());
            Assert.IsNull(byId);
        }

        [TestMethod]
        public void RoleService_DeleteRole()
        {
            var service = _container.Resolve<IRoleService>();
            var firstRole = service.GetAllRoles().First();
            var count = service.GetAllRoles().Count();
            var ok = service.DeleteRole(firstRole.RoleId);
            Assert.IsTrue(ok);
            Assert.AreEqual(count - 1, service.GetAllRoles().Cast<Role>().Count());
        }

        [TestMethod]
        public void RoleService_GetFilteredRoles()
        {
            var service = _container.Resolve<IRoleService>();
            var roles = service.FindRoles("P");
            var count = roles.Cast<Role>().Count();
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void RoleService_GetAllRoles()
        {
            var service = _container.Resolve<IRoleService>();
            var count = service.GetAllRoles().Cast<Role>().Count();
            Assert.AreEqual(5, count);
        }

        [TestMethod]
        public void RoleService_UpdateRole()
        {
            var service = _container.Resolve<IRoleService>();
            var role = service.GetAllRoles().First();
            role  = service.UpdateRole(role.RoleId, "New Description");
            Assert.AreEqual("New Description", role.Description);
        }

        [TestMethod]
        public void CitizenService_GetComboRoles()
        {
            var service = _container.Resolve<IRoleService>();
            var species = service.GetRolesForCombo();
            Assert.AreEqual(5, species.Cast<Role>().Count());
        }

    }
}
