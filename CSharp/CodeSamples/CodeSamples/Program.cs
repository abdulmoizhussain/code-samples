using CodeSamples.CustomCollections;
using System;
using System.Dynamic;

namespace CodeSamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // initializing it with its simple empty constructor.
            var e1 = new ExpandoDictionary
            {
                { "str1", "strv1" },
                { "int1", 123 },
                { "int2", 456 },
                { "float1", (float)2.34567 },
                { "boolean1", true },
            };

            // get a property which exists
            float float1 = (float)e1["float1"];

            // trying to get a property, as boxed value, which does not exist.
            bool success1 = e1.TryGetValue("float2", out object _);

            // trying to get a property, with its type, which does not exist.
            bool success2 = e1.TryGetValue<float>("float2", out float _);

            // update a property, which exists
            e1["float1"] = 45.908;
            e1["str1"] = "strv1..strv1";

            // in the end, when we finally need it as an ExpandoObject.
            ExpandoObject result = e1.AsExpandoObject();

            // initializing it with its constructor which request an ExpandoObject.
            // you will need this constructor when you receive an ExpandoObject from somewhere else.
            var e2 = new ExpandoDictionary(result);
        }
    }
}
