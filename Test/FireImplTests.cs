using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FireNamespace.Tests
{
    [TestClass]
    public class FireImplTests
    {
        private CityStub cityStub;
        private PlayerStub playerStub;
        private FireImpl fire;

        [SetUp]
        public void Setup()
        {
            cityStub = new CityStub();
            playerStub = new PlayerStub();
            cityStub.Player = playerStub;
            fire = new FireImpl(cityStub);
        }

        [TestMethod]
        public void SetCost_WithFewCitizensAndWater_ReturnsMinimumCost()
        {
            // Arrange
            cityStub.Citizens = 2;
            playerStub.Resources[ResourceNamespace.WATER] = 1;

            // Act
            fire.setCost();

            // Assert
            Assert.AreEqual(FireImpl.MIN_COST, fire.getCost());
        }

        [Test]
        public void SpendGold_WithEnoughGold_RemovesGoldFromPlayer()
        {
            // Arrange
            playerStub.Resources[ResourceNamespace.GOLD] = 100;
            fire.setCost();

            // Act
            fire.spendGold();

            // Assert
            Assert.AreEqual(100 - fire.getCost(), playerStub.Resources[ResourceNamespace.GOLD]);
        }

        [Test]
        public void SpendGold_WithNotEnoughGold_ThrowsException()
        {
            // Arrange
            playerStub.Resources[ResourceNamespace.GOLD] = 10;
            fire.setCost();

            // Assert
            Assert.Throws<System.ArgumentException>(() => fire.spendGold());
        }

        [Test]
        public void DestroyBuildings_DemolishesAllNonUpgradableBuildings()
        {
            // Arrange
            BuildingStub b1 = new BuildingStub(true);
            BuildingStub b2 = new BuildingStub(false);
            BuildingStub b3 = new BuildingStub(false);
            cityStub.Buildings = new List<BuildingNamespace>() { b1, b2, b3 };

            // Act
            fire.destroyBuildings();

            // Assert
            Assert.AreEqual(1, cityStub.Buildings.Count);
            Assert.AreEqual(b1, cityStub.Buildings[0]);
            Assert.IsTrue(b1.Demolished);
            Assert.IsFalse(b2.Demolished);
            Assert.IsTrue(b3.Demolished);
        }

        [Test]
        public void DestroyBuildings_DemolishesAllBuildingsIfNoNonUpgradableBuildings()
        {
            // Arrange
            BuildingStub b1 = new BuildingStub(false);
            BuildingStub b2 = new BuildingStub(false);
            cityStub.Buildings = new List<BuildingNamespace>() { b1, b2 };

            // Act
            fire.destroyBuildings();

            // Assert
            Assert.AreEqual(0, cityStub.Buildings.Count);
            Assert.IsTrue(b1.Demolished);
            Assert.IsTrue(b2.Demolished);
        }
    }
}
        