using System;
using System.Linq;
using ITCR.Data.Interfaces;
using ITCR.Domain.Entities;
using ITCR.Domain.Exceptions;
using ITCR.Services.Interfaces;

namespace ITCR.Services.Classes
{
    public class SpecieService : ISpecieService
    {
        private IDALContext _repo;
        protected IDALContext Repo { get { return _repo; } }
        public SpecieService(IDALContext repo)
        {
            _repo = repo;
        }

        public Specie AddSpecie(string description)
        {
            Specie result = null;
            try
            {
                if (string.IsNullOrEmpty(description))
                    throw new ValidationException("This field is required");

                result = this.Repo.Species.Add(new Specie() { Description = description });
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }

        public Specie GetSpecie(Guid specieId)
        {
            Specie result = null;
            try
            {
                result = this.Repo.Species.GetOne(o => o.SpecieId.Equals(specieId));
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }

        public IQueryable<Specie> FindSpecies(string partialFilter = "")
        {
            IQueryable<Specie> result = null;
            try
            {
                result = this.Repo.Species
                    .Get(o => o.Description.ToUpper().Contains(partialFilter.ToUpper()));
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }

        public bool DeleteSpecie(Guid specieId)
        {
            bool result = false;
            try
            {
                var specie = this.Repo.Species.GetOne(o => o.SpecieId.Equals(specieId));
                if (specie == null)
                    throw new Exception("Specie not found");
                result = this.Repo.Species.Delete(specie);
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }

        public IQueryable<Specie> GetAllSpecies()
        {
            IQueryable<Specie> result = null;
            try
            {
                result = this.Repo.Species.All();
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }

        public Specie GetSpecieByDescription(string description)
        {
            Specie result = null;
            try
            {
                result = Repo.Species.GetOne(o => o.Description.ToUpper().Equals(description.ToUpper()));
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }

        public Specie UpdateSpecie(Guid specieId, string description)
        {
            Specie result = null;
            try
            {
                var specie = Repo.Species.GetOne(o => o.SpecieId.Equals(specieId));
                if (specie == null)
                    throw new Exception("Specie not found");
                specie.Description = description;
                if (!Repo.Species.Update(specie))
                    throw new Exception("Could not update specie");
                result = specie;
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }

        public IQueryable<Specie> GetSpeciesForCombo()
        {
            IQueryable<Specie> result = null;
            try
            {
                result = Repo.Species.All().OrderBy(o => o.Description);
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }


    }
}
