using Lexicon_Assignment4.Model;
using System;
using Xunit;

namespace Lexicon_Assignment4.Test
{
    public class TodoTests
    {
        [Fact]
        public void TodoIdWorks()
        {
            //Arrange
            int id = 1;
            string description = "First todo";

            //Act
            Todo todo = new Todo(id, description);

            //Assert
            Assert.Equal(id, todo.TodoId);
        }

        [Fact]
        public void DescriptionWorks()
        {
            //Arrange
            int id = 1;
            string description = "First todo";

            //Act
            Todo todo = new Todo(id, description);

            //Assert
            Assert.Equal(description, todo.Description);
        }

        [Fact]
        public void DoneWorks()
        {
            //Arrange
            int id = 1;
            string description = "First todo";
            bool done = true;

            //Act
            Todo todo = new Todo(id, description);
            todo.Done = done;

            //Assert
            Assert.Equal(done, todo.Done);
        }

        [Fact]
        public void DescriptionIsNull()
        {
            //Arrange
            int id = 1;
            string description = null;

            //Act
            ArgumentException result = Assert.Throws<ArgumentException>(
                () => new Todo(id, description));

            //Assert
            Assert.Equal("Empty or only whitespace is not allowed.", result.Message);
        }

        [Fact]
        public void DescriptionIsEmpty()
        {
            //Arrange
            int id = 1;
            string description = "";

            //Act
            ArgumentException result = Assert.Throws<ArgumentException>(
                () => new Todo(id, description));

            //Assert
            Assert.Equal("Empty or only whitespace is not allowed.", result.Message);
        }
    }


}
