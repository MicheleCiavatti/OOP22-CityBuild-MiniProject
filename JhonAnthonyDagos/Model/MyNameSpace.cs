/** This namespace is used to implement the Controller's model 
*/
namespace Controller
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
            // This method adds the values from resource2 to the corresponding values in resource1, if the same key is present in both dictionaries
            foreach (var key in resource.Keys)
            {
                if (resources.ContainsKey(key))
                {
                    resources[key] += resource[key];
                }
            }

            // This method adds all the key-value pairs from resource2 to resource1 that are not already present in resource1
            foreach (var entry in resource)
            {
                if (!resources.ContainsKey(entry.Key))
                {
                    resources.Add(entry.Key, entry.Value);
                }
            }
        }

        //The method subtracts the specified quantities of resources from the resources dictionary of the player, if they exist
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


