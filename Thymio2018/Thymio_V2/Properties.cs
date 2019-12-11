using System;
using System.Collections.Generic;
using System.Text;

namespace Thymio_V2
{
    /// <summary>
    /// Enumeration of all the propeties of the robot thymio-II
    /// </summary>
    enum Properties 
    {
        //motor properties
        MOTOR_LEFT_SPEED,
        MOTOR_RIGHT_SPEED,
        MOTOR_LEFT_TARGET,
        MOTOR_RIGHT_TARGET,
        MOTOR_LEFT_PWM,
        MOTOR_RIGHT_PWM,
        

        // Button
        BUTTON_FORWARD,
        BUTTON_BACKWARD,
        BUTTON_LEFT,
        BUTTON_RIGHT,
        BUTTON_CENTER,

        // sensor
        TEMPERATURE,

        // Infrared
        RC5_ADRESS,
        RC5_COMMAND,

        // mic 
        MIC_INTENSITY,  // microphone intensity
        MIC_THRESHOLD,  // limit of the intensity for the event if mic_intensiy > mic_trreshold the event is called

        // captor/sensor
        PROX_HORIZONTAL_1,
        PROX_HORIZONTAL_2,
        PROX_HORIZONTAL_3,
        PROX_HORIZONTAL_4,
        PROX_HORIZONTAL_5,
        PROX_HORIZONTAL_6,

        PROX_GROUND_AMBIANT,
        PROX_GROUND_REFLECTED,
        PROX_GROUND_DELTA,

        //accelerometer

        ACC_0,      // X axis
        ACC_1,      // y axis
        ACC_2,      // z axis


        //Timer 
        TIMER1,
        TIMER2


    }
}
