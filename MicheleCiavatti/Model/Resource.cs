namespace Model
{
    public enum Resource
    {
        Water = 0, Wood = 1, Energy = 2, Metal = 3, Citizen = 4, Gold = 5
    }

    public static class ResourceExtension {
        
        public static string getSimpleBuilding(this Resource r)
        {
            switch (r) {
                case Resource.Water: return "Depurator";
                case Resource.Wood: return "Woodcutter";
                case Resource.Energy: return "Power_plant";
                case Resource.Metal: return "Foundry";
                case Resource.Citizen: return "House";
                case Resource.Gold: return "Mine";
                default: throw new ArgumentException();
            }
        }

        public static string getAdvancedBuilding(this Resource r)
        {
            switch (r) {
                case Resource.Water: return "Ultrafiltration_complex";
                case Resource.Wood: return "Lumber_refinary";
                case Resource.Energy: return "Quantum_reactor";
                case Resource.Metal: return "Forge";
                case Resource.Citizen: return "Skyscraper";
                case Resource.Gold: return "Mineral_station";
                default: throw new ArgumentException();
            }
        }
    }
}