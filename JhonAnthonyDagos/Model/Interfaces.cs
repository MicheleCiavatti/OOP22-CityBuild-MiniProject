/** This namespace is used to 
*/

using System.Windows.Forms;

namespace Interfaces
{

    public enum Resource{
        Water = 0, Wood = 1, Energy = 2, Metal = 3, Citizen = 4, Gold = 5
    }

    public class Dialog {
        private string name;
        public string text {get; set;}
        public Dialog(){
            text = new String("");
            this.name = "New";
        }
        public Dialog(string name) {
            text = new String("");
            this.name = name;
        }

        public void setText(String text){
            this.text = text;
        }
    }

    public class Controller
    {
        private Dictionary<Resource, int> resources = new Dictionary<Resource, int>();

        public Controller(){
            resources.Add(Resource.Gold, 50);
        }

        public void addResource(Dictionary<Resource, int> resource){
            // Aggiunge i valori di resource2 ai valori corrispondenti di resource1, se la stessa chiave è presente in entrambi i dizionari
            foreach (var key in resource.Keys)
            {
                if (resource.ContainsKey(key))
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

        public Dictionary<Resource, int> getPlayerResource(){
            return resources;
        }

    }



    public class Player{
        public void addResources() {
            System.Console.WriteLine("Added Resources");
        }
    }

}


