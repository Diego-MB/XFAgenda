using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFAgenda.Services;
using XFAgenda.Views;

namespace XFAgenda
{
    public partial class App : Application
    {
        IContactRepository _contactRepository;
        public App()
        {
            InitializeComponent();

              
            _contactRepository = new ContactRepository();
            OnAppStart();
        }

        public void OnAppStart()
        {
            var getLocalDB = _contactRepository.GetAllContactsData();

            //if (getLocalDB.Count > 0)
            //{
                MainPage = new NavigationPage(new ContactList());
            //}
            //else
            //{
            //    MainPage = new NavigationPage(new AddContact());
            //}

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
