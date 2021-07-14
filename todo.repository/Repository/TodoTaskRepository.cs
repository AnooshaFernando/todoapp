using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todo.repository.Entity;
using todo.repository.Interface;

namespace todo.repository.Repository
{
    public class TodoTaskRepository: ITodoTaskRepository
    {
        private readonly TodoDBContext _dbcontext;

        public TodoTaskRepository(TodoDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<TodoTask>> GetCompleteTasks()
        {
            return await _dbcontext.TodoTask.Where(e => e.Completed == true).ToListAsync();
        }
        public async Task<IEnumerable<TodoTask>> GetIncompleteTasks()
        {
            return await _dbcontext.TodoTask.Where(e => e.Completed == false).ToListAsync();
        }
        public async Task<TodoTask> GetTask(int id)
        {
            return await _dbcontext.TodoTask.FindAsync(id);
        }
        public async Task<TodoTask> AddTask(TodoTask addTask)
        {
            _dbcontext.TodoTask.Add(addTask);
            await _dbcontext.SaveChangesAsync();
            return addTask;
        }
        public async Task<TodoTask> EditTask(TodoTask editTask)
        {
            _dbcontext.Entry(editTask).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return editTask;
        }
        public async Task<TodoTask> DeleteTask(int id)
        {
            var todoTask = await _dbcontext.TodoTask.FindAsync(id);
            if (todoTask == null)
            {
                return todoTask;
            }
            _dbcontext.TodoTask.Remove(todoTask);
            await _dbcontext.SaveChangesAsync();

            return todoTask;
        }
        public bool TaskExist(int id)
        {
            return _dbcontext.TodoTask.Any(e => e.Id == id);
        }
        public bool TaskDuplicate(string name)
        {
            return _dbcontext.TodoTask.Any(e => EF.Functions.Like(e.Name, name));
        }
        public bool TaskDuplicate(int id, string name)
        {
            return _dbcontext.TodoTask.Any(e => EF.Functions.Like(e.Name, name) && e.Id != id);
        }
    }
}
