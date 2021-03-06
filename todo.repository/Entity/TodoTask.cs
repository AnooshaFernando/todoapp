using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace todo.repository.Entity
{
    public class TodoTask
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public DateTime? Due { get; set; }
        public bool Completed { get; set; } = false;
    }
}
