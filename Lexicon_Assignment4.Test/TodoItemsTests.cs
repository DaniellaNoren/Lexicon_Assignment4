using Lexicon_Assignment4.Model;
using Lexicon_Assignment4.Data;
using System;
using Xunit;

namespace Lexicon_Assignment4.Test
{
    public class TodoItemsTests
    {
        private readonly TodoItems items = new TodoItems();

        private Person CreatePerson()
        {
            int personId = PersonSequencer.NextPersonId();
            string firstName = "Sven";
            string lastName = "Persson";
            return new Person(personId, firstName, lastName);
        }

        /// <summary>
        /// Checks that correct Size of Array is returned
        /// </summary>
        [Fact]
        public void Size_ShouldReturnLengthOfArray()
        {
            // Arrange
            string description = "My todo";
            bool done = false;
            Person person = CreatePerson();

            //Act
            int before = items.Size();
            items.AddTodo(description, done, person);
            int result = items.Size();

            //Assert
            Assert.Equal(before, result - 1);
        }

        /// <summary>
        /// Checks that TodoItems contains all items
        /// </summary>
        [Fact]
        public void FindAll_ShouldContainAllTodoItems()
        {
            // Arrange
            string description1 = "My todo 1";
            bool done1 = false;
            string description2 = "My todo 2";
            bool done2 = false;
            Person person = CreatePerson();

            //Act
            items.Clear();
            items.AddTodo(description1, done1, person);
            items.AddTodo(description2, done2, person);

            //Assert
            Assert.Equal(2, items.Size());
        }

        [Fact]
        /// <summary>
        /// Checks that correct TodoItem is returned
        /// </summary>
        public void FindById_ShouldReturnTodoItemToFind()
        {
            // Arrange
            items.Clear();
            // Arrange
            string description1 = "My todo 1";
            bool done1 = false;
            string description2 = "My todo 2";
            bool done2 = false;
            Person person = CreatePerson();

            //Act
            items.Clear();
            items.AddTodo(description1, done1, person);
            Todo todo = items.AddTodo(description2, done2, person);

            //Assert
            Assert.Equal(todo.TodoId, items.FindById(todo.TodoId).TodoId);
        }

        /// <summary>
        /// Checks that null is returned when id not contained in array is passed in
        /// </summary>
        [Fact]
        public void FindById_ShouldReturnNull()
        {
            // Arrange
            int id = 1;
            
            //Act
            items.Clear();

            //Assert
            Assert.Null(items.FindById(id));
        }

        /// <summary>
        /// Checks that TodoItem is added to Array
        /// </summary>
        [Fact]
        public void AddTodo_ShouldBeAdded()
        {
            // Arrange
            items.Clear();
            // Arrange
            string description1 = "My todo 1";
            bool done1 = false;
            string description2 = "My todo 2";
            bool done2 = false;
            Person person = CreatePerson();

            //Act
            items.Clear();
            items.AddTodo(description1, done1, person);
            Todo todo = items.AddTodo(description2, done2, person);

            //Assert
            Assert.Equal(todo.TodoId, items.FindById(todo.TodoId).TodoId);
        }


        /// <summary>
        /// Checks that Array is cleared
        /// </summary>
        [Fact]
        public void Clear_ShouldBeClearedForTodoItems()
        {
            // Arrange
            string description = "My todo";
            bool done = false;
            Person person = CreatePerson();

            //Act
            items.Clear();
            int before = items.Size();
            items.AddTodo(description, done, person);
            items.Clear();
            int result = items.Size();

            //Assert
            Assert.Equal(result, before);
        }
    }
}
