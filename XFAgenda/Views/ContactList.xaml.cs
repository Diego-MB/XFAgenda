using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFAgenda.ViewModels;

namespace XFAgenda.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactList : ContentPage
    {
        public ContactList()
        {
            InitializeComponent();            
        }

        protected override void OnAppearing()
        {
            BindingContext = new ContactListViewModel(Navigation);
        }
    }
}