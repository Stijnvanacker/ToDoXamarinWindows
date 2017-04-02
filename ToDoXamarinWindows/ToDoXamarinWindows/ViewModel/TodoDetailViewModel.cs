using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoXamarinWindows.Message;
using ToDoXamarinWindows.Model;
using ToDoXamarinWindows.Views;

namespace ToDoXamarinWindows.ViewModel
{
    public class TodoDetailViewModel : ViewModelBase
    {
        private string name;
        private string body;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged();
            }
        }

        public string Body
        {
            get { return body; }
            set
            {
                body = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }


        public TodoDetailViewModel()
        {
            InstantiateCommands();
        }

        private void InstantiateCommands()
        {
            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);
        }

        private void Cancel()
        {
            Messenger.Default.Send<NavigationMessage>(new NavigationMessage { View = new TodoListView() });
        }

        private void Save()
        {
            //Try to find the item first by name (we don't have an id :)
            var todoItem = Database.TodoItems.FirstOrDefault(t => t.Name == this.Name);
            if (todoItem == null)
            {
                todoItem = new TodoItem { Name = this.Name, Body = this.Body };
                Database.TodoItems.Add(todoItem);
            }
            else
            {
                todoItem.Body = this.body;
            }
            //Save it first :)
            Messenger.Default.Send<NavigationMessage>(new NavigationMessage { View = new TodoListView() });
        }
    }
}
