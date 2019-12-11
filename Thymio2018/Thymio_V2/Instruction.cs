using System;
using System.Collections.Generic;
using System.Text;

namespace Thymio_V2
{
    /// <summary>
    /// Class instruction that define an instruction by his name and his code
    /// The code will be only the part necessary for the control the robot thymio
    /// </summary>
    public class Instruction
    {
        private string name;
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        private string code;
        public string Code
        {
            get { return code; }
            private set { code = value; }
        }


        public Instruction(string name,string code)
        {
            this.name = name;
            this.code = code;
        }
    }
}
