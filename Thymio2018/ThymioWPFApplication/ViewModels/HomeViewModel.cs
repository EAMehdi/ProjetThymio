using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ThymioWPFApplication.ViewModels
{
    class HomeViewModel : BaseViewModel
    {

        /// <summary>
        /// Comamnd progHomeCommand
        /// Va permmettre de se diriger ver la page progHomePage
        /// </summary>
        private ICommand progHomeCommand;
        public ICommand ProgHomeCommand
        {
            get { return progHomeCommand; }
        }

        /// <summary>
        /// Command pour accéder à la partie démonstration de l'application
        /// </summary>
        private ICommand demonstrationCommand;
        public ICommand DemonstrationCommand
        {
            get { return demonstrationCommand; }
        }

        /// <summary>
        /// constructor
        /// </summary>
        public HomeViewModel()
        {
            //Pas besoin de can execute pour ces deux commandes
            progHomeCommand = new RelayCommand(new Action(ProgHome_ExecuteComamnd));
            demonstrationCommand = new RelayCommand(new Action(Demonstration_ExecuteCommand));
            //exitCommand = new RelayCommand(new Action(Exit_ExecuteCommand));
        }

        #region Command_Method
        private void Demonstration_ExecuteCommand()
        {
            publishAction(EnumMessengerAction.GO_DEMONSTRATION);
        }

        /// <summary>
        /// Commande qui sera executé via l'utilisation de la commande progHome_Command au travers de la class RelayCommand
        /// </summary>
        private void ProgHome_ExecuteComamnd()
        {
            Debug.WriteLine("Command");
            //Cette instruction va déclencher le messageStatus Event qui va invoke la méthode abonné qui va enclenché des changements 
            publishAction(EnumMessengerAction.GO_PROG_HOME);
        }

        private void Exit_ExecuteCommand()
        {

        }
        #endregion


    }
}
