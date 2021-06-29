using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon_Assignment4.Data
{
    public class TodoSequencer
    {
        private static int todoId;

        static TodoSequencer()
        {
            todoId = 0;
        }

        public static int NextTodoId()
        {
            todoId++;
            return todoId;
        }

        public static void Reset()
        {
            todoId = 0;
        }
    }
}
