using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ThymioWPFApplication.ViewModels
{
    /// <summary>
    /// Classe Abstraite pour permettre et eviter a tout les Views Model de réinplémenter le PropertyChanged...
    /// </summary>
    abstract class BaseViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(String info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }

        
        /// <summary>
        /// Permet de déclencher un événement via l'envoie d'une action depuis n'importe quel viewModel héritant de BaseViewModel
        /// Un objet peut être envoyé via cette appelle
        /// </summary>
        /// <param name="messenger_action">L'action à déclencher</param>
        /// <param name="obj">L'objet à envoyer</param>
        protected virtual void publishAction(EnumMessengerAction messenger_action, Object obj){
            Messenger.Messenger_instance.Obj = obj;
            Messenger.Messenger_instance.Action_message = messenger_action;
        }

        /// <summary>
        /// Même principe que la méthode précédent seulement l'on ne déclenche qu'une seule action sans avoir à envoyer instancié
        /// </summary>
        /// <param name="messenger_action"></param>
        protected virtual void publishAction(EnumMessengerAction messenger_action)
        {
            publishAction(messenger_action, null);
        }


    }
}
