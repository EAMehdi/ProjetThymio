using Modele;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Thymio_V2;

namespace ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            ThymioV2 thy = new ThymioV2();
            //turn(thy);
            //prog2(thy);
            moveForwardBackward(thy);
            Console.Read();
        }
    
        private static void moveForwardBackward(ThymioV2 thy)
        {
            thy.ForwardAtDistanceToSpeed(0, 500);
            thy.Stop();
            //thy.Evenement();
            thy.BackwardAtDistanceToSpeed(0, 500);
            thy.Stop();
            thy.Fin();
        }
        
        private static void prog2(ThymioV2 thy)
        {
            thy.TurnLeft(90);
            thy.ForwardAtDistanceToSpeed(0,400);
            thy.TurnRight(90);
            thy.ForwardAtDistanceToSpeed(0, 400);
            thy.Stop();
            thy.TurnLeft(90);
            thy.ForwardAtDistanceToSpeed(0, 400);
            thy.TurnRight(90);
            thy.ForwardAtDistanceToSpeed(0, 400);
            thy.Stop();
            thy.Fin();
        }


        private static void turn(ThymioV2 thy)
        {
            thy.TurnLeft(90);
            thy.TurnRight(90);
            thy.Stop();
            thy.TurnLeft(180);
            thy.TurnRight(180);
            thy.Stop();
            thy.Stop();
            thy.Fin();
        }
    }
}
