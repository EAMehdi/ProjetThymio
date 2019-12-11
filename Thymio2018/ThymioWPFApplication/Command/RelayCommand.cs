using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ThymioWPFApplication
{
    /// <summary>
    /// Class RalayCommand permettant de pouvoir créer une seule commande
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// Delégué de type Action soit qui prend un ou des paramètres générique et qui renvoie void 
        /// Ici le delegue ne prend aucun paramètre 
        /// </summary>
        readonly Action _execute = null;

        /// <summary>
        /// Délégué prenant en paramtre un objet afin de modéliser les command utilisant les command parameter
        /// </summary>
        readonly Action<Object> _execute2 = null;

        /// <summary>
        /// Délégué de type Func soit un délégué qui prend un ou des paramètres générique et qui renvoie une valeur d'un type générique
        /// Ici on ne renvoie qu'un booleen sans avoir de paramètre en entré
        /// </summary>
        readonly Func<bool> _canExecute = null;


        /// <summary>
        /// Creer la nouvelle instance Relay commande. 
        /// Ce constructeur prend en action un methode prenant en paramètre un Object quelconque
        /// </summary>
        /// <param name="execute">Deleguer a executer quand la commande est appelé.</param>
        /// <remarks><seealso cref="CanExecute"/> will always return true.</remarks>
        public RelayCommand(Action<Object> execute2) : this(execute2, null)
        {
        }

        /// <summary>
        /// Constructeur de RelayCommand prennant cette fois ci en paramètre une Action ainsi que un delegué Func Prenant en compte un objet recu en paramètre
        /// Lors de la création de la commande le delegue Action execute doit forcement réferenecer une methode sinon la commande n'a pas lieu d'etre
        /// </summary>
        /// <param name="execute">L'execution logique</param>
        /// <param name="canExecute">Le status de l'execution (Si on peut l'executer ou pas) </param>
        public RelayCommand(Action<Object> execute2, Func<bool> canExecute)
        {
            if (execute2 == null)
                throw new ArgumentNullException("Exception car execute2 == null");

            _execute2 = execute2;
            _canExecute = canExecute;
        }


        /// <summary>
        /// Creer la nouvelle instance Relay commande. 
        /// Dans ce constructeur qui prend juste une Action en paramètre l'on insctancie le relayCommand via second constructeur envoyant en paramètre l'action et une valeur null
        /// </summary>
        /// <param name="execute">Deleguer a executer quand la commande est appelé.</param>
        /// <remarks><seealso cref="CanExecute"/> will always return true.</remarks>
        public RelayCommand(Action execute) : this(execute, null)
        {
        }

        /// <summary>
        /// Constructeur de RelayCommand prennant cette fois ci en paramètre une Action ainsi que un delegué Func 
        /// Lors de la création de la commande le delegue Action execute doit forcement réferenecer une methode sinon la commande n'a pas lieu d'etre
        /// </summary>
        /// <param name="execute">L'execution logique</param>
        /// <param name="canExecute">Le status de l'execution (Si on peut l'executer ou pas) </param>
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("Exception car execute == null");

            _execute = execute;
            _canExecute = canExecute;
        }

        ///<summary>
        ///Definis quand la command peut etre execute
        ///On a deux cas soit l'on a définis une fonction définissant quand la commande peut etre execute (methode referencé par le delegue Func)
        ///Ou alors notre commande ne possede pas de "Func" (donc lors de ca construction celle ci à été définis à null)
        ///Ce qui veut dire quelle peut etre executée sans conditions de vérification 
        ///D'ou le if ternaire.
        ///</summary>
        ///<param name="parameter"></param>
        ///<returns>
        ///     Retourne true si il n'y a pas de methode implémenté via le deleguate Func , si il y en a une alors l'on retourne la valeur de cette methode _canExecute.invoke() /_canExecute();
        ///</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }

        ///<summary>
        ///
        ///</summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        ///<summary>
        ///La methode à executer quand la commande est appellé. Ici on fait donc un invoke du délegue Action qui contient une réference vers la méthode donnée lors de la création de la commande 
        ///Par conséquent l'on va donc executer cette methode (par _execute(); ou _execute.invoke(); ) 
        ///</summary>
        ///<param name="parameter"></param>
        public void Execute(object parameter)
        {
            if (_execute != null)
                _execute();
            else
                _execute2(parameter.ToString());
        }

    }
}