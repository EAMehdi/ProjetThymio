using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThymioWPFApplication.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        /// <summary>
        /// Current View Model
        /// </summary>
        private BaseViewModel currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
                OnPropertyChanged("CurrentViewModel");
                //OnPropertyRaised(nameof(CurrentViewModel));
            }
        }


        /// <summary>
        /// Methode abonné à l'evenement de la classe messenger
        /// Lorsque celui est déclencher par messageStatus recoit l'action source du déclenchement
        /// En fonction de cette action l'on peut instancier un nouveau ViewModel pour notre currentViewModel
        /// Cela va donc notifier le changement du currentviewModel à la vues bindé sur le contentPresenter
        /// Grace à notre DataTemplate en fonction du ViewModel celui ci va afficher le bon UserControle
        /// L'on peut aussi rediriger des objet lors de la création du nouveau viewmodel et ainsi faire transiter des informations 
        /// </summary>
        /// <param name="messenger_action"></param>
        /// <param name="obj"></param>
        private void listeningMessenger(EnumMessengerAction messenger_action, Object obj)
        {
            //Debug.WriteLine("Notification Command");
            if (messenger_action.Equals(EnumMessengerAction.GO_PROG_HOME))
            {
                CurrentViewModel = new ProgPageViewModel();
            }
            else if (messenger_action.Equals(EnumMessengerAction.GO_HOME))
            {
                CurrentViewModel = new HomeViewModel();
            }
            else if (messenger_action.Equals(EnumMessengerAction.GO_DEMONSTRATION))
            {
                CurrentViewModel = new DemonstrationViewModel();
            }
        }


        public MainViewModel()
        {
            currentViewModel = new HomeViewModel();
            // abonnement de la méthode listeningMessenger à l'event deleguate messagestatus
            // A chaque déclenchement d'action la méthode listenMessenger sera notifié avec des données si nécessaire en paramètre
            Messenger.Messenger_instance.messageStatus += listeningMessenger;
        }

    }
}
