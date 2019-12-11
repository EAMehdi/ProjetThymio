using Modele;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Xml;

namespace Thymio_V2
{
    public class ThymioV2 : Thymio
    {
        /// <summary>
        /// List of instruction that will be add in the aesl file during the transfert+aeslgenerator
        /// </summary>
        private List<Instruction> listInstruction;
        public ObservableCollection<Instruction> ListInstruction; 

        /// <summary>
        /// Dictionary of properties/variables names
        /// For each properties/variables names are link for values their equivalent in aesl language
        /// The dictionary will be load in the constructor. 
        /// </summary>
        //private Dictionary<Properties, String> variables;

        private int timeDelay = 10000;

        /// <summary>
        /// Contains all variables used by the robot
        /// There is robot variables
        /// And personnal variables
        /// </summary>
        private Variables variables;


        /// <summary>
        /// Itera is an iterator that will allow the robot to produce severals action with intervals of time between them
        /// Iterator is a variables that will be incremented in the robot algorithm each time that the timer make a loop
        /// Then owing to that with the iterators values and an if condition we can execute the right instructions
        /// </summary>
        private int itera;
        public int Itera
        {
            get {
                itera++;
                return itera;
            }
        }

        /// <summary>
        /// Allow the start of the transfert process 
        /// During the transfert the aesl file will be generate before being sent to the robot
        /// </summary>
        Transfert tranfert;

        
        
        /// <summary>
        /// Constructor 
        /// </summary>
        public ThymioV2()
        {
            tranfert = new Transfert();
            listInstruction = new List<Instruction>();
            ListInstruction = new ObservableCollection<Instruction>();
            variables = new Variables();
            //variables = new Dictionary<Properties, string>();

            // met en place les instructions permettant au robot d'executer des actions séquentiellement
            initialize();
        }

        /// <summary>
        /// Initialize method 
        /// Build up the bases of the robot algorithm by adding the sequencial structure using the timer and the iterator
        /// </summary>
        private void initialize()
        {
            sequential_structure();
        }


        #region Forward

        /// <summary>
        /// Instruction for moving forward
        /// </summary>
        /// <param name="distance"> The distance that the robot will have to reach </param>
        /// <param name="speed"> The speed of the motor wheels </param>
        public override void ForwardAtDistanceToSpeed(int distance,int speed)
            {
                AddInstructionToList(new Instruction("Start if Forward", "if iterator" + Condition.Instance.getOperator(Operator.EQUAL) + Itera +" then"));
                AssignVariable(Properties.MOTOR_RIGHT_TARGET, speed);
                AssignVariable(Properties.MOTOR_LEFT_TARGET, speed);
                //listInstruction.Add(new Instruction(" Forward ", " motor.left.target =" + speed));
                //listInstruction.Add(new Instruction(" Forward ", " motor.right.target =" + speed));
                EndIfCondition();
        }



        #endregion

        #region Backward

        public override void BackwardAtDistanceToSpeed(int distance, int speed)
        {

            speed *= -1; 
            AddInstructionToList(new Instruction("Start if Backward", "if iterator" + Condition.Instance.getOperator(Operator.EQUAL) + Itera + " then"));
            AssignVariable(Properties.MOTOR_RIGHT_TARGET, speed);
            AssignVariable(Properties.MOTOR_LEFT_TARGET, speed);
            EndIfCondition();

        }



        #endregion

        #region Turn

        /// <summary>
        /// Perimeter of a circle is 2 x π x R
        /// </summary>
        /// <param name="angle"></param>
        public override void TurnLeft(int angle){
            //distance between the two wheel is 10cm so R is equal to 10
            angle = angle % 360;
            int ratio;
            if (angle != 0)
            {
                ratio = (angle == 360) ?  1 : 360 / angle;
                double dist = (2 * Math.PI * 10) / ratio;
                int speed = (int)dist * 500 / 16;
                //speed += 150;

                Debug.WriteLine("dist" + dist + "\nspeed" + speed);

                AddInstructionToList(new Instruction("Start if TurnLeft", "if iterator" + Condition.Instance.getOperator(Operator.EQUAL) + Itera + " then"));
                AssignVariable(Properties.MOTOR_RIGHT_TARGET, (speed / 2));
                AssignVariable(Properties.MOTOR_LEFT_TARGET, (-speed / 2));
                EndIfCondition();
            }
        }

