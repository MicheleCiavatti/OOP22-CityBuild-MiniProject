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
        }
    }
}