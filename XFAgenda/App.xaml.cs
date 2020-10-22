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
            MainPage = new NavigationPage(new ContactList()) {
                //Definindo cor do background e texto
                BarBackgroundColor = Color.Black,
                BarTextColor = Color.White
                
                };
            //}
            //else
            //{
            //    MainPage = new NavigationPage(new AddContact());
            //}
            //((NavigationPage)Application.Current.MainPage).BackgroundColor = Color.FromHex("#000000");
            //((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;


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
