/** This namespace is used to 
*/

namespace MyNameSpace
{



    public enum Resource{
        Water = 0, Wood = 1, Energy = 2, Metal = 3, Citizen = 4, Gold = 5
    }
    public class Controller
    {
        private Dictionary<Resource, int> resources = new Dictionary<Resource, int>();

        public Controller(){
            resources.Add(Resource.Gold, 50);
        }


        public void addResource(Dictionary<Resource, int> resource){
            System.Console.WriteLine("Setting resource of the player");
            // Aggiunge i valori di resource2 ai valori corrispondenti di resource1, se la stessa chiave è presente in entrambi i dizionari
            foreach (var key in resource.Keys)
            {
                if (resources.ContainsKey(key))
                {
                    resources[key] += resource[key];
                }
            }

            // Aggiunge tutte le coppie chiave-valore di resource2 a resource1 che non sono già presenti in resource1
            foreach (var entry in resource)
            {
                if (!resources.ContainsKey(entry.Key))
                {
                    resources.Add(entry.Key, entry.Value);
                }
            }
        }

        public void spendResource(Dictionary<Resource,int> r)
        {
            foreach(KeyValuePair<Resource,int> entry in r) 
            {
                if(resources.ContainsKey(entry.Key))
                {
                    resources[entry.Key] -= entry.Value;
                }
            }
        }

        public Dictionary<Resource, int> getPlayerResource(){
            return resources;
        }

        
        public void printResource()
        {
            foreach(Resource key in resources.Keys)
            {
                System.Console.WriteLine("Key: {0}, Value: {1}",key,resources[key]);
                
            }
        }

    }

}


