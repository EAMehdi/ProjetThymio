using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Thymio_V2;
using ThymioWPFApplication.ViewModels.DemonstrationViewModels;

namespace ThymioWPFApplication.ViewModels
{
    class DemonstrationViewModel :BaseViewModel
    {
        /// <summary>
        /// Robot
        /// </summary>
        private static ThymioV2 thymio;

        public static ThymioV2  getThymio()
        {
            return thymio;
        }
        public ObservableCollection<Instruction> ListInstruction
        {
            get { return thymio.ListInstruction; }
        }



        private BaseViewModel myUserControlVM;
        public BaseViewModel MyUserControlVM
        {
            get { return myUserControlVM; }
            set
            {
                myUserControlVM = value;
                OnPropertyChanged(nameof(MyUserControlVM));
            }
        }

        #region Command
        private ICommand chooseFunctionCommand;
        public ICommand ChooseFunctionCommand
        {
            get { return chooseFunctionCommand; }
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
        /// Command for coe back to the menu
        /// </summary>
        private ICommand homeCommand;
        public ICommand HomeCommand
        {
            get { return homeCommand; }
        }

        /// <summary>
        /// Command for coe back to the menu
        /// </summary>
        private ICommand resetCodeCommand;
        public ICommand ResetCodeCommand
        {
            get { return resetCodeCommand; }
        }
        
        #endregion

        /// <summary>
        /// Constructor of the DemonstrationViewModel
        /// </summary>
        public DemonstrationViewModel()
        {
            chooseFunctionCommand = new RelayCommand(new Action<Object>(ChooseFunction_ExecuteCommand));
            transfertCommand = new RelayCommand(new Action(TransfertCommand_ExecuteMethode));
            homeCommand = new RelayCommand(new Action(HomeCommand_ExecuteMethod));

            resetCodeCommand = new RelayCommand(new Action(ResetCodeCommand_ExecuteMethod));
            thymio = new ThymioV2();
        }

        /// <summary>
        /// ExecuteMethod of the command ChooseFunction that will set the right VM according to the parameters received
        /// The riht UserControl will be displayed according to the ViewModel
        /// </summary>
        /// <param name="obj"></param>
        private void ChooseFunction_ExecuteCommand(Object obj)
        {
            string val = obj.ToString();
            switch (val)
            {
                case "move":
                    MyUserControlVM =new ForwardBackwardViewModel();
                    break;
                case "turn":
                    MyUserControlVM = new TurnViewModel();
                    break;
                case "sensors":
                    MyUserControlVM = new SensorViewModel();
                    break;
            }

        }

        private void HomeCommand_ExecuteMethod()
        {
            publishAction(EnumMessengerAction.GO_HOME);
        }

        private void TransfertCommand_ExecuteMethode()
        {
            thymio.Fin();
        }

        private void ResetCodeCommand_ExecuteMethod()
        {
            thymio.resetCode();
        }



    }
}
