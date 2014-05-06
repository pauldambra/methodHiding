namespace methodHiding
{
    using System;
    using System.Collections.Generic;

    public class OriginalThing
    {
        public void DoesThing(List<string> stuff)
        {
            var s = "Original Thing";
            Console.WriteLine(s);
            stuff.Add(s);
        }
    }
}