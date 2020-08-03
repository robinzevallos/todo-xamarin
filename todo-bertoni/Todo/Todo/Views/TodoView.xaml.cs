using Todo.ViewModels;
using Xamarin.Forms;

namespace Todo.Views
{
    public partial class TodoView : ContentPage
    {
        public TodoView()
        {
            InitializeComponent();

            BindingContext = new TodoViewModel();
        }
    }
}