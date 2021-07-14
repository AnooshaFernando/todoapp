using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using todo.domain.DTO;
using todo.domain.Interface;
using todo.repository.Entity;
using todo.repository.Interface;

namespace todo.domain.Service
{
    public class TodoTaskHandler : ITodoTaskHandler
    {
        private readonly ITodoTaskRepository _todoTaskRepository;
        private readonly IMapper _mapper;

        public TodoTaskHandler(ITodoTaskRepository todoTaskRepository, IMapper mapper)
        {
            this._todoTaskRepository = todoTaskRepository;
            this._mapper = mapper;
        }

        public async Task<TodoTaskViewModel> Add(AddTodoTaskViewModel addTodoTaskViewModel)
        {
            TodoTask addTodoTask;
            if (this._todoTaskRepository.TaskDuplicate(addTodoTaskViewModel.Name))
            {
                throw new ArgumentException("Task name already used");
            }
            try
            {
                addTodoTask = _mapper.Map<TodoTask>(addTodoTaskViewModel);
                addTodoTask.Created = DateTime.Now;
                return _mapper.Map<TodoTaskViewModel>(await this._todoTaskRepository.AddTask(addTodoTask));
            }
            catch (AutoMapperMappingException autoMapperException)
            {
                throw autoMapperException.InnerException;
            }
        }

        public async Task<TodoTaskViewModel> Edit(int id, EditTodoTaskViewModel editTodoTaskViewModel)
        {
            TodoTask editTodoTask;
            if (!this._todoTaskRepository.TaskExist(id))
            {
                throw new ArgumentException("Task not found");
            }
            if (this._todoTaskRepository.TaskDuplicate(id, editTodoTaskViewModel.Name))
            {
                throw new ArgumentException("Task name already used");
            }
            try
            {
                editTodoTask = _mapper.Map<TodoTask>(editTodoTaskViewModel);
                editTodoTask.Id = id;
                return _mapper.Map<TodoTaskViewModel>(await _todoTaskRepository.EditTask(editTodoTask));
            }
            catch (AutoMapperMappingException autoMapperException)
            {
                throw autoMapperException.InnerException;
            }
        }

        public async Task<TodoTaskViewModel> ToggleComplete(int id)
        {
            TodoTask CompleteTodoTask;
            try
            {
                CompleteTodoTask = await _todoTaskRepository.GetTask(id);
                CompleteTodoTask.Completed = !CompleteTodoTask.Completed;
                return _mapper.Map<TodoTaskViewModel>(await _todoTaskRepository.EditTask(CompleteTodoTask));
            }
            catch (AutoMapperMappingException autoMapperException)
            {
                throw autoMapperException.InnerException;
            }
        }

        public async Task<TodoTaskViewModel> Delete(int id)
        {
            var result = await _todoTaskRepository.DeleteTask(id);
            if (result == null)
            {
                throw new ArgumentException("Task not found");
            }
            return _mapper.Map<TodoTaskViewModel>(result);
        }

        public async Task<IEnumerable<TodoTaskViewModel>> GetComplete()
        {
            return this._mapper.Map<List<TodoTaskViewModel>>(await this._todoTaskRepository.GetCompleteTasks());
        }

        public async Task<IEnumerable<TodoTaskViewModel>> GetIncomplete()
        {
            return this._mapper.Map<List<TodoTaskViewModel>>(await this._todoTaskRepository.GetIncompleteTasks());
        }
    }
}
