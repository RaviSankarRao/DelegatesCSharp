using System;
using System.Collections.Generic;
using System.Text;

namespace SampleWPFUI.WithouDelegates
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }

        public string ToString(FormatType format)
        {
            switch (format)
            {
                case FormatType.Default:
                    return this.ToString();

                case FormatType.LastNameFirst:
                    return $"{this.LastName} {this.FirstName}";

                case FormatType.LastNameOnly:
                    return this.LastName;

                case FormatType.FirstNameOnly:
                    return this.FirstName;

                case FormatType.InitialsOnly:
                    return $"{this.FirstName[0]} {this.LastName[0]}";
            }

            return default;
        }
    }
}
