using CodeSamples.CustomTypes;
using System;
using System.Dynamic;

namespace CodeSamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var item1 = new ExpandoDictionary()
            {
                { "333", "333" },
                { "123", 123 },
                { "111", 123 },
                { "aboolean", true },
            };
            _ = item1["asdf"];
            _ = item1.AsExpandoObject();
        }
    }
}
