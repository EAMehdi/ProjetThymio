using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ThymioWPFApplication.ViewModels.DemonstrationViewModels
{
    class TurnViewModel : BaseViewModel
    {

        private int angle;
        public int Angle
        {
            get { return angle; }
            set
            {
                angle = value;
                OnPropertyChanged(nameof(Angle));
            }
        }

        public String AngleStr
        {
            get { return angle.ToString(); }
            set
            {
                
                int x;
                if(Int32.TryParse(value, out x)) {
                    if (x > 360)
                        Angle = 360;
                    else if (x < 0)
                        Angle = 0;
                    else
                        Angle=x;
                    OnPropertyChanged(nameof(AngleStr));
                }
                else
                    Angle= 0;
            }
        }

        /// <summary>
        /// Direction of the rotation false for left and true for right
        /// </summary>
        private Boolean direction;
        public Boolean Direction
        {
            get { return direction; }
            set
            {
                direction = value;
                Debug.WriteLine("dir" + direction);
                OnPropertyChanged(nameof(Direction));
            }
        }

        private ICommand addInstructionCommand;
        public ICommand AddInstructionCommand
        {
            get { return addInstructionCommand; }
        }



        public TurnViewModel()
        {
            Direction = true;
            addInstructionCommand = new RelayCommand(new Action(AddInstruction_ExecuteCommand));
        }


        private void AddInstruction_ExecuteCommand()
        {
            if (Direction)
                DemonstrationViewModel.getThymio().TurnRight(Angle);
            else
                DemonstrationViewModel.getThymio().TurnLeft(Angle);


        }
    }
}
