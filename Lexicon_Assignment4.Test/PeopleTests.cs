using Lexicon_Assignment4.Data;
using Lexicon_Assignment4.Model;
using Xunit;

namespace Lexicon_Assignment4.Test
{
    public class PeopleTests 
    {
        private readonly People people = new People();
      
        [Fact]
        public void Clear_ShouldEmptyArray()
        {
            people.CreatePerson("Johan", "Eriksson");
            people.Clear();
            Assert.Equal(0, people.Size());
        }


        [Fact]
        public void CreatePerson_ShouldSavePerson()
        {
            string firstName = "Göran";
            string lastName = "Persson";
            Person person = people.CreatePerson(firstName, lastName);
            Person foundPerson = people.FindById(person.PersonId);

            Assert.NotNull(foundPerson);
            Assert.Equal(person.FirstName, foundPerson.FirstName);
            Assert.Equal(person.LastName, foundPerson.LastName);
        }

        [Fact]
        public void CreatePerson_ShouldIncreseSize()
        {
            int originalSize = people.Size();
            people.CreatePerson("Berit", "Beritsson");
            int newSize = people.Size();
            
            Assert.True(originalSize < newSize);
        }

        [Fact]
        public void CreatePerson_ShouldGenerateId()
        {
            Person person = people.CreatePerson("FirstName", "LastName");
            Assert.True(person.PersonId > 0);

        }

        [Theory]
        [InlineData("", "")]
        [InlineData("", "lastName")]
        [InlineData("firstName", "")]
        [InlineData("firstName", null)]
        [InlineData("firstName", " ")]
        [InlineData(null, null)]
        public void CreatePerson_ShouldReturnNullIfBadInput(string firstName, string lastName)
        {
            Assert.Null(people.CreatePerson(firstName, lastName));
        }

        [Fact]
        public void FindById_ShouldReturnCorrectPerson()
        {
            Person person = people.CreatePerson("Jan", "Jansson");
            Person foundPerson = people.FindById(person.PersonId);
            Assert.NotNull(foundPerson);
            Assert.Equal(person.FirstName, foundPerson.FirstName);
            Assert.Equal(person, foundPerson);
        }

        [Fact]
        public void FindById_ShouldReturnNullIfIncorrectId()
        {
            Assert.Null(people.FindById(250));
        }

        /// <summary>
        /// Checks that correct Array is returned
        /// </summary>
        [Fact]
        public void FindAll()
        {
            people.Clear();
            Assert.True(0 == people.FindAll().Length);

            people.CreatePerson("Paul", "Hollywood");
            people.CreatePerson("Mary", "Berry");

            Assert.True(2 == people.FindAll().Length);
        }

        /// <summary>
        /// Checks that array shrinks in size after removal
        /// </summary>
        [Fact]
        public void RemovePerson_ShouldShrinkArray()
        {
            InsertPeople();
            Person person = people.CreatePerson("Terry", "Timber");

            int originalSize = people.Size();
            people.RemovePerson(person.PersonId);
            int newSize = people.Size();

            Assert.True(originalSize > newSize);
           
        }

      
        /// <summary>
        /// Checks that Array does not change if Person cannot be found
        /// </summary>
        [Fact]
        public void RemovePerson_ShouldNotRemoveIfPersonNotFound()
        {
            int originalSize = people.Size();
            people.RemovePerson(250);
            int newSize = people.Size();
            Assert.True(originalSize == newSize);
        }

        /// <summary>
        /// Checks that correct person is removed
        /// </summary>
        [Fact]
        public void RemovePerson_ShouldRemoveCorrectPerson()
        {
            Person person = people.CreatePerson("Birgit", "Nilsson");
            InsertPeople();
         
            people.RemovePerson(person.PersonId);
       
            Assert.Null(people.FindById(person.PersonId));
        }

        public void InsertPeople()
        {
            people.CreatePerson("Alice", "Corn");
            people.CreatePerson("Kenny", "Roger");
        }


    }
}
