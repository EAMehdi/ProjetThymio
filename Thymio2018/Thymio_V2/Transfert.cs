using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Thymio_V2;

namespace Thymio_V2
{
    public class Transfert
    {

        public bool IsAsebarec;

        /// <summary>
        /// The processus for run asebahttp
        /// </summary>
        Process processus;
        ProcessStartInfo process_startInfo;

        Boolean __transfertEnCours;

        /// <summary>
        /// The relative path of the current directory
        /// </summary>
        private String relativePath; 
        
        /// <summary>
        /// The path of the aesl file that will be transfer to the thymio
        /// </summary>
        private String aeslfile_path;
        
        /// <summary>
        /// The path of the asebahttp executable
        /// </summary>
        private String asebahttp_path;

        /// <summary>
        /// The 
        /// </summary>
        private String transfer_message;

        /// <summary>
        /// 
        /// </summary>
        private AeslGenerator AESLgenerator;


        /// <summary>
        /// Transfert Constructor that will set a default name of the aesl file generate (foo.aesl)
        /// </summary>
        public Transfert() : this("foo.aesl"){
         
        }

        /// <summary>
        /// Transfert constructor that will set the file_path of the asebahttp executable needed for the file transfert as well as the aesl file 
        /// It will create a AESLgenerator instance aiming to convert the list of instructions before the transfert
        /// </summary>
        /// <param name="filename"></param>
        public Transfert(string filename)
        {
            relativePath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + @"\..\";

            aeslfile_path = relativePath + filename;
            asebahttp_path = relativePath + @"asebahttp\asebahttp.exe";
            Debug.WriteLine("ASEBAHTTP:" + asebahttp_path);
            Debug.WriteLine("FILE:" + aeslfile_path);

            //creation of the aesl file by instanciate AESLGenerator
            AESLgenerator = new AeslGenerator(aeslfile_path);

            processus = new Process();
            process_startInfo = new ProcessStartInfo();
        }

        public Boolean TransfertFileToThymio(List<Instruction> instructionList)
        {
            AESLgenerator.generateAeslFile(instructionList);
            
            if (IsAsebarec)
            {
                Console.WriteLine("Aseba rec-------------");
            }

            if ( !isFileExist(asebahttp_path))
            {
                Console.WriteLine("error file doesn't exist");
                return false;
            }
            else if (!isFileExist(aeslfile_path)){
                Console.WriteLine("error 2");
                return false;
            }
            else{
                // Prépare le processus de transfert avec l'application asebahttp.exe
                AfficheMessage("Execution de AsebaHttp"); // utilisé un delegate pour l'affichage

                process_startInfo.Arguments = "--aesl \"" + aeslfile_path + "\" ser:name=Thymio-II";
                process_startInfo.FileName = asebahttp_path;
                process_startInfo.WorkingDirectory = Path.GetDirectoryName(asebahttp_path);
                process_startInfo.CreateNoWindow = true;
                process_startInfo.RedirectStandardOutput = true;
                process_startInfo.RedirectStandardError = true;
                process_startInfo.UseShellExecute = false;

                // Lance le processus de transfert
                __transfertEnCours = true;

                transfer_message = String.Empty;

                processus = new Process();
                processus.OutputDataReceived += new DataReceivedEventHandler(ConsoleMessageRedirection);
                processus.ErrorDataReceived += new DataReceivedEventHandler(ConsoleMessageRedirection);
                processus.EnableRaisingEvents = false;

                processus.StartInfo = process_startInfo;
                processus.Start();
                processus.BeginOutputReadLine();

                processus.BeginErrorReadLine();

                // Boucle de TimeOut de 10 secondes
                for (int i = 0; i < 10 * 2; i++)
                {
                    if (!__transfertEnCours)
                    {
                        // Attends 4s, le temps que le transfert se termine.
                        // Temporisation à déterminer avec un Thymio Wireless
                        System.Threading.Thread.Sleep(4000);
                        break;
                    }
                    System.Threading.Thread.Sleep(500);

                }
                Debug.WriteLine("Coucou");
                //FIn du processus, fin du transfert
                processus.Kill();
                Debug.WriteLine("Coucou2");

                AfficheMessage("Fin execution de AsebaHTTP");
                

                if (transfer_message == String.Empty )
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    AfficheMessage("Erreur: " + transfer_message);
                    return false;
                }

                // Envoie vers la console les messages de AsebaHttp
            }
        }
        
        /// <summary>
        /// Afficher message
        /// </summary>
        /// <param name="texte"></param>
        private static void AfficheMessage(string texte)
        {
            Console.WriteLine();
            Console.WriteLine(texte);
        }

        /// <summary>
        /// Afficher en tête
        /// </summary>
        /// <param name="texte"></param>
        private static void AfficheEnTete(string texte)
        {
            int nbEspaces = (Console.WindowWidth - texte.Length) / 2;

            Console.SetCursorPosition(nbEspaces, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(texte);
            Console.ForegroundColor = ConsoleColor.White;
        }

        

        /// <summary>
        /// Check if the file exist or not 
        /// </summary>
        /// <param name="fileName"> The file name </param>
        /// <returns></returns>
        private  static Boolean isFileExist(String fileName)
        {
            return File.Exists(fileName);
        }


        /// <summary>
        /// Console Message redirection
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="_e"></param>
        private void ConsoleMessageRedirection(object _sender, DataReceivedEventArgs _e)
        {
            Console.ForegroundColor = ConsoleColor.White;
            AfficheMessage(_e.Data);
            if (_e.Data != null)
            {
                if (_e.Data.IndexOf("Found Thymio-II on port") != -1)
                    __transfertEnCours = false;
                if (_e.Data.IndexOf("HttpInterface can't connect target") != -1)
                {
                    transfer_message = "THYMIO NON CONNECTE !";
                    __transfertEnCours = false;
                }
                if (_e.Data.IndexOf("Script too big for target bytecode") != -1)
                {
                    transfer_message = "Programme trop grand pour Thymio";
                    __transfertEnCours = false;
                }
            }
        }



    }
}

