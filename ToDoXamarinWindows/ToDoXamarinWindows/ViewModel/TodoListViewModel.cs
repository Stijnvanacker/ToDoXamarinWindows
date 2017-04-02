using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using ToDoXamarinWindows.Model;
using GalaSoft.MvvmLight.Command;
using ToDoXamarinWindows.Message;
using ToDoXamarinWindows.Views;

namespace ToDoXamarinWindows.ViewModel
{
    public class TodoListViewModel : ViewModelBase
    {
        private IList<TodoItem> todoItems;

        public IList<TodoItem> TodoItems
        {
            get { return todoItems; }
            set
            {
                todoItems = value;
                RaisePropertyChanged();
            }
        }

        private TodoItem selectedTodoItem;

        public TodoItem SelectedTodoItem
        {
            get { return selectedTodoItem; }
            set
            {
                selectedTodoItem = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand CreateTodoCommand { get; private set; }
        public RelayCommand EditTodoCommand { get; private set; }

        public TodoListViewModel()
        {
            TodoItems = Database.TodoItems;
            InstantiateCommands();
        }

        private void InstantiateCommands()
        {
            CreateTodoCommand = new RelayCommand(CreateTodo);
            EditTodoCommand = new RelayCommand(EditTodo);
        }

        private void CreateTodo()
        {
            //var todoDetailModel = new TodoDetailViewModel();
            Messenger.Default.Send<NavigationMessage>(new NavigationMessage { View = new TodoDetailView() });
        }

        public void EditTodo()
        {
            var todoDetailViewModel = new TodoDetailViewModel { Name = SelectedTodoItem.Name, Body = SelectedTodoItem.Body };
            Messenger.Default.Send<NavigationMessage>(new NavigationMessage { View = new TodoDetailView { BindingContext = todoDetailViewModel } });
        }

    }
}
