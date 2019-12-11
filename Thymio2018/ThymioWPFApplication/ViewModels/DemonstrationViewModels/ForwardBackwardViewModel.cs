using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Thymio_V2;

namespace ThymioWPFApplication.ViewModels.DemonstrationViewModels
{
    class ForwardBackwardViewModel :BaseViewModel
    {
        private int speed;
        public int Speed
        {
            get { return speed;}
            set
            {
                speed = value;
                OnPropertyChanged(nameof(Speed));
            }
        }
        
        public String SpeedStr
        {
            get { return speed.ToString(); }
            set
            {
                Debug.WriteLine(SpeedStr);
                int x;
                if (Int32.TryParse(value, out x))
                {
                    if (x > 600)
                        Speed = 600;
                    else if (x < 0)
                        Speed = 0;
                    else
                        Speed = x;

                    OnPropertyChanged(nameof(SpeedStr));
                }
                else
                    Speed = 0;
            }
        }


        /// <summary>
        /// Direction the movement true for forward and false for backward
        /// </summary>
        private Boolean direction;
        public Boolean Direction
        {
            get { return direction; }
            set
            {
                direction = value;
                OnPropertyChanged(nameof(Direction));
            }
        }


        private ICommand addInstructionCommand;
        public ICommand AddInstructionCommand {
            get { return addInstructionCommand; }
        }


        public ForwardBackwardViewModel()
        {
            Direction = true;
            addInstructionCommand = new RelayCommand(new Action(AddInstruction_ExecuteCommand));
        }


        private void AddInstruction_ExecuteCommand()
        {
            if(Direction)
                DemonstrationViewModel.getThymio().ForwardAtDistanceToSpeed(0, Speed);
            else
                DemonstrationViewModel.getThymio().BackwardAtDistanceToSpeed(0, Speed);

        }

    }
}
