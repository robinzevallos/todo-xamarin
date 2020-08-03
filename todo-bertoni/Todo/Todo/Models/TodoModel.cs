using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Models
{
    public class TodoModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public TodoStatus Status { get; set; }
    }
}
