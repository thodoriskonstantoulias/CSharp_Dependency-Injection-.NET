using PeopleViewer.Presentation;
using PersonDataReader.CSV;
using PersonDataReader.Decorators;
using PersonDataReader.Service;
using System.Windows;

namespace PeopleViewer
{
    public partial class App : Application
    {
        //Dependency injection : Similar to Startup for web apps. Instantiation of classes here
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ComposeObjects();
            Application.Current.MainWindow.Title = "With Dependency Injection";
            Application.Current.MainWindow.Show();
        }

        private static void ComposeObjects() 
        {
            //With dependency injection we can switch to another service easily
            //var reader = new ServiceReader();
            //var reader = new CSVReader();

            //Adding cache functionality with dependency injection
            var wrappedReader = new ServiceReader();
            var reader = new CachingReader(wrappedReader);
            var viewModel = new PeopleViewModel(reader);
            Application.Current.MainWindow = new PeopleViewerWindow(viewModel);
        }
    }
}

