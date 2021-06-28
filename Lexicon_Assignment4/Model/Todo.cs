using System;

namespace Lexicon_Assignment4.Model
{
    public class Todo
    {
        private int todoId;
        private string description;
        private bool done;
        //private Person assignee;

        public int TodoId { get { return todoId; } private set { todoId = value; } }
        public string Description
        {
            get { return description; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Empty or only whitespace is not allowed.");
                }
                description = value;
            }
        }
        public bool Done { get { return done; } set { done = value; } }
        public Todo(int todoId, string description)
        {
            TodoId = todoId;
            Description = description;
        }
    }
}
