using System.Collections.Generic;
using System.Linq;

namespace methodHiding
{
    using FluentAssertions;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class WithMoqTests
    {
        [Test]
        public void OriginalThing_DoesThing()
        {
            var strings = new List<string>();
            new OriginalThing().DoesThing(strings);
            strings.Should().NotBeEmpty();
            strings.Should().HaveCount(1);
            strings.ElementAt(0).Should().Contain("Original");
        }

        [Test]
        public void ProvidedOriginalThing_DoesThing()
        {
            var strings = new List<string>();
            var thingServer = new Mock<IThingFactory>();
            thingServer.Setup(ts => ts.GetThing()).Returns(new OriginalThing());
            thingServer.Object.GetThing().DoesThing(strings);
            strings.Should().NotBeEmpty();
            strings.Should().HaveCount(1);
            strings.ElementAt(0).Should().Contain("Original");
        }

        [Test]
        public void FakeThing_DoesThing()
        {
            var strings = new List<string>();

            new FakeThing().DoesThing(strings);
            
            strings.Should().NotBeEmpty();
            strings.Should().HaveCount(1);
            strings.ElementAt(0).Should().Contain("Fake");
        }

        [Test]
        public void ProvidedFakeThing_DoesThing()
        {
            var strings = new List<string>();
            var thingServer = new Mock<IThingFactory>();
            thingServer.Setup(ts => ts.GetThing()).Returns(new FakeThing());

            var fakeThing = thingServer.Object.GetThing();
            fakeThing.DoesThing(strings);

            strings.Should().NotBeEmpty();
            strings.Should().HaveCount(1);
            strings.ElementAt(0).Should().Contain("Fake");
        }
    }

}
