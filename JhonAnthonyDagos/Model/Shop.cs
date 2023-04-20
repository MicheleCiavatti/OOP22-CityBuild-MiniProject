//This class is the implementation of the interface Shop from the main project
using System.Collections.Generic;
using Interfaces;
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

        public Shop() {

        }
        public Shop(Controller controller) {
            _okButton = false;
            _noButton = false;
            _visibility = false;
            _controller = controller;

        }

/*
        public string generateResource() {
        } */

        public Controller getResource() {
            setResource();

            if(!isTransitionValid()) {
                System.Console.WriteLine("Transition is not valid");
                return _controller;
            }

            _controller.addResource(_resource);

            return _controller;
        }

        public string generateResource() {
            Random random = new Random();
            _randomAmount = random.Next(1, 10+1);
            _randomResource = random.Next(0,4);
            _randomPrice = random.Next(50+1) ;
            _text = "Vuoi comprare " + _randomAmount + " di " + _resourceStringList[_randomResource]  + " per " + _randomPrice + " Gold ?"; 
            System.Console.WriteLine(_text);
            return _text;
        }

        /*In this method i */
        public Dialog createDialogShop(Controller c){
            _controller = c;
            
            if(_resource.Count > 0) {
                _resource.Clear();
            }

            Dialog dialog = new Dialog("Shop");
            dialog.setText(generateResource());

            return dialog;
        }


        private void turnButtonFalse() {
            _okButton = false;
            _noButton = false;
        }

        private void setResource() {
            _resource.Add((Resource)_randomResource, _randomAmount);
            _costResource.Add(Resource.Gold, _randomPrice);
        }
        
        private Boolean isTransitionValid() {
            foreach(var key in _controller.getPlayerResource().Keys)
            {
                if(_controller.getPlayerResource()[key].Equals(_costResource[key])){
                    if(_costResource[key] > _controller.getPlayerResource()[key]){
                        return false;
                    }
                }
            }
            return true;
        }
    }

}