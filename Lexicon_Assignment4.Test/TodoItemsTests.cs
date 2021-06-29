using Lexicon_Assignment4.Model;
using Lexicon_Assignment4.Data;
using System;
using Xunit;

namespace Lexicon_Assignment4.Test
{
    public class TodoItemsTests
    {
        private readonly TodoItems todos = new TodoItems();

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
            int before = todos.Size();
            todos.AddTodo(description, done, person);
            int result = todos.Size();

            //Assert
            Assert.Equal(before, result - 1);
        }

        /// <summary>
        /// Checks that TodoItems contains all todos
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
            todos.Clear();
            todos.AddTodo(description1, done1, person);
            todos.AddTodo(description2, done2, person);

            //Assert
            Assert.True(todos.Size() == 2);
        }

        [Fact]
        /// <summary>
        /// Checks that correct TodoItem is returned
        /// </summary>
        public void FindById_ShouldReturnTodoItemToFind()
        {
            // Arrange
            todos.Clear();
            // Arrange
            string description1 = "My todo 1";
            bool done1 = false;
            string description2 = "My todo 2";
            bool done2 = false;
            Person person = CreatePerson();

            //Act
            todos.Clear();
            todos.AddTodo(description1, done1, person);
            Todo todo = todos.AddTodo(description2, done2, person);

            //Assert
            Assert.Equal(todo.TodoId, todos.FindById(todo.TodoId).TodoId);
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
            todos.Clear();

            //Assert
            Assert.Null(todos.FindById(id));
        }

        /// <summary>
        /// Checks that TodoItem is added to Array
        /// </summary>
        [Fact]
        public void AddTodo_ShouldBeAdded()
        {
            // Arrange
            todos.Clear();
            // Arrange
            string description1 = "My todo 1";
            bool done1 = false;
            string description2 = "My todo 2";
            bool done2 = false;
            Person person = CreatePerson();

            //Act
            todos.Clear();
            todos.AddTodo(description1, done1, person);
            Todo todo = todos.AddTodo(description2, done2, person);

            //Assert
            Assert.Equal(todo.TodoId, todos.FindById(todo.TodoId).TodoId);
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
            todos.Clear();
            int before = todos.Size();
            todos.AddTodo(description, done, person);
            todos.Clear();
            int result = todos.Size();

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
            todos.Clear();
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
            todos.Clear();
            todos.AddTodo(description1, done1, person1);
            todos.AddTodo(description2, done2, person1);
            todos.AddTodo(description3, done3, person1);
            todos.AddTodo(description4, done4, person2);
            Todo[] items = todos.FindByAssignee(person1.PersonId);

            //Assert
            Assert.True(items.Length == 3);
        }

        /// <summary>
        /// Checks that Todos with assignee is returned
        /// </summary>
        [Fact]
        public void FindByAssignee_ShouldReturnTodoItemsWithAssignee()
        {
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
            todos.Clear();
            todos.AddTodo(description1, done1, person1);
            todos.AddTodo(description2, done2, person1);
            todos.AddTodo(description3, done3, person1);
            todos.AddTodo(description4, done4, person2);
            Todo[] items = todos.FindByAssignee(person1);

            //Assert
            Assert.True(items.Length == 3);
        }

        /// <summary>
        /// Checks that Todos with assignee is returned
        /// </summary>
        [Fact]
        public void FindByAssignee_ShouldReturnUnAssignedTodoItems()
        {
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
            todos.Clear();
            todos.AddTodo(description1, done1, person1);
            todos.AddTodo(description2, done2, person1);
            todos.AddTodo(description3, done3, person1);
            todos.AddTodo(description4, done4, null);
            Todo[] items = todos.FindUnAssignedTodoITems();

            //Assert
            Assert.True(items.Length == 1);
        }

        /// <summary>
        /// Checks that Todos with doneStatus true is returned
        /// </summary>
        [Fact]
        public void FindByDoneStatus_ShouldReturnTodoItemsWithDoneStatusTrue()
        {
            // Arrange
            string description1 = "My todo 1";
            bool done1 = false;
            string description2 = "My todo 2";
            bool done2 = false;
            string description3 = "My todo 3";
            bool done3 = true;
            Person person = CreatePerson();

            //Act
            todos.Clear();
            todos.AddTodo(description1, done1, person);
            todos.AddTodo(description2, done2, person);
            todos.AddTodo(description3, done3, person);
            Todo[] items = todos.FindByDoneStatus(false);

            //Assert
            Assert.True(items.Length == 2);
        }

        /// <summary>
        /// Checks that a Todo is removed
        /// </summary>
        [Fact]
        public void RemoveTodo_ShouldReturnArrayWithoutRemovedTodo()
        {
            // Arrange
            string description1 = "My todo 1";
            bool done1 = false;
            string description2 = "My todo 2";
            bool done2 = false;
            string description3 = "My todo 3";
            bool done3 = true;
            Person person = CreatePerson();

            //Act
            todos.Clear();
            todos.AddTodo(description1, done1, person);
            Todo todo = todos.AddTodo(description2, done2, person);
            todos.AddTodo(description3, done3, person);
            int before = todos.Size();
            todos.RemoveTodo(todo.TodoId);
            int result = todos.Size();

            //Assert
            Assert.Equal(result, before - 1);
        }

        /// <summary>
        /// Checks that Todos with doneStatus true is returned
        /// </summary>
        [Fact]
        public void RemoveTodo_ShouldReturnUnchangedArray()
        {
            // Arrange
            string description1 = "My todo 1";
            bool done1 = false;
            string description2 = "My todo 2";
            bool done2 = false;
            string description3 = "My todo 3";
            bool done3 = true;
            Person person = CreatePerson();
            int removedId = 99;

            //Act
            todos.Clear();
            todos.AddTodo(description1, done1, person);
            Todo todo = todos.AddTodo(description2, done2, person);
            todos.AddTodo(description3, done3, person);
            int before = todos.Size();
            todos.RemoveTodo(removedId);
            int result = todos.Size();

            //Assert
            Assert.Equal(result, before);
        }
    }
}