        public override void TurnLeftMoving()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Problème angle élévé et fréquence
        /// </summary>
        /// <param name="angle"></param>
        public override void TurnRight(int angle)
        {
            //distance between the two wheel is 10cm so R is equal to 10
            angle = angle % 360;
            if(angle != 0){
                int ratio = (angle == 360) ? 1 : 360 / angle;
                double dist = (2 * Math.PI * 10) / ratio;
                Debug.WriteLine("angle"+angle + "ration" + ratio);
                int speed = (int)dist * 500 / 16;
            
                Debug.WriteLine("dist" + dist + "\nspeed" + speed);

                AddInstructionToList(new Instruction("Start if TurnRight", "if iterator" + Condition.Instance.getOperator(Operator.EQUAL) + Itera + " then"));
                AssignVariable(Properties.MOTOR_RIGHT_TARGET, (-speed / 2));
                AssignVariable(Properties.MOTOR_LEFT_TARGET, (speed / 2));
                EndIfCondition();
            }
        }
        #endregion

        #region Stop
            public override void Stop()
            {
                AddInstructionToList(new Instruction("Start if Stop", "if iterator" + Condition.Instance.getOperator(Operator.EQUAL) + Itera + " then"));
                AssignVariable(Properties.MOTOR_RIGHT_TARGET, 0);
                AssignVariable(Properties.MOTOR_LEFT_TARGET, 0);
                EndIfCondition();
            }

            public override void StopWithASoundSignal()
            {
                throw new NotImplementedException();
            }

            public override void StopWithButton()
            {
                throw new NotImplementedException();
            }
        #endregion

        #region Loop_and_Condition
            // EndIf COndition et EndLoop Condition à factoriser
            public override void EndIfCondition()
            {
                AddInstructionToList(new Instruction("End if", "end"));
            }

            public override void EndLoopCondition()
            {
                AddInstructionToList(new Instruction("End loop","end"));
            }


            public override void StartIfCondition(string condition)
            {
                throw new NotImplementedException();
            }

            public override void StartLoopCondition(String Condition)
            {
            //    Ajouter condition dans la ligne de code
            //    listInstruction.Add(new Instruction("Start loop",))
            
            }
        #endregion

        #region led
        public override void SwitchOnLed( int led){
            // A modifier et rendre maintenable
            AddInstructionToList(new Instruction("", "if iterator" + Condition.Instance.getOperator(Operator.EQUAL) + Itera + " then"));
            AddInstructionToList(new Instruction("led", "call leds.circle(32,32,32,32,32,32,32,32)"));
            AddInstructionToList(new Instruction("led", "call leds.bottom.left(255, 255, 255)"));
            AddInstructionToList(new Instruction("led", "call leds.bottom.right(255, 255, 255)"));
            AddInstructionToList(new Instruction("led", "call leds.top(255, 255, 255)"));
            AddInstructionToList(new Instruction("led", "call leds.buttons(32, 15, 32, 15)"));
            EndLoopCondition();
        }
        #endregion


        public void Fin()
        {
            // générer les itérateurs avec le timer
            tranfert.TransfertFileToThymio(listInstruction);
        }

        public void resetCode()
        {
            ListInstruction.Clear();
            listInstruction.Clear();
            initialize();
        }

        public override void TurnRightMoving()
        {
            throw new NotImplementedException();
        }



        #region InstructionConstruction
        //Methode assignVAriable à factoriser

        /// <summary>
        /// This method allow the assignment of robot variables by adding an assignement instruction into the list of Instruction 
        /// </summary>
        /// <param name="var"></param>
        /// <param name="value"></param>
        private void AssignVariable(Properties var, object value)
        {
           
            Instruction i = new Instruction("Affectation", variables.getVariable(var) + "=" + value.ToString());

            if (variables.isVariableExist(var))
            {
                AddInstructionToList(i);
            }
            else
                throw new Exception("assignemet error, var doesn't exist");
        }


        private void AssignVariable(String name, object value)
        {

            if (variables.isVariableExist(name))
            {
                AddInstructionToList( new Instruction("Affectation", variables.getVariable(name) + "=" + value.ToString()));
            }
            else
                throw new Exception("assignemet error, var doesn't exist");
        }


        private void sequential_action(List<Instruction> innner_instruction)
        {
            //listInstruction.Add(new Instruction("", "if iterator" + Condition.Instance.getOperator(Operator.EQUAL) + Itera + " then"));
            AddInstructionToList(new Instruction("If Condition", "if iterator" + Condition.Instance.getOperator(Operator.EQUAL) + Itera + " then"));
            EndLoopCondition();
        }

        private void VariableDeclaration(String name)
        {

        }


        /// <summary>
        /// Methode à améliorer (à rendre plus propre eviter l'ajout des instructions en dur)
        /// </summary>
        private void sequential_structure()
        {
            AddInstructionToList(new Instruction("Déclaration", "var iterator"));
            AssignVariable(Properties.TIMER1,timeDelay);
            AddInstructionToList(new Instruction("Event","onevent timer0"));
            AddInstructionToList(new Instruction("Affectation", "\t iterator++"));
        }
        private void AddInstructionToList(Instruction i)
        {
            listInstruction.Add(i);
            ListInstruction.Add(i);
        }

        #endregion


        public void Evenement()
        {
        }
        
    }
}
