using System.Collections.Generic;

namespace FireNamespace
{
    using CityNamespace = it.unibo.model.api.City;
    using FireNamespace = it.unibo.model.api.Fire;
    using PlayerNamespace = it.unibo.model.api.Player;
    using ResourceNamespace = it.unibo.model.api.Resource;

    /**
     * A class representing a Fire object that implements the Fire interface.
     */
    public class FireImpl : FireNamespace
    {
        public const int ARBITRARY_VALUE = 5;
        private const int MIN_COST = 50;
        public const int MIN_INTENSITY = 99;
        private CityNamespace city;
        PlayerNamespace player;
        private int citizen;
        private int cost;

        public FireImpl(CityNamespace city)
        {
            this.city = city;
            this.player = city.getPlayer();
        }

        /**
         * {@inheritDoc}
         */
        public void setCost()
        {
            this.citizen = city.getCitizens();
            int water = this.getNumResource(ResourceNamespace.WATER);
            int cost = calculateCost(citizen, water);
            this.cost = cost < MIN_COST ? MIN_COST : cost;
        }

        private int calculateCost(int citizen, int water)
        {
            return (citizen / 2) * (ARBITRARY_VALUE - water / 2) * ARBITRARY_VALUE;
        }

        /**
         * {@inheritDoc}
         */
        public int getCost()
        {
            return cost;
        }

        /**
         * {@inheritDoc}
         */
        public void spendGold()
        {
            System.Console.WriteLine("COSTO" + cost);
            System.Console.WriteLine("BEFORE" + player.getResource(ResourceNamespace.GOLD));
            player.spendResources(new Dictionary<ResourceNamespace, int>() { { ResourceNamespace.GOLD, cost } });
            System.Console.WriteLine("AFTER" + player.getResource(ResourceNamespace.GOLD));
        }

        private int getNumResource(ResourceNamespace resource)
        {
            return city.getPlayerResources().GetValueOrDefault(resource, 0);
        }

        private void destroyBuildings()
        {

            city.getBuildings().FindAll(building => !building.isUpgradable())
                .ForEach(building => city.demolish(building));
        }

        public void performFireAction()
        {
            this.setCost();
            this.spendGold();
            this.destroyBuildings();
        }
    }
}
