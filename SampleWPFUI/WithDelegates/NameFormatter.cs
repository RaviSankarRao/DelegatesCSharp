using System;
using System.Collections.Generic;
using System.Text;

namespace SampleWPFUI
{
    public static class NameFormatter
    {
        public static string Default(Person person)
        {
            return $"{person.FirstName} {person.LastName}";
        }

        public static string LastNameFirst(Person person)
        {
            return $"{person.LastName} {person.FirstName}";
        }

        public static string FirstNameOnly(Person person)
        {
            return person.FirstName;
        }

        public static string LastNameOnly(Person person)
        {
            return person.LastName;
        }
    }
}
