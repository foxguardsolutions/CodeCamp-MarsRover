using NUnit.Framework;
using Ploeh.AutoFixture;

namespace MarsRover.Tests
{
    [TestFixture]
    public class Tests
    {
        protected Fixture Fixture { get; set; }

        [SetUp]
        public void SetUp()
        {
            Fixture = new Fixture();
        }
    }
}
