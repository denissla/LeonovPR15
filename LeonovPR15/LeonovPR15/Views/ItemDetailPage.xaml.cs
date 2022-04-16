using LeonovPR15.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace LeonovPR15.Views
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