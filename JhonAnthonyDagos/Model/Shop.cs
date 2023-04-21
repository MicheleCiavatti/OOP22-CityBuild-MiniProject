//This class is the implementation of the interface Shop from the main project
using System.Collections.Generic;
using MyNameSpace;
using System;

namespace ShopModel
{

    public class Shop
    {
        private string[] _resourceStringList = {"Water", "Wood", "Energy", "Metal", "Citizen"};
        private string _text = new String("");
        private int _randomAmount;
        private int _randomResource;
        private int _randomPrice;
        private Dictionary<Resource, int> _resource = new Dictionary<Resource, int>();
        private Dictionary<Resource, int> _costResource = new Dictionary<Resource, int>();

        //Using the auto-implemented properties to add variables
        public bool _okButton { get; private set; }
        public bool _noButton { get; private set; }
        public bool _visibility { get; set; }

        private Controller _controller = new Controller();

        public Shop()
        {

        }
        public Shop(Controller controller)
        {
            _controller = controller;

        }

        //This method is used to return the player resource to the Controller which manages all the resource information of the player
        public Controller getResource()
        {
            setResource();

            if(!isTransitionValid())
            {
                System.Console.WriteLine("Transition is not valid");
                return _controller;
            }

            _controller.addResource(_resource);
            _controller.spendResource(_costResource);

            return _controller;
        }

        //This method is used to generate a random resource
        public string generateResource()
        {
            Random random = new Random();
            _randomAmount = random.Next(1, 10+1);
            _randomResource = random.Next(0,4);
            _randomPrice = random.Next(50+1) ;
            _text = "Vuoi comprare " + _randomAmount + " di " + _resourceStringList[_randomResource]  + " per " + _randomPrice + " Gold ?"; 

            return _text;
        }

        /*This method is used to regenerate the shop when is called by other classes*/
        public void regenerateShop(Controller c)
        {
            _controller = c;
            
            //Checks if the resource is not empty, in case it is not empty it will clear itself
            if(_resource.Count > 0) {
                _resource.Clear();
            }

            System.Console.WriteLine("Shop Menu");
            System.Console.WriteLine(generateResource());
        }


        private void turnButtonFalse()
        {
            _okButton = false;
            _noButton = false;
            System.Console.WriteLine("Ok button: " + _okButton);
            System.Console.WriteLine("No button: " + _noButton);
        }

        //This method is used to add the resource generated to a field
        private void setResource()
        {
            _resource.Add((Resource)_randomResource, _randomAmount);
            _costResource.Add(Resource.Gold, _randomPrice);
            System.Console.WriteLine("Resource added to the field");
        }
        
        //This method is used to check wether the transition is valid or not
        //It checks the resource of the player, in case if has sufficient amount of gold then it will return true
        private Boolean isTransitionValid()
        {
            System.Console.WriteLine("Check if the transition is valid");
            foreach(var key in _controller.getPlayerResource().Keys)
            {
                if(_controller.getPlayerResource()[key].Equals(_costResource[key]))
                {
                    if(_costResource[key] > _controller.getPlayerResource()[key])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }

}