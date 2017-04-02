using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoXamarinWindows.Model;
using Xamarin.Forms;

namespace ToDoXamarinWindows
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Database.TodoItems = new List<TodoItem>();
            MainPage = new ToDoXamarinWindows.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
