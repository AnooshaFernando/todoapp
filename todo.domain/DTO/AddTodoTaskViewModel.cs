using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace todo.domain.DTO
{
    public class AddTodoTaskViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Due { get; set; }
    }
}
