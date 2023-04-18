//This class is the implementation of the interface Shop from the main project
using Resource;
using System.Collections.Generic;

namespace ShopModel
{
    public class Shop
    {
        private readonly string[] _resourceStringList = new string[] {"Water", "Wood", "Energy", "Metal", "Citizen"};
        private string _text;
        private int _randomAmount;
        private Dictionary<Resource, int> _resource;
        private Dictionary<Resource, int> _costResource;

        //Using the auto-implemented properties
        public bool _okButton { get; set; }
        public bool _noButton { get; set; }
        public bool visibility { get; set;};

        public Shop() {
            this._okButton = false;
            this._noButton = false;
            this.visibility = false;

        }
        
    }

    public class useShop
    {
        static void Main(string[] args) {
            var s1 = new Shop()
            Console.WriteLine(s1._noButton);
        }
    }
}