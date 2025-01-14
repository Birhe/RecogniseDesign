﻿using System;
using System.Collections.Generic;

namespace RecogniseDesign.Todo.Infrastructure.DataContext
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
