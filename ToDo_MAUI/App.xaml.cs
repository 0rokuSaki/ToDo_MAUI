﻿namespace ToDo_MAUI
{
    public partial class App : Application
    {
        public App(Views.MainView view)
        {
            InitializeComponent();

            MainPage = new NavigationPage(view);
        }
    }
}
