using RecogniseDesign.Todo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecogniseDesign.Todo.Application
{
    public interface ITodoItemRepository
    {
         List<Todoitem> GetAllTodoItems();
         Todoitem GetTodoitem(int id);
        Todoitem PutTodoitem(int id, Todoitem todoitem);
        Todoitem PostTodoitem(Todoitem todoitem);
        bool DeleteTodoitem(int id);
    }
}
