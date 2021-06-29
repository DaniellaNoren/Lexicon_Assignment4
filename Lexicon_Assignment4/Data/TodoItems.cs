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
        /// <param name="assignee">The person to assignee a Todo item</param>
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
        /// Finds Todo in Array based on doneStatus
        /// </summary>
        /// <param name="doneStatus">The Todos with the doneStatus to return</param>
        /// <returns>Array of todos, or an empty array if no match</returns>
        public Todo[] FindByDoneStatus(bool doneStatus)
        {
            Todo[] todos = new Todo[0];
            int index = 0;
            for (int i= 0; i < items.Length; i++)
            {
                if (items[i].Done == doneStatus)
                {
                    Array.Resize(ref todos, index + 1);
                    todos[index] = items[i];
                    index++;
                }
            }
            return todos;
        }

        /// <summary>
        /// Finds Todo in Array based on assignee
        /// </summary>
        /// <param name="personId">The Todos with the personId to return</param>
        /// <returns>Array of todos, or an empty array if no match</returns>
        public Todo[] FindByAssignee(int personId)
        {
            Todo[] todos = new Todo[0];
            int index = 0;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Assignee.PersonId == personId)
                {
                    Array.Resize(ref todos, index + 1);
                    todos[index] = items[i];
                    index++;
                }
            }
            return todos;
        }

        /// <summary>
        /// Finds Todo in Array based on assignee
        /// </summary>
        /// <param name="person">The Todos with the person to return</param>
        /// <returns>Array of todos, or an empty array if no match</returns>
        public Todo[] FindByAssignee(Person person)
        {
            Todo[] todos = new Todo[0];
            int index = 0;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Assignee.PersonId == person.PersonId)
                {
                    Array.Resize(ref todos, index + 1);
                    todos[index] = items[i];
                    index++;
                }
            }
            return todos;
        }

        /// <summary>
        /// Finds Todo in Array based on assignee
        /// </summary>
        /// <param name="person">The Todos with the person to return</param>
        /// <returns>Array of todos, or an empty array if no match</returns>
        public Todo[] FindUnAssignedTodoITems()
        {
            Todo[] todos = new Todo[0];
            int index = 0;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Assignee == null)
                {
                    Array.Resize(ref todos, index + 1);
                    todos[index] = items[i];
                    index++;
                }
            }
            return todos;
        }

        /// <summary>
        /// Adds a Todo item to Array
        /// </summary>
        /// <param name="description">Description of Todo item</param>
        /// <param name="assignee">The person to assignee a Todo item</param>
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
