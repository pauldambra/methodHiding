namespace methodHiding
{
    public class FakeThingFactory : IThingFactory
    {
        public OriginalThing GetThing()
        {
            return new FakeThing();
        }
    }
}