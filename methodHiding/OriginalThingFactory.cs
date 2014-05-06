namespace methodHiding
{
    public class OriginalThingFactory : IThingFactory
    {
        public OriginalThing GetThing()
        {
            return new OriginalThing();
        }
    }
}