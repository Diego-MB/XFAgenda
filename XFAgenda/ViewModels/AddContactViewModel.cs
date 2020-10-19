using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFAgenda.Models;
using XFAgenda.Services;
using XFAgenda.ViewModels;
using XFAgenda.Views;

namespace XFAgenda
{
    class AddContactViewModel : BaseContactViewModel
    {
        public ICommand AddContactCommand { get; private set; }

        public AddContactViewModel(INavigation navigation)
        {
            _navigation = navigation;
            //_contactValidator = new ContactValidator();
            _contact = new ContactInfo();
            _contactRepository = new ContactRepository();

            AddContactCommand = new Command(async () => await AddContact());
        }

        async Task AddContact()
        {
            
           bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Novo Contato", "Deseja salvar o novo contato?", "OK", "Cancelar");
           if (isUserAccept)
            {
                _contactRepository.InsertContact(_contact);
                await _navigation.PopAsync();
                
           }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Novo Contato", "O contato não foi salvo!", "Ok");
            }
        }

        async Task ShowContactList()
        {
            await _navigation.PushAsync(new ContactList());
        }

        public bool IsViewAll => _contactRepository.GetAllContactsData().Count > 0 ? true : false;
    }
}
