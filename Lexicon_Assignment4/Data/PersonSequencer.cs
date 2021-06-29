using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon_Assignment4.Data
{
    public class PersonSequencer
    {
        private static int personId;

        /// <summary>
        /// Increases and returns next Person Id
        /// </summary>
        /// <returns>Person id</returns>
        public static int NextPersonId()
        {
            personId = personId + 1;
            return personId;
        }

        /// <summary>
        /// Resets personId back to 0
        /// </summary>
        public static void Reset()
        {
            personId = 0;
        }
    }
}
