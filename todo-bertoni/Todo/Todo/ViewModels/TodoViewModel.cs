using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Todo.Models;
using Todo.Services;
using Xamarin.Forms;

namespace Todo.ViewModels
{
    public class TodoViewModel : BaseViewModel
    {
        public static TodoViewModel Instance { get; set; }

        readonly TodoService service = new TodoService();

        ObservableCollection<TodoItem> _todos;
        public ObservableCollection<TodoItem> Todos
        {
            get => _todos;
            set => SetProperty(ref _todos, value);
        }

        string _newTodo;
        public string NewTodo 
        {
            get => _newTodo; 
            set => SetProperty(ref _newTodo, value); 
        }

        TodoItem _currentItem;
        public TodoItem CurrentItem
        {
            get => _currentItem;
            set => SetProperty(ref _currentItem, value);
        }

        public ICommand AddCommand => new Command(Add);

        public TodoViewModel()
        {
            Instance = this;

            var todoItems = service.GetTodos()
                 .Where(_ => _.Status != TodoStatus.Removed)
                .Select(_ => new TodoItem
                {
                    Model = _,
                    IsCompleted = _.Status != TodoStatus.Completed                   
                });

            Todos = new ObservableCollection<TodoItem>(todoItems);
        }

        void Add()
        {
            var model = new TodoModel { Description = NewTodo };

            var newModel = service.Add(model);

            var item = new TodoItem
            {
                Model = newModel
            };

            Todos.Add(item);
        }

        public void Remove(TodoItem item)
        {
            item.IsCompleted = false;

            var updateModel = new TodoModel
            {
                Id = item.Model.Id,
                Description = item.Model.Description,
                Status = TodoStatus.Removed
            };

            service.Update(updateModel);

            Todos.Remove(item);
        }

        public void Complete(TodoItem item)
        {
            item.IsCompleted = false;

            var updateModel = new TodoModel
            {
                Id = item.Model.Id,
                Description = item.Model.Description,
                Status = TodoStatus.Completed
            };

            service.Update(updateModel);
        }
    }

    public class TodoItem : BaseViewModel
    {
        //public TodoModel Model { get; set; }

        TodoModel _model;
        public TodoModel Model
        {
            get => _model;
            set => SetProperty(ref _model, value);
        }

        bool _isCompleted = true;
        public bool IsCompleted
        {
            get => _isCompleted;
            set => SetProperty(ref _isCompleted, value);
        }

        public ICommand RemoveCommand =>
            new Command(() => TodoViewModel.Instance.Remove(this));

        public ICommand CompleteCommand =>
            new Command(() => TodoViewModel.Instance.Complete(this));
    }
}
