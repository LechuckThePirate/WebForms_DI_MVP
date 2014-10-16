using System.Collections.Generic;
using ITCR.Data.Interfaces;
using ITCR.Domain.Entities;

namespace ITCR.Data.Mocks.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private static List<Role> _mockDbSet = new List<Role> {
                            new Role { Description = "Queen" },
                            new Role { Description = "Prime Minister" },
                            new Role { Description = "Politician" },
                            new Role { Description = "Citizen" },
                            new Role { Description = "Slave" }
                        };

        protected override List<Role> MockDbSet
        {
            get { return _mockDbSet; }
        }

        public RoleRepository(IDataContext context) { 

        }

    }
}
