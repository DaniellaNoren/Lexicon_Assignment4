using Lexicon_Assignment4.Data;
using Xunit;

namespace Lexicon_Assignment4.Test
{

    public class TodoSequencerTests
    {
        [Fact]
        public void IdCounterWorks()
        {
            // Arrange
            TodoSequencer.reset();

            //Act
            int before = TodoSequencer.nextTodoId();
            int result = TodoSequencer.nextTodoId();

            //Assert
            Assert.True(before < result);
        }

        [Fact]
        public void ResetWorks()
        {
            // Arrange
            TodoSequencer.reset();

            //Act
            int before = TodoSequencer.nextTodoId();
            TodoSequencer.reset();
            int result = TodoSequencer.nextTodoId();

            //Assert
            Assert.True(before == result);
        }
    }
}
