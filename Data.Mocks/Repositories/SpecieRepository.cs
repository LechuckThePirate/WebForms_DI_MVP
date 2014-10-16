using System.Collections.Generic;
using ITCR.Data.Interfaces;
using ITCR.Domain.Entities;

namespace ITCR.Data.Mocks.Repositories
{
    public class SpecieRepository : Repository<Specie>, ISpecieRepository
    {
        private static List<Specie> _mockDbSet = new List<Specie> {
                    new Specie { Description = "Human" },
                    new Specie { Description = "Wookie" },
                    new Specie { Description = "Jawa" },
                    new Specie { Description = "Gungan" },
                    new Specie { Description = "Mon Calamari" }
                };

        protected override List<Specie> MockDbSet
        {
            get { return _mockDbSet; }
        }
        public SpecieRepository(IDataContext context) { }
    }
}
