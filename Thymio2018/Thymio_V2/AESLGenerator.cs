using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Thymio_V2
{
    class AeslGenerator
    {
        private StringBuilder aesl_code;
        XDocument doc;
        private XElement content;

        private string aesl_file_path;

        /// <summary>
        /// Constructor of the Generator Class 
        /// If the aesl file doesn't exist we initialize his template
        /// Otherwise we will use the existant file
        /// </summary>
        /// <param name="aesl_path"></param>
        public AeslGenerator(string aesl_path)
        {
            aesl_code = new StringBuilder();
            doc = new XDocument();
            
            Debug.Write(doc);
            initialize();
            Debug.WriteLine("INIT");

            aesl_file_path = aesl_path;
        }


        private void initialize()
        {
            doc.Add(new XElement("network",
                   new XElement("keyboards", new XAttribute("flag", "true")),
                     new XElement("node", new XAttribute("nodeId", "2349"), new XAttribute("name", "Thymio-II"),"" )) );
        }

        /// <summary>
        /// Inititialize the template of the file  
        /// </summary>
        private void writeAeslFile(StringBuilder code)
        {
            //doc.Element("node").Value = code;
            doc.Element("network").Element("node").SetValue(code);
        
        }


     
        public void saveDoc()
        { 
            //document.Save(@"D:\bilel\Desktop\thymio II\thymio2018\Thymio2018\foo.aesl");
        }

        public void generateAeslFile(List<Instruction> instructionList)
        {
            StringBuilder code = convertInstruction(instructionList);
            writeAeslFile(code);
            code.Clear();
            doc.Save(aesl_file_path);

            Debug.Write("ok");
        }

        /// <summary>
        /// This method will convert the instructions list into a string builder that will be add into the XElement name "node"
        /// </summary>
        /// <param name="instructionList"></param>
        public StringBuilder convertInstruction(List<Instruction> instructionList)
        {

            foreach(Instruction instruc in instructionList)
            {
                aesl_code = aesl_code.Append(new StringBuilder("\t"+instruc.Code+"\n"));
            }
            return aesl_code;
        }

    }
}
