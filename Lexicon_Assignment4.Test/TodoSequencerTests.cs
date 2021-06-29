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
            TodoSequencer.Reset();

            //Act
            int before = TodoSequencer.NextTodoId();
            int result = TodoSequencer.NextTodoId();

            //Assert
            Assert.True(before < result);
        }

        [Fact]
        public void ResetWorks()
        {
            // Arrange
            TodoSequencer.Reset();

            //Act
            int before = TodoSequencer.NextTodoId();
            TodoSequencer.Reset();
            int result = TodoSequencer.NextTodoId();

            //Assert
            Assert.True(before == result);
        }
    }
}
