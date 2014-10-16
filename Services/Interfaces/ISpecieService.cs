using System;
using System.Linq;
using ITCR.Domain.Entities;

namespace ITCR.Services.Interfaces
{
    public interface ISpecieService
    {
        Specie AddSpecie(string description);
        Specie GetSpecieByDescription(string description);
        bool DeleteSpecie(Guid specieId);
        IQueryable<Specie> GetAllSpecies();
        Specie GetSpecie(Guid specieId);
        IQueryable<Specie> FindSpecies(string partialFilter = "");
        Specie UpdateSpecie(Guid specieId, string description);
        IQueryable<Specie> GetSpeciesForCombo();
        
    }
}
