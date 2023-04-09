using System.Collections.Generic;
namespace Model 
{
    ///This class is a translation of PlayerImpl in the main project
    public class Player {

        public Dictionary<Resource, int> Resources { get; }

        public Player() {
            Resources = new Dictionary<Resource, int>();
            foreach (Resource res in Enum.GetValues(typeof(Resource))) 
            {
                Resources.Add(res, 0);
            }
        }

        public int GetResource(Resource r) => Resources.GetValueOrDefault(r, 0);

        public bool SpendResources(Dictionary<Resource, int> toSpend)
        {
            var input = new Dictionary<Resource, int>(toSpend);
            Normalize(input, false);
            if (CheckResourcesToSpend(input))
            {
                SetResources(input, toSpend.Count() == 1 && toSpend.ContainsKey(Resource.Citizen));
                return true;
            }
            return false;
        }

        private void Normalize(Dictionary<Resource, int> map, bool positive)
        {
            foreach (Resource res in map.Keys)
            {
                map[res] = Math.Abs(map[res]) * (positive ? 1 : -1);
            }
        }

        public void AddResources(Dictionary<Resource, int> toAdd)
        {
            Dictionary<Resource, int> input = new Dictionary<Resource, int>(toAdd);
            Normalize(input, true);
            SetResources(input, true);
        }

        private bool CheckResourcesToSpend(Dictionary<Resource, int> toSpend)
        {
            bool output = true;
            foreach (Resource res in toSpend.Keys)
            {
                if (Resources[res] + toSpend[res] < 0)
                {
                    output = false;
                }
            }
            return output;
        }

        private void SetResources(Dictionary<Resource, int> map, bool addCitizens)
        {
            if (!addCitizens)
            {
                map.Remove(Resource.Citizen);
            }
            foreach (Resource res in map.Keys)
            {
                Resources[res] += map[res];
            }
        }

        public static void Main() {
            Resource r = Resource.Water;
            Player p = new Player();
            Console.WriteLine(r.getSimpleBuilding());
            var copy = p.Resources;
            var input = new Dictionary<Resource, int>(copy);
            copy.Remove(Resource.Water);
            foreach (var i in input) 
            {
                Console.WriteLine(i);
            }
        }
    }
}
