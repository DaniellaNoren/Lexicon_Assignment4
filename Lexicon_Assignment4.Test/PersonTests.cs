using Lexicon_Assignment4.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lexicon_Assignment4.Test
{
    public class PersonTests
    {

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
