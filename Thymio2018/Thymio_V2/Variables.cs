using System;
using System.Collections.Generic;
using System.Text;

namespace Thymio_V2
{
    class Variables
    {
        /// <summary>
        /// Dictionary of properties/variables names
        /// For each properties/variables names are link for values their equivalent in aesl language
        /// The dictionary will be load in the constructor. 
        /// </summary>
        private Dictionary<Properties, String> _robot_variables;


        /// <summary>
        /// </summary>
        private Dictionary<String , String> _personal_variables;

        public Variables()
        {
            _robot_variables = new Dictionary<Properties, string>();
            _personal_variables = new Dictionary<string, string>();


            // A enlever et remplacer par le chargement des données via un stub
            // Variables manquantes mais présente dans Properties
            _robot_variables.Add(Properties.MOTOR_RIGHT_TARGET, "motor.right.target");
            _robot_variables.Add(Properties.MOTOR_LEFT_TARGET, "motor.left.target");
            _robot_variables.Add(Properties.MOTOR_LEFT_SPEED, "motor.left.speed");
            _robot_variables.Add(Properties.MOTOR_RIGHT_SPEED, "motor.right.speed");
            _robot_variables.Add(Properties.TIMER1, "timer.period[0]");
            _robot_variables.Add(Properties.TIMER2, "timer.period[1]");
            // ... ajouter d'autre variable spécifique au robot

        }


        /// <summary>
        /// Allow to add a personnal variable. If the variable doesn't exist it will be add to the dictionnary of personnal variable
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool addPersonnalVariable(String name)
        {
            if (_personal_variables.ContainsKey(name))
            {
                return false;
            }
            
            _personal_variables.Add(name, "var"+name);
            return true;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public string getVariable(Properties property)
        {
            return _robot_variables.ContainsKey(property) ?_robot_variables[property] : "";
        }

        public string getVariable(String name)
        {
            return (_personal_variables.ContainsKey(name)) ? name : "";
        }

        public Boolean isVariableExist(Properties property)
        {
            return _robot_variables.ContainsKey(property);

        }

        public Boolean isVariableExist(String name)
        {
            return _personal_variables.ContainsKey(name);

        }
    }
}
