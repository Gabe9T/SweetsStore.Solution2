using System.Collections.Generic;

namespace SweetStore.Models
{
    public class Treat
    {
        public int TreatId { get; set; }
        public string Name { get; set; }
        public string Description {get; set; }
        public List<TreatFlavor> TreatFlavors { get; set; }
    }
}