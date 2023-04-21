using Xunit;

namespace Model 
{
    
    public class TestPlayer 
    {
        [Fact]
        public void TestCreation()
        {
            var p = new Player();
            Assert.NotNull(p);
            foreach (int r in p.Resources.Values) 
                Assert.Equal(0, r);
            var keys = p.Resources.Keys;
            var resources = Enum.GetValues(typeof(Resource));
            foreach (Resource r in resources)
                Assert.Contains(r, keys);
        }

        [Fact]
        public void TestAddingResources()
        {
            var p = new Player();
            var toAdd = new Dictionary<Resource, int>();
            toAdd.Add(Resource.Energy, 10);
            p.AddResources(toAdd);
            Assert.Equal(toAdd.GetValueOrDefault(Resource.Energy), p.GetResource(Resource.Energy));
        }
    }
}