using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using todo.domain.DTO;

namespace todo.domain.Interface
{
    public interface ITodoTaskHandler
    {
        Task<IEnumerable<TodoTaskViewModel>> GetComplete();
        Task<IEnumerable<TodoTaskViewModel>> GetIncomplete();
        Task<TodoTaskViewModel> Add(AddTodoTaskViewModel addTodoTaskViewModel);
        Task<TodoTaskViewModel> Edit(int id, EditTodoTaskViewModel editTodoTaskViewModel);
        Task<TodoTaskViewModel> Delete(int id);
        Task<TodoTaskViewModel> ToggleComplete(int id);
    }
}
