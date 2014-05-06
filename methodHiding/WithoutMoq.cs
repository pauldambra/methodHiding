using System.Collections.Generic;
using System.Linq;

namespace methodHiding
{
    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture]
    public class WithoutMoqTests
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
        public void FakeThing_DoesThing()
        {
            var strings = new List<string>();

            new FakeThing().DoesThing(strings);

            strings.Should().NotBeEmpty();
            strings.Should().HaveCount(1);
            strings.ElementAt(0).Should().Contain("Fake");
        }

        [Test]
        public void ProvidedOriginalThing_DoesThing()
        {
            var strings = new List<string>();
            var factory = new OriginalThingFactory();
            var originalThing = factory.GetThing();

            originalThing.Should().BeOfType<OriginalThing>();

            originalThing.DoesThing(strings);
            strings.Should().NotBeEmpty();
            strings.Should().HaveCount(1);
            strings.ElementAt(0).Should().Contain("Original");
        }

        [Test]
        public void ProvidedFakeThing_DoesThing()
        {
            var strings = new List<string>();
            var factory = new FakeThingFactory();
            var fakeThing = factory.GetThing();

            fakeThing.Should().BeOfType<FakeThing>();

            fakeThing.DoesThing(strings);

            strings.Should().NotBeEmpty();
            strings.Should().HaveCount(1);
            strings.ElementAt(0).Should().Contain("Fake");
        }
    }

}
