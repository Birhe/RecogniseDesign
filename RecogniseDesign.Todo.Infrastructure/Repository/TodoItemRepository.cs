using Microsoft.EntityFrameworkCore;
using RecogniseDesign.Todo.Application;
using RecogniseDesign.Todo.Domain.Entities;
using RecogniseDesign.Todo.Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecogniseDesign.Todo.Infrastructure.Repository
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly TODOContext _context;
        public TodoItemRepository(TODOContext context)
        {
            _context = context;
        }

        public bool DeleteTodoitem(int id)
        {
            var todoitem =  _context.Todoitems.Where(s=>s.Id== id).FirstOrDefault();

            _context.Todoitems.Remove(todoitem);
            _context.SaveChangesAsync();

            return true;
        }

        public List<Todoitem> GetAllTodoItems()
        {
            if (_context.Todoitems == null)
            {
                return null;
            }
           return _context.Todoitems.ToList();
        }

        public Todoitem GetTodoitem(int id)
        {
           return _context.Todoitems.Where(s=>s.Id== id).FirstOrDefault();
        }

        public Todoitem PostTodoitem(Todoitem todoitem)
        {
            _context.Todoitems.Add(todoitem);
            _context.SaveChangesAsync();

            return todoitem;
        }
        private bool TodoitemExists(int id)
        {
            return (_context.Todoitems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public Todoitem PutTodoitem(int id, Todoitem todoitem)
        {
            if (!TodoitemExists(id))
            {
                return null;
            }
            _context.Entry(todoitem).State = EntityState.Modified;

            try
            {
                 _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoitemExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return todoitem;
        }
    }
}
