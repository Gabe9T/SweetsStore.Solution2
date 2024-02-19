using System.Collections.Generic;

namespace SweetStore.Models
{
    public class Flavor
    {
        public int FlavorId { get; set; }
        public string Name { get; set; }
        public List<TreatFlavor> TreatFlavors { get; set; }
    }
}