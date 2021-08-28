using MyShopping.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MyShopping.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}