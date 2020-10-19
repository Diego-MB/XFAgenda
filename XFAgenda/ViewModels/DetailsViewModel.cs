using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFAgenda.Models;
using XFAgenda.Services;

namespace XFAgenda.ViewModels
{
    class DetailsViewModel : BaseContactViewModel
    {
        public ICommand UpdateContactCommand { get; private set; }
        public ICommand DeleteContactCommand { get; private set; }

        public DetailsViewModel(INavigation navigation, int selectedContactID)
        {
            _navigation = navigation;
            //_contactValidator = new ContactValidator();
            _contact = new ContactInfo();
            _contact.Id = selectedContactID;
            _contactRepository = new ContactRepository();

            UpdateContactCommand = new Command(async () => await UpdateContact());
            DeleteContactCommand = new Command(async () => await DeleteContact());

            FetchContactDetails();
        }

        void FetchContactDetails()
        {
            _contact = _contactRepository.GetContactData(_contact.Id);            
        }

        async Task UpdateContact()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Detalhes do contato", "Deseja atualizar informações do contato", "OK", "Cancelar");
            if (isUserAccept)
            {
                _contactRepository.UpdateContact(_contact);
                await _navigation.PopAsync();
                
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Detalhes do contato", "Erro em atualizar contato", "Ok");
            }
        }

        async Task DeleteContact()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Detalhes do contato", "Deseja excluir o contato", "OK", "Cancelar");
            if (isUserAccept)
            {
                _contactRepository.DeleteContact(_contact.Id);
                await _navigation.PopAsync();
            }
        }
    }
}
