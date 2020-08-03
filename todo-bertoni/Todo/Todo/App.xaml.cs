using Todo.Context;
using Todo.Views;
using Xamarin.Forms;

namespace Todo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            new AppDbContext();

            MainPage = new TodoView();
        }
    }
}
