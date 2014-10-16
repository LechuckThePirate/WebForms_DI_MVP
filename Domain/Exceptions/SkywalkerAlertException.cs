using ITCR.Domain.Entities;

namespace ITCR.Domain.Exceptions
{
    /// <summary>
    /// Thrown when someone tries to register Skywalker as part of the citizen name
    /// </summary>
    public class SkywalkerAlertException : BaseException
    {

        public string Name { get; set; }
        public Specie Specie { get; set; }
        public Role Role { get; set; }

        public SkywalkerAlertException(string name, Specie specie, Role role) : base("Skywalker intrusion - Logging!")
        {
            Name = name;
            Specie = specie;
            Role = role;
        }

    }
}
