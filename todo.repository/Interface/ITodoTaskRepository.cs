using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using todo.repository.Entity;

namespace todo.repository.Interface
{
    public interface ITodoTaskRepository
    {
        Task<IEnumerable<TodoTask>> GetCompleteTasks();
        Task<IEnumerable<TodoTask>> GetIncompleteTasks();
        Task<TodoTask> GetTask(int id);
        Task<TodoTask> AddTask(TodoTask addTask);
        Task<TodoTask> EditTask(TodoTask editTask);
        Task<TodoTask> DeleteTask(int id);
        bool TaskExist(int id);
        bool TaskDuplicate(string name);
        bool TaskDuplicate(int id, string name);
    }
}
