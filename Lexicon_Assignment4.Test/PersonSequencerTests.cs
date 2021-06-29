using Lexicon_Assignment4.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lexicon_Assignment4.Test
{/// <summary>
/// Tests for PersonSequencer. Implements IDisposable to execute code after each test in Dispose()
/// </summary>
    public class PersonSequencerTests : IDisposable
    {

        /// <summary>
        /// Runs before each test
        /// </summary>
        public PersonSequencerTests()
        {
            PersonSequencer.Reset();
        }

        /// <summary>
        /// Checks that the next person id is larger than the previous
        /// </summary>
        [Fact]
        public void Increment_ShouldIncrementPersonId()
        {
            int id1 = PersonSequencer.NextPersonId();
            int id2 = PersonSequencer.NextPersonId();
            Assert.True(id1 < id2);

            id1 = PersonSequencer.NextPersonId();
            id2 = PersonSequencer.NextPersonId();
            Assert.True(id1 < id2);
        }

        /// <summary>
        /// Checks that Reset method works. After reset, id should come back smaller.
        /// </summary>
        [Fact]
        public void Reset_ShouldResetPersonId()
        {
            PersonSequencer.NextPersonId();
            int id = PersonSequencer.NextPersonId();
            PersonSequencer.Reset();
            Assert.True(PersonSequencer.NextPersonId() < id);
        }

        /// <summary>
        /// Runs after each test. Resets person id
        /// </summary>
        public void Dispose()
        {
            PersonSequencer.Reset();
        }
    }
}
