using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFAgenda.Models;
using XFAgenda.Services;
using XFAgenda.Views;

namespace XFAgenda.ViewModels
{
    class ContactListViewModel : BaseContactViewModel
    {
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteAllContactsCommand { get; private set; }

        public ContactListViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _contactRepository = new ContactRepository();

            AddCommand = new Command(async () => await ShowAddContact());
            DeleteAllContactsCommand = new Command(async () => await DeleteAllContacts());

            FetchContacts();
        }

        void FetchContacts()
        {
            ContactList = _contactRepository.GetAllContactsData();
        }

        async Task ShowAddContact()
        {
            await _navigation.PushAsync(new AddContact());
        }

        async Task DeleteAllContacts()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Lista de Contatos", "Excluir todos os contatos?", "OK", "Cancelar");
            if (isUserAccept)
            {
                _contactRepository.DeleteAllContacts();
                //await _navigation.PushAsync(new AddContact());
                FetchContacts();
            }
        }

        async void ShowContactDetails(int selectedContactID)
        {
            await _navigation.PushAsync(new DetailsPage(selectedContactID) { Title = _selectedContactItem.Name });
        }

        ContactInfo _selectedContactItem;
        public ContactInfo SelectedContactItem
        {
            get => _selectedContactItem;
            set
            {
                if (value != null)
                {
                    _selectedContactItem = value;
                    NotifyPropertyChanged("SelectedContactItem");
                    ShowContactDetails(value.Id);
                }
            }
        }
    }
}
