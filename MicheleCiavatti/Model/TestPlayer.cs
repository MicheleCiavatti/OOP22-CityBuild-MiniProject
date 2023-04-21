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
                Assert.True(keys.Contains(r));
        }
    }
}