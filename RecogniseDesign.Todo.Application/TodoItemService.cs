using RecogniseDesign.Todo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecogniseDesign.Todo.Application
{
    public class TodoItemService : ITodoItemService
    {
        ITodoItemRepository _repository;
        public TodoItemService(ITodoItemRepository todoItemRepository)
        {
            _repository = todoItemRepository;
        }

        public bool DeleteTodoitem(int id)
        {
            return _repository.DeleteTodoitem(id);
        }

        public List<Todoitem> GetAllTodoItems()
        {
           return _repository.GetAllTodoItems();
        }

        public Todoitem GetTodoitem(int id)
        {
            return _repository.GetTodoitem(id);
        }

        public Todoitem PostTodoitem(Todoitem todoitem)
        {
            return _repository.PostTodoitem(todoitem);
        }

        public Todoitem PutTodoitem(int id, Todoitem todoitem)
        {
           return _repository.PutTodoitem(id,todoitem);
        }
    }
}
