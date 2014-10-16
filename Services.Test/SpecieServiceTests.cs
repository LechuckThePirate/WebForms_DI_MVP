using System;
using System.Linq;
using ITCR.Domain.Entities;
using ITCR.Domain.Exceptions;
using ITCR.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Services.Test
{
    [TestClass]
    public class SpecieServiceTests
    {
        DIContainer _container = new DIContainer();

        [TestMethod]
        public void SpecieService_AddSpecie()
        {
            var service = _container.Resolve<ISpecieService>();
            var specie = service.AddSpecie("New Specie");
            Assert.AreEqual("New Specie", specie.Description);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException), "This field is required")]
        public void SpecieService_AddSpecieWithEmptyDescription()
        {
            var service = _container.Resolve<ISpecieService>();
            service.AddSpecie("");
        }

        [TestMethod]
        public void SpecieService_GetSpecieById()
        {
            var service = _container.Resolve<ISpecieService>();
            var firstSpecie = service.GetAllSpecies().First();
            // Find a known Id
            var byId = service.GetSpecie(firstSpecie.SpecieId);
            Assert.AreEqual(firstSpecie.SpecieId, byId.SpecieId);
            // This shouldn't find any
            byId = service.GetSpecie(Guid.NewGuid());
            Assert.IsNull(byId);
        }

        [TestMethod]
        public void SpecieService_DeleteSpecie()
        {
            var service = _container.Resolve<ISpecieService>();
            var firstSpecie = service.GetAllSpecies().First();
            var count = service.GetAllSpecies().Count();
            var ok = service.DeleteSpecie(firstSpecie.SpecieId);
            Assert.IsTrue(ok);
            Assert.AreEqual(count - 1, service.GetAllSpecies().Cast<Specie>().Count());
        }

        [TestMethod]
        public void SpecieService_GetAllSpecies()
        {
            var service = _container.Resolve<ISpecieService>();
            var count = service.GetAllSpecies().Cast<Specie>().Count();
            Assert.AreEqual(5, count);
        }

        [TestMethod]
        public void SpecieService_GetFilteredSpecies()
        {
            var service = _container.Resolve<ISpecieService>();
            var species = service.FindSpecies("J");
            Assert.AreEqual(1, species.Cast<Specie>().Count());
        }

        [TestMethod]
        public void SpecieService_UpdateSpecie()
        {
            var service = _container.Resolve<ISpecieService>();
            var specie = service.GetSpecieByDescription("Jawa");
            specie.Description = "Altered Human";
            specie = service.UpdateSpecie(specie.SpecieId, specie.Description);
            Assert.AreEqual("Altered Human", specie.Description);
        }

        [TestMethod]
        public void SpecieService_GetComboSpecies()
        {
            var service = _container.Resolve<ISpecieService>();
            var species = service.GetSpeciesForCombo();
            Assert.AreEqual(5, species.Cast<Specie>().Count());
        }

    }
}
