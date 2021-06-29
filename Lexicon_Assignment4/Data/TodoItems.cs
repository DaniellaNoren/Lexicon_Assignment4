using Lexicon_Assignment4.Model;
using Lexicon_Assignment4.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon_Assignment4.Data
{
    public class TodoItems
    {
        private static Todo[] items = new Todo[0];

        public int Size()
        {
            return items.Length;
        }

        public Todo[] FindAll()
        {
            return items;
        }

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

        public Todo AddTodo(string description, bool done, Person assignee)
        {
            int todoId = TodoSequencer.nextTodoId();
            Todo todo = new Todo(todoId, description);
            todo.Done = done;
            todo.Assignee = assignee;
            Array.Resize(ref items, items.Length + 1);
            items[Size() - 1] = todo;
            return todo;
        }

        public void Clear()
        {
            items = new Todo[0];
        }
    }
}
