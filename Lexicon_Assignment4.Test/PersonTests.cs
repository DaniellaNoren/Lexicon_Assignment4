using Lexicon_Assignment4.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lexicon_Assignment4.Test
{
    public class PersonTests
    {
        /// <summary>
        /// Checks that exception is thrown when trying to send in empty or null string to Person-class.
        /// </summary>
        /// <param name="firstName">First name of Person</param>
        /// <param name="lastName">Last name of person</param>
        [Theory]
        [InlineData("firstname", "")]
        [InlineData("firstname", " ")]
        [InlineData("", "lastName")]
        [InlineData(" ", "lastName")]
        [InlineData("firstname", null)]
        [InlineData(null, null)]
        public void CreatePerson_ShouldThrowException(string firstName, string lastName)
        {
            Assert.Throws<NullReferenceException>(() => new Person(1, firstName, lastName));
        }

        /// <summary>
        /// Checks that Person-object is correctly created
        /// </summary>
        /// <param name="id">Id of person</param>
        /// <param name="firstName">First name of person</param>
        /// <param name="lastName">Last name of person</param>
        [Theory]
        [InlineData(1, "Anna", "Johansson")]
        [InlineData(3, "Peter", "Grönwall")]
        [InlineData(15, "Berit", "Björk")]
        public void CreatePerson(int id, string firstName, string lastName)
        {
            Person person = new Person(id, firstName, lastName);
            Assert.Equal(id, person.PersonId);
            Assert.Equal(firstName, person.FirstName);
            Assert.Equal(lastName, person.LastName);

        }


    }
}
