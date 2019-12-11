using Modele;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Thymio_V2;

namespace ThymioWPFApplication.ViewModels
{
    class ProgPageViewModel : BaseViewModel
    {
        private Boolean isErrorTransfer;
        public Boolean IsErrorTransfer {
            get { return isErrorTransfer; }
            set{
                isErrorTransfer = value;
                OnPropertyChanged(nameof(IsErrorTransfer));
            }
        }
        private ObservableCollection<string> testlist= new ObservableCollection<string>();
        public ObservableCollection<string> Testlist
        {
         
            get { return testlist; }
        }

        private StringBuilder terminalText = new StringBuilder();
        public StringBuilder TerminalText
        {
            get { return terminalText; }
       
        }


        private ThymioV2 t;

        /// <summary>
        /// The state of the transfert 
        /// </summary>
        private string transfertState;
        public string TransfertState
        {
            set{
                transfertState=value;
                OnPropertyChanged(nameof(TransfertState));
            }
            get { return transfertState; }
        }

        /// <summary>
        /// Command for start the transfert process
        /// </summary>
        private ICommand transfertCommand;
        public ICommand TransfertCommand
        {
            get { return transfertCommand; }
        }

        /// <summary>
        /// Command for return to the home page
        /// </summary>
        private ICommand quitCommand;
        public ICommand QuitCommand
        {
            get { return quitCommand; }
        }


        /// <summary>
        /// Constructor
        /// </summary>
        public ProgPageViewModel()
        {
            transfertCommand = new RelayCommand(new Action(TransfertCommand_ExecuteMethode), new Func<bool>(TransfertCommand_CanExecuteMethode));
            quitCommand = new RelayCommand(new Action(QuitCommand_ExecuteMethode));
           
            testlist.Add("test");
            testlist.Add("test3");
            testlist.Add("test4");
            testlist.Add("ftest");
            
            TransfertState = "En cours";
            IsErrorTransfer = true;

            t = new ThymioV2();
        }

        private Boolean TransfertCommand_CanExecuteMethode()
        {
            return true;
        }

        private void TransfertCommand_ExecuteMethode()
        {
            terminalText.Append("===DEBUT TRANSFERT===\n");
            OnPropertyChanged(nameof(TerminalText));

            t.ForwardAtDistanceToSpeed(0,500);
            t.Stop();
            t.Fin();

        }

        private void QuitCommand_ExecuteMethode()
        {
            
            publishAction(EnumMessengerAction.GO_HOME);
        }


    }
}
