using System;

namespace ITCR.Domain.Entities
{
    [Serializable]
    public class SkywalkerAlert
    {
        public DateTime Timestamp { get; set; }
        public string Name { get; set; }
        public Specie Specie { get; set; }
        public Role Role { get; set; }

        public string ClientIP { get; set; }
        public string BrowserInfo { get; set; }

      
    }
}