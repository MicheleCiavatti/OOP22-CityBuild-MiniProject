using Xunit;

public class TestSetCost
{
    [Fact]
    public void TestSetCostCalculatesCorrectly()
    {
        // Arrange
        City city = new City();
        Player player = new Player();
        player.AddResource(ResourceNamespace.WATER, 10);

        // Act
        player.setCost();

        // Assert
        Assert.True(player.cost = 50);
    }

    [Fact]
    public void TestSpendGoldSubtractsCorrectAmount()
    {
        // Arrange
        Player player = new Player();
        //player.AddResource(ResourceNamespace.GOLD, 100); default
        int expectedGold = player.getResource(ResourceNamespace.GOLD) - 50;

        // Act
        player.setCost(); // cost = 50
        player.spendGold();

        // Assert
        Assert.Equal(expectedGold, player.getResource(ResourceNamespace.GOLD));
    }

    [Fact]
    public void TestDestroyBuildingsDemolishesNonUpgradableBuildings()
    {
        // Arrange
        City city = new City();
        Building b1 = new Building("Factory", false);
        Building b2 = new Building("School", true);
        Building b3 = new Building("Hospital", false);
        city.addBuilding(b1);
        city.addBuilding(b2);
        city.addBuilding(b3);

        // Act
        city.destroyBuildings();

        // Assert
        List<Building> remainingBuildings = city.getBuildings();
        Assert.DoesNotContain(b1, remainingBuildings);
        Assert.Contains(b2, remainingBuildings);
        Assert.DoesNotContain(b3, remainingBuildings);
    }
}
