using System;
using System.Linq;
using ITCR.Data.Interfaces;
using ITCR.Domain.Entities;
using ITCR.Domain.Exceptions;
using ITCR.Services.Interfaces;

namespace ITCR.Services.Classes
{
    public class CitizenService : ICitizenService
    {

        private const string SKYWALKER = "SKYWALKER";
        
        private IDALContext _repo;
        protected IDALContext Repo { get { return _repo; } }

        public CitizenService(IDALContext repo)
        {
            this._repo = repo;
        }

        public Citizen AddCitizen(string name, Guid specieId, Guid roleId, StatusEnum status)
        {
            Citizen result = null;
            try
            {
                var specie = Repo.Species.GetOne(o => o.SpecieId.Equals(specieId));
                var role = Repo.Roles.GetOne(o => o.RoleId.Equals(roleId));

                if (string.IsNullOrEmpty(name))
                    throw new ValidationException("This field is required", "Citizen", "Name");
                if (IsSkywalker(name))
                    throw new SkywalkerAlertException(name, specie, role);
                if (specie == null)
                    throw new ValidationException("The specie doesn't exist", "Citizen", "Specie", specieId, null);
                if (role == null)
                    throw new ValidationException("The role doesn't exist", "Citizen", "Role", roleId, null);
                
                var citizen = new Citizen
                {
                    Name = name,
                    Specie = specie,
                    Role = role,
                    Status = status
                };
                result = Repo.Citizens.Add(citizen);
            }
            catch (SkywalkerAlertException ex)
            {
                DeathstarRESTClient.Current.PostAlert(ex.Name, ex.Specie, ex.Role);
                BaseException.HandleException(ex);
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }

        public Citizen GetCitizen(Guid citizenId)
        {
            Citizen result = null;
            try
            {
                result = Repo.Citizens.GetOne(o => o.CitizenId.Equals(citizenId));
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }

        public IQueryable<Citizen> GetAllCitizens()
        {
            IQueryable<Citizen> result = null;
            try
            {
                result = Repo.Citizens.All();
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }

        public IQueryable<Citizen> GetCitizensByRole(Guid roleId)
        {
            IQueryable<Citizen> result = null;
            try
            {
                var role = Repo.Roles.GetOne(o => o.RoleId.Equals(roleId));
                if (role == null)
                    throw new Exception("Invalid role");
                result = Repo.Citizens.Get(c => c.Role.RoleId.Equals(roleId));
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }

        public Citizen UpdateCitizen(Guid citizenId, string newName, Guid newSpecieId, Guid newRoleId, StatusEnum newStatus)
        {
            Citizen result = null;
            try
            {
                var citizen = Repo.Citizens.GetOne(c => c.CitizenId.Equals(citizenId));
                if (citizen == null)
                    throw new Exception("Invalid citizen");
                var role = Repo.Roles.GetOne(r => r.RoleId.Equals(newRoleId));
                var specie = Repo.Species.GetOne(s => s.SpecieId.Equals(newSpecieId));
                
                if (IsSkywalker(newName))
                    throw new SkywalkerAlertException(newName, specie, role);
                if (role == null)
                    throw new ValidationException("Invalid role","Citizen", "Role");
                if (specie == null)
                    throw new ValidationException("Invalid specie", "Citizen","Specie");

                citizen.Name = newName;
                citizen.Specie = specie;
                citizen.Role = role;
                citizen.Status = newStatus;

                Repo.Citizens.Update(citizen);
                result = citizen;
            }
            catch (SkywalkerAlertException ex)
            {
                DeathstarRESTClient.Current.PostAlert(ex.Name, ex.Specie, ex.Role);
                BaseException.HandleException(ex);
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }

        public int GetCitizenCount()
        {
            int count = -1;
            try
            {
                count = Repo.Citizens.Count;
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return count;
        }

        public bool IsSkywalker(string name)
        {
            bool result = false;
            try
            {
                result = name.Trim().ToUpper().Contains(SKYWALKER);
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }

        public bool SetCitizenRole(Citizen citizen, Role role)
        {
            bool result = false;
            try
            {
                citizen.Role = role;
                Repo.Citizens.Update(citizen);
                result = true;
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }

        public Citizen GetCitizenByName(string name)
        {
            Citizen result = null;
            try
            {
                result = Repo.Citizens.GetOne(o => o.Name.Trim().ToUpper().Equals(name.Trim().ToUpper()));
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }

        public bool DeleteCitizen(Guid citizenId)
        {
            bool result = false;
            try
            {
                var citizen = Repo.Citizens.GetOne(o => o.CitizenId.Equals(citizenId));
                if (citizen == null)
                    throw new Exception("Citizen not found");
                result = Repo.Citizens.Delete(citizen);
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }

    }

}
