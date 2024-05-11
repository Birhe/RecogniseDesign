using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecogniseDesign.Todo.Domain.Entities
{
    public partial class Todoitem
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Note { get; set; } = null!;
    }
}
