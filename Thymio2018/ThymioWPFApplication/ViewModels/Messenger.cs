using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThymioWPFApplication.ViewModels
{
    /// <summary>
    /// Messenger Class implementing the singleton conception patron
    /// This class allow the possibility to publish a message and notify the followers
    /// </summary>
    class Messenger
    {
        private static Messenger messenger_instance;
        public static Messenger Messenger_instance
        {
            get{
                if(messenger_instance == null)
                    messenger_instance = new Messenger();
                return messenger_instance;
            }
        }

        /// <summary>
        /// Création du type deleguate référencant une méthode retournant void et prenant en paramètre une action ainsi qu'un objet quelconque
        /// </summary>
        /// <param name="action"></param>
        /// <param name="obj"></param>
        public delegate void MessageEventHandler(EnumMessengerAction action, Object obj);

        /// <summary>
        /// Création de l'instance du délégué précedent 
        /// A noté que l'on rajoute event devant le délégué pour éviter de supprimer l'ensemble des méthodes déjà référencé par le déléguate
        /// (Sous entend l'interdiction du messageStatus = methode(...) )
        /// </summary>
        public event MessageEventHandler messageStatus;

        /// <summary>
        /// Objet que l'on peut envoyer durant l'envoie d'une action 
        /// </summary>
        private Object obj;
        public Object Obj
        {
            set{
                obj = value;
            }
        }

        private EnumMessengerAction action_message;
        /// <summary>
        /// Le message/action à setter
        /// Lors de la modification de action_message ceci déclanche invocation des méthode abonné a messageStatus
        /// En envoyant l'action source et un objet si nécessaire
        /// </summary>
        public EnumMessengerAction Action_message
        {
            set{
                action_message = value;
                messageStatus?.Invoke(action_message,obj);  // ? est pour dire si le delgaute n'est pas null alors invoke
            }
        }


        /// <summary>
        /// Private Constructor because of the singleton conception pattern
        /// </summary>
        private Messenger(){
        }
        



    }
}
