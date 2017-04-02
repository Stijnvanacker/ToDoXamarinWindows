using GalaSoft.MvvmLight;
using ToDoXamarinWindows.Views;
using Xamarin.Forms;
using GalaSoft.MvvmLight.Messaging;
using ToDoXamarinWindows.Message;

namespace ToDoXamarinWindows.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ContentView currentView;
        public ContentView CurrentView
        {
            get
            {
                return currentView;
            }
            set
            {
                currentView = value;
                RaisePropertyChanged();
            }
        }

        public MainViewModel()
        {
            CurrentView = new TodoListView();
            InitializeMessenger();
        }

        private void InitializeMessenger()
        {
            Messenger.Default.Register<NavigationMessage>(this, NavigateToViewModel);
        }

        private void NavigateToViewModel(NavigationMessage message)
        {
            CurrentView = message.View;
        }
    }
}