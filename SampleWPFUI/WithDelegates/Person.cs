using System;
using System.Collections.Generic;
using System.Text;

namespace SampleWPFUI
{
    public delegate string PersonFormatter(Person persion);

    public delegate TResult Func<in T, out TResult>(T input);
    // Func are delegates that return some value
    // Compare this with the above delegate

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Func<Person, string> personFromatterFunction;

        public string ToString(PersonFormatter formatter)
        {
            // formatter delegate - 1. Accepts a person object, 2. Returns a string 
            return formatter(this);
        }

        // The parameter here is not a custom defined delegate as previous
        // Inbuilt Func<> are used
        //      - framwework provides 16 overloaded Func
        //      - last type is always the return
        //      - anything before that are the parameters
        public string ToString(Func<Person, string> formatter)
        {
            // formatter delegate - 1. Accepts a person object, 2. Returns a string 
            return formatter(this);
        }
    }
}
