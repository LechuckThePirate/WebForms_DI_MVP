using System;
using System.Linq;
using ITCR.Domain.Entities;

namespace ITCR.Services.Interfaces
{
    public interface ICitizenService
    {
        Citizen AddCitizen(string name, Guid specieId, Guid roleId, StatusEnum status);
        Citizen GetCitizen(Guid citizenId);
        IQueryable<Citizen> GetAllCitizens();
        IQueryable<Citizen> GetCitizensByRole(Guid roleId);
        Citizen UpdateCitizen(Guid citizenId, string newName, Guid newSpecieId, Guid newRoleId, StatusEnum newStatus);
        int GetCitizenCount();
        bool IsSkywalker(string name);
        bool SetCitizenRole(Citizen citizen, Role role);
        Citizen GetCitizenByName(string name);
        bool DeleteCitizen(Guid citizenId);
    }
}
