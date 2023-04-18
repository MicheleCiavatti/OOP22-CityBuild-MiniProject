public class FireImpl{
    public void setCost() { 
        this.citizen = city.getCitizens(); 
        int water = this.getNumResource(Resource.WATER); 
        int cost = calculateCost(citizen, water);
        this.cost = cost < MIN_COST ? MIN_COST : cost; 
    }

    public void spendGold() {
        player.spendResources(Map.of(Resource.GOLD, cost));
    }

    public void performFireAction() { 
        this.setCost(); 
        this.spendGold();
        this.destroyBuildings(); 
    }

    public int getCost() { return cost; }
}