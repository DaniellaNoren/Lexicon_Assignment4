using System;

namespace Lexicon_Assignment4.Model
{/// <summary>
/// Class representing a Person
/// </summary>
    public class Person
    {
        public int PersonId { get { return personId; } }

        private readonly int personId;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                CheckNullOrEmptyString(value);
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                CheckNullOrEmptyString(value);
                lastName = value;
            }
        }

        private string firstName;
        private string lastName;

        public Person(int personId, string firstName, string lastName)
        {
            this.personId = personId;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        /// <summary>
        /// Takes in a string, throws exception if it is either Null or Empty. 
        /// </summary>
        /// <param name="str">String to be checked</param>
        /// <exception cref="System.NullReferenceException">Thrown if string is null or empty</exception>
        public void CheckNullOrEmptyString(string str)   
        {
            if (string.IsNullOrEmpty(str.Trim()))
                throw new NullReferenceException();
        }
    }
}
