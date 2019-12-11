using System;
using System.Diagnostics;

namespace Modele
{
    public abstract class Thymio
    {

        public Thymio()
        {
        }

    
        /// <summary>
        /// Move forward for a know distance
        /// </summary>
        /// <param name="distance"> a distance in cm </param>
        public abstract void ForwardAtDistanceToSpeed(int distance, int speed);


      
        public abstract void BackwardAtDistanceToSpeed(int distance, int speed);

        /// <summary>
        /// Turn left without moving forward or backward with a special angle given in parameter
        /// </summary>
        /// <param name="angle"> the angle of the rotation </param>
        public abstract void TurnLeft(int angle);

        /// <summary>
        /// Turn Left while moving forward or backward
        /// </summary>
        public abstract void TurnLeftMoving();

        
        /// <summary>
        /// Turn right without moving forward or backward with a special angle given in parameter
        /// </summary>
        /// <param name="angle">The angle of rotation </param>
        public abstract void TurnRight(int angle);

        /// <summary>
        /// Turn right while moving
        /// </summary>
        public abstract void TurnRightMoving();

        public abstract void Stop();
        public abstract void StopWithASoundSignal();
        public abstract void StopWithButton();
        //  protected abstract void 


        /// <summary>
        /// Switch on the led which the number is given in paramter
        /// <param name="ledNumber"> The led number to switch on </param>
        /// </summary>
        public abstract void SwitchOnLed(int ledNumber); // ADD AN ENUMERATION


        //protected abstract void PlaySound();


        //Prototype à developper
        //------------------------------------------------------------------------
        public abstract void StartIfCondition(string condition);
        public abstract void EndIfCondition();

        public abstract void StartLoopCondition(String condition);

        public abstract void EndLoopCondition();


    }
}
