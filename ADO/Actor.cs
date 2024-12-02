using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
    public class Actor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Actor(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;    
        }
        public string FullName => $"{FirstName} {LastName}";
    }
}
