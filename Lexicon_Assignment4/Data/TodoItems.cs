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
        private static Todo[] todos = new Todo[0];

        /// <summary>
        /// Returns the size of the Todo Array
        /// </summary>
        /// <returns>The size of the Todo Array</returns>
        public int Size()
        {
            return todos.Length;
        }

        /// <summary>
        /// Finds all Todos
        /// </summary>
        /// <returns>All Todos</returns>
        public Todo[] FindAll()
        {
            return todos;
        }

        /// <summary>
        /// Finds Todo in Array based on id
        /// </summary>
        /// <param name="todoId">The todoId for the Todo to find</param>
        /// <returns>Todo if id is matching, null if no match is found</returns>
        public Todo FindById(int todoId)
        {
            foreach (Todo item in todos)
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
            Todo[] items = new Todo[0];
            int index = 0;
            for (int i= 0; i < todos.Length; i++)
            {
                if (todos[i].Done == doneStatus)
                {
                    Array.Resize(ref items, index + 1);
                    items[index] = todos[i];
                    index++;
                }
            }
            return items;
        }

        /// <summary>
        /// Finds Todo in Array based on assignee
        /// </summary>
        /// <param name="personId">The Todos with the personId to return</param>
        /// <returns>Array of todos, or an empty array if no match</returns>
        public Todo[] FindByAssignee(int personId)
        {
            Todo[] items = new Todo[0];
            int index = 0;
            for (int i = 0; i < todos.Length; i++)
            {
                if (todos[i].Assignee.PersonId == personId)
                {
                    Array.Resize(ref items, index + 1);
                    items[index] = todos[i];
                    index++;
                }
            }
            return items;
        }

        /// <summary>
        /// Finds Todo in Array based on assignee
        /// </summary>
        /// <param name="person">The Todos with the person to return</param>
        /// <returns>Array of todos, or an empty array if no match</returns>
        public Todo[] FindByAssignee(Person person)
        {
            Todo[] items = new Todo[0];
            int index = 0;
            for (int i = 0; i < todos.Length; i++)
            {
                if (todos[i].Assignee.PersonId == person.PersonId)
                {
                    Array.Resize(ref items, index + 1);
                    items[index] = todos[i];
                    index++;
                }
            }
            return items;
        }

        /// <summary>
        /// Finds Todo in Array based on assignee
        /// </summary>
        /// <returns>Array of todos, or an empty array if no match</returns>
        public Todo[] FindUnAssignedTodoITems()
        {
            Todo[] items = new Todo[0];
            int index = 0;
            for (int i = 0; i < todos.Length; i++)
            {
                if (todos[i].Assignee == null)
                {
                    Array.Resize(ref items, index + 1);
                    items[index] = todos[i];
                    index++;
                }
            }
            return items;
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
            Array.Resize(ref todos, todos.Length + 1);
            todos[Size() - 1] = todo;
            return todo;
        }

        /// <summary>
        /// Clears the Todo Array
        /// </summary>
        public void Clear()
        {
            todos = new Todo[0];
            TodoSequencer.Reset();
        }

        /// <summary>
        /// Finds todoitem based on todoId and removes it from the array. If todoitem not found, nothing is changed.
        /// </summary>
        /// <param name="todoId">Id of TodoItem</param>
        public void RemoveTodo(int todoId)
        {
            Todo todo = FindById(todoId);

            if (todo == null)
                return;

            int index = Array.IndexOf(todos, todo);

            RemoveIndex(index);
        }

        /// <summary>
        /// Makes a new array, copies all values from old array excluding index sent in.
        /// </summary>
        /// <param name="index">Index to be excluded</param>
        private void RemoveIndex(int index)
        {
            Todo[] newTodos = new Todo[Size() - 1];
            Array.Copy(todos, newTodos, length: index);
            Array.ConstrainedCopy(todos, index + 1, newTodos, index, Size() - index - 1);

            todos = newTodos;
        }
    }
}
