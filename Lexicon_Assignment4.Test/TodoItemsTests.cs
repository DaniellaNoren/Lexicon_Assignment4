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
            Assert.True(items.Size() == 2);
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

        /// <summary>
        /// Checks that Todos with personId is returned
        /// </summary>
        [Fact]
        public void FindByAssignee_ShouldReturnTodoItemsWithPersonId()
        {
            // Arrange
            items.Clear();
            // Arrange
            string description1 = "My todo 1";
            bool done1 = false;
            string description2 = "My todo 2";
            bool done2 = false;
            string description3 = "My todo 3";
            bool done3 = true;
            string description4 = "My todo 4";
            bool done4 = true;
            Person person1 = CreatePerson();
            int personId = PersonSequencer.NextPersonId();
            string firstName = "Hulda";
            string lastName = "Larsson";
            Person person2 = new Person(personId, firstName, lastName);

            //Act
            items.Clear();
            items.AddTodo(description1, done1, person1);
            items.AddTodo(description2, done2, person1);
            items.AddTodo(description3, done3, person1);
            items.AddTodo(description4, done4, person2);
            Todo[] todos = items.FindByAssignee(person1.PersonId);

            //Assert
            Assert.True(todos.Length == 3);
        }

        /// <summary>
        /// Checks that Todos with assignee is returned
        /// </summary>
        [Fact]
        public void FindByAssignee_ShouldReturnTodoItemsWithAssignee()
        {
            // Arrange
            items.Clear();
            // Arrange
            string description1 = "My todo 1";
            bool done1 = false;
            string description2 = "My todo 2";
            bool done2 = false;
            string description3 = "My todo 3";
            bool done3 = true;
            string description4 = "My todo 4";
            bool done4 = true;
            Person person1 = CreatePerson();
            int personId = PersonSequencer.NextPersonId();
            string firstName = "Hulda";
            string lastName = "Larsson";
            Person person2 = new Person(personId, firstName, lastName);

            //Act
            items.Clear();
            items.AddTodo(description1, done1, person1);
            items.AddTodo(description2, done2, person1);
            items.AddTodo(description3, done3, person1);
            items.AddTodo(description4, done4, person2);
            Todo[] todos = items.FindByAssignee(person1);

            //Assert
            Assert.True(todos.Length == 3);
        }

        /// <summary>
        /// Checks that Todos with assignee is returned
        /// </summary>
        [Fact]
        public void FindByAssignee_ShouldReturnUnAssignedTodoItems()
        {
            // Arrange
            items.Clear();
            // Arrange
            string description1 = "My todo 1";
            bool done1 = false;
            string description2 = "My todo 2";
            bool done2 = false;
            string description3 = "My todo 3";
            bool done3 = true;
            string description4 = "My todo 4";
            bool done4 = true;
            Person person1 = CreatePerson();

            //Act
            items.Clear();
            items.AddTodo(description1, done1, person1);
            items.AddTodo(description2, done2, person1);
            items.AddTodo(description3, done3, person1);
            items.AddTodo(description4, done4, null);
            Todo[] todos = items.FindUnAssignedTodoITems();

            //Assert
            Assert.True(todos.Length == 1);
        }

        /// <summary>
        /// Checks that Todos with doneStatus true is returned
        /// </summary>
        [Fact]
        public void FindByDoneStatus_ShouldReturnTodoItemsWithDoneStatusTrue()
        {
            // Arrange
            items.Clear();
            // Arrange
            string description1 = "My todo 1";
            bool done1 = false;
            string description2 = "My todo 2";
            bool done2 = false;
            string description3 = "My todo 3";
            bool done3 = true;
            Person person = CreatePerson();

            //Act
            items.Clear();
            items.AddTodo(description1, done1, person);
            items.AddTodo(description2, done2, person);
            items.AddTodo(description3, done3, person);
            Todo[] todos = items.FindByDoneStatus(false);

            //Assert
            Assert.Equal(2, todos.Length);
        }
    }
}
