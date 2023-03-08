using CMP1903M_A01_2223;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{//As requested a test class
    internal class TestClass
    {//main constructor
        public TestClass()
        {
            //Card Object
            Card testCard = new Card(2, 1);
            // works as programmed
            Console.WriteLine("$Test to check a card object has been properly created\n\n" + "Int representing the suit {1}" + "   " + "The int representing value {2}" + "   " + "and finally its face values {3}" + "\n", "\n", testCard.suit, testCard.value, testCard.aface);


            //Deck creation
            //Deck will inherit the methods and attributes of the Pack class
            Pack testPack = new Pack();


            Console.WriteLine("Test the deck has been created correctly");
            //tests the unsuffled deck
            testPack.TestPack(testPack);





            Console.WriteLine("\n\n");
            //Shuffles
            Console.WriteLine("Test to confirm the shuffle has worked");
            Console.WriteLine("\n\n");


            //try block covers non int input errors
            try
            {
                //user input for shuffle type
                Console.WriteLine("Please enter yor preffered shuffle;\n The choices are as follows:\n enter 1 for a Fisher shuffle, 2 for Riffle and 3 for no shuffle");
                int shuffleType = Convert.ToInt32(Console.ReadLine());

                Pack.ShuffleCardPack(shuffleType, testPack);





                Console.WriteLine("\n\n");
                Console.WriteLine("Test of deal single card func\n");


                //Hand and single card methods
                Pack.Deal(testPack);
                Console.WriteLine("\n\n");
                Console.WriteLine("Test of multi card deal\n");
                Pack.DealCard(7, testPack);

            }
            //code that is ran during the event of error handling
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Goodbye");
                Environment.Exit(1);
            }
        }
    }
}
        

            
        
