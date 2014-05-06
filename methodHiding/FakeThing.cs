namespace methodHiding
{
    using System;
    using System.Collections.Generic;

    class FakeThing : OriginalThing
    {
        public void DoesThing(List<string> stuff)
        {
            var s = "Fake Thing";
            Console.WriteLine(s);
            stuff.Add(s);
        }
    }
}