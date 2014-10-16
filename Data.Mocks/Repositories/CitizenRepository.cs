using System.Collections.Generic;
using ITCR.Data.Interfaces;
using ITCR.Domain.Entities;

namespace ITCR.Data.Mocks.Repositories
{
    public class CitizenRepository : Repository<Citizen>, ICitizenRepository
    {
        private static List<Citizen> _mockDbSet = new List<Citizen> {
                    new Citizen { Name = "Han Solo", Specie = new Specie { Description = "Human"}, Role = new Role { Description = "Citizen"}, Status = StatusEnum.Rebel},
                    new Citizen { Name = "Chewbacca", Specie = new Specie { Description = "Wookie"}, Role = new Role { Description = "Slave"}, Status = StatusEnum.Rebel} ,
                    new Citizen { Name = "Darth Vader" }
                };

        protected override List<Citizen> MockDbSet
        {
            get { return _mockDbSet; }
        }

        public CitizenRepository(IDataContext context) { }
    }
}
