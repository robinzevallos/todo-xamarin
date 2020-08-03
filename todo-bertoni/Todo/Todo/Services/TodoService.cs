using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Todo.Context;
using Todo.Models;

namespace Todo.Services
{
    public class TodoService
    {
        public IEnumerable<TodoModel> GetTodos()
        {
            using (var db = new AppDbContext())
            {
                return db.Todos.ToList();
            }
        }

        public TodoModel Add(TodoModel model)
        {
            using (var db = new AppDbContext())
            {
                db.Add(model);
                db.SaveChanges();

                return db.Todos.Last();
            };
        } 

        public TodoModel Update(TodoModel model)
        {
            using (var db = new AppDbContext())
            {
                db.Update(model);
                db.SaveChanges();

                return db.Todos.Find(model.Id);
            };
        }
    }
}
