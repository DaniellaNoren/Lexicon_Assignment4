using Lexicon_Assignment4.Model;
using Lexicon_Assignment4.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon_Assignment4.Data
{
    /// <summary>
    /// Adds, finds and gets the size of Todo array 
    /// </summary>
    public class TodoItems
    {
        private static Todo[] items = new Todo[0];

        /// <summary>
        /// Returns the size of the Todo Array
        /// </summary>
        /// <returns>The size of the Todo Array</returns>
        public int Size()
        {
            return items.Length;
        }

        /// <summary>
        /// Finds all Todos
        /// </summary>
        /// <returns>All Todos</returns>
        public Todo[] FindAll()
        {
            return items;
        }

        /// <summary>
        /// Finds Todo in Array based on id
        /// </summary>
        /// <param name="todoId">The todoId for the Todo to find</param>
        /// /// <param name="assignee">The person to assignee a Todo item</param>
        /// <returns>Todo if id is matching, null if no match is found</returns>
        public Todo FindById(int todoId)
        {
            foreach (Todo item in items)
            {
                if (item.TodoId == todoId)
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// Adds a Todo item to Array
        /// </summary>
        /// <param name="description">Description of Todo item</param>
        /// /// <param name="assignee">The person to assignee a Todo item</param>
        /// <returns>Todo if id is matching, null if no match is found</returns>
        public Todo AddTodo(string description, bool done, Person assignee)
        {
            int todoId = TodoSequencer.NextTodoId();
            Todo todo;
            try
            {
                todo = new Todo(todoId, description);
            }
            catch (NullReferenceException)
            {
                return null;
            }
            todo.Done = done;
            todo.Assignee = assignee;
            Array.Resize(ref items, items.Length + 1);
            items[Size() - 1] = todo;
            return todo;
        }

        /// <summary>
        /// Clears the Todo Array
        /// </summary>
        public void Clear()
        {
            items = new Todo[0];
            TodoSequencer.Reset();
        }
    }
}
