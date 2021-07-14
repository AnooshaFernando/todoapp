using System;
using System.Collections.Generic;
using System.Text;
using todo.domain.DTO;
using todo.repository.Entity;

namespace todo.domain.Utilites
{
    public class MappingProfiles : AutoMapper.Profile
    {
        public MappingProfiles()
        {
            CreateMap<TodoTask, TodoTaskViewModel>();
            CreateMap<TodoTaskViewModel, TodoTask>();
            CreateMap<AddTodoTaskViewModel, TodoTask>();
            CreateMap<EditTodoTaskViewModel, TodoTask>();
        }
    }
}
