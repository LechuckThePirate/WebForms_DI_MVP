using System.Linq;
using ITCR.Data.Interfaces;
using ITCR.Domain.Entities;
using ITCR.Services.Interfaces;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Services.Test
{
    [TestClass]
    public class CitizenServiceTests
    {

        private DIContainer _container = new DIContainer();

        [TestMethod]
        public void CitizenService_GetAllCitizens()
        {
            var service = _container.Resolve<ICitizenService>();
            var citizens = service.GetAllCitizens();
            Assert.AreEqual(service.GetCitizenCount(), citizens.Cast<Citizen>().Count());
        }

        [TestMethod]
        public void CitizenService_AddCitizen()
        {
            var roleSvc = _container.Resolve<IRoleService>();
            var specieSvc = _container.Resolve<ISpecieService>();
            var service = _container.Resolve<ICitizenService>();
            var specie = specieSvc.GetSpecieByDescription("Gungan");
            Assert.IsNotNull(specie,"Specie not null");
            var role = roleSvc.GetRoleByDescription("Slave");
            Assert.IsNotNull(role, "Role not null");
            var newCitizen =
                service.AddCitizen(
                    "New Citizen",
                    specie.SpecieId,
                    role.RoleId,
                    StatusEnum.Rebel
                );
            var dbCitizen = service.GetCitizen(newCitizen.CitizenId);
            Assert.AreEqual(dbCitizen, newCitizen);
        }

        [TestMethod]
        public void CitizenService_GetCitizensByRole()
        {
            var service = _container.Resolve<ICitizenService>();
            var roleSvc = _container.Resolve<IRoleService>();
            var role = roleSvc.GetRoleByDescription("Citizen");
            Assert.IsNotNull(role);
            var citizens = service.GetAllCitizens();
            citizens.Cast<Citizen>().ForEach(citizen => service.SetCitizenRole(citizen, role));
            var citByRole = service.GetCitizensByRole(role.RoleId);
            Assert.AreEqual(citizens.Cast<Citizen>().Count(), citByRole.Cast<Citizen>().Count());
        }

        [TestMethod]
        public void CitizenService_ChangeCitizenRole()
        {
            var service = _container.Resolve<ICitizenService>();
            var roleSvc = _container.Resolve<IRoleService>();
            var citizen = service.GetCitizenByName("Han Solo");
            var role = roleSvc.GetRoleByDescription("Slave");
            var ok = service.SetCitizenRole(citizen, role);
            Assert.IsTrue(ok);
            Assert.AreEqual(role.RoleId, citizen.Role.RoleId);
        }

        [TestMethod]
        public void CitizenService_UpdateCitizen()
        {
            var service = _container.Resolve<ICitizenService>();
            var citizen = service.GetAllCitizens().Cast<Citizen>().Last();
            var newCitizen = service.UpdateCitizen(citizen.CitizenId, "New Citizen Name", citizen.Specie.SpecieId, citizen.Role.RoleId, StatusEnum.Rebel);
            Assert.AreEqual("New Citizen Name", newCitizen.Name);
            Assert.AreEqual(StatusEnum.Rebel, newCitizen.Status);
        }

        [TestMethod]
        public void CitizenService_CheckSkywaylker()
        {
            var service = _container.Resolve<ICitizenService>();
            string name = "skywalker";
            Assert.IsTrue(service.IsSkywalker(name));
            name = "jabba the hut";
            Assert.IsFalse(service.IsSkywalker(name));
        }

        [TestMethod]
        public void CitizenService_DeleteCitizen()
        {
            var service = _container.Resolve<ICitizenService>();
            var citizen = service.GetAllCitizens().First();
            service.DeleteCitizen(citizen.CitizenId);
            Assert.IsNull(service.GetCitizen(citizen.CitizenId));
        }
    }
}
