//class to create the deck of cards
////

using System.Linq.Expressions;
using System.Runtime.CompilerServices;
///OOP assignment 1///
namespace CMP1903M_A01_2223
{
    class Pack
    {
        //collection of variables used by various Pack methods
        public static int xAmount;
        public static List<Card> hand = new List<Card>();

        public List<Card> pack = new List<Card>();
        public static List<Card> playerHand = new List<Card>();
        public static List<Card> shuffledPack = new List<Card>();

        //main constructor
        public Pack()
        {

            //card creation
            for (int i = 0; i < 4; i++)//first loop adds suit looping 4 times
            {
                for (int j = 2; j < 15; j++)// inner loop loops 13 times adding the values to each card and this happens 4 times
                {
                    int suit = j;
                    int Val = i;
                    pack.Add(new Card(suit, Val));

                }
            }
        }
        //Testing
        public void TestPack(Pack pack)
        {

            foreach (Card c in pack.pack)//iterationg through each Card object in the deck Object
            {
                Console.Write(" " + c.aface + "\t" + "\t" + "\t" + "\t");//prints aface as that value is what an end user expects to see

            }
            Console.WriteLine("\n\n");
        }

        //Decide which shuffle to perform and validate input
        public static bool ShuffleCardPack(int typeOfShuffle, Pack pack)
        {
            //shuffle choice validation and selection

            if (typeOfShuffle == 1)
            {



                Console.WriteLine("Fisher shuffle");
                Console.WriteLine("\n");
                Fisher(pack);//point to the relevant method
                return true;
            }
            else if (typeOfShuffle == 2)
            {
                Console.WriteLine("Riffle shuffle");
                Console.WriteLine("\n");
                Riffle(pack);
                return true;
            }
            else if (typeOfShuffle == 3)
            {
                Console.WriteLine("No shuffle\n");
                foreach (Card c in pack.pack)//loop to print deck in the event of no shuffle choice
                {
                    Console.WriteLine(c.aface);
                }
                Console.WriteLine("\n");
                return true;
            }
            //covers non valid int input
            else
            {
                Console.WriteLine("Erroneous input\n Please try again");
                TestClass test = new TestClass(); return true;//loop to beginning in case of error during input
                //Console.WriteLine("Erroneous input\n Please try again");
                //Environment.Exit(1); return true;
            }

        }



        //Shuffle specifics

        public static void Fisher(Pack pack)
        {


            Card temp;//temp card object to aid in swapping cards around


            Random random = new Random();//aids in the randomness of a natural shuffle
            int n = 51;


            for (int i = 0; i < n; i++)//loop to make sure each card is iterated through

            // foreach (Card c in pack.pack)
            {

                int k = random.Next(n - 1);
                temp = pack.pack[i];//remove the first value
                pack.pack[i] = pack.pack[k];//change the first value with a random instance
                pack.pack[k] = temp;// integrate the original card removed




            }

            //test to check they are shuffled
            foreach (Card d in pack.pack)
            {

                Console.WriteLine(d.aface);
            }
        }


        public static void Riffle(Pack pack)
        {
            //List var to hold half of the pack each
            List<Card> TempPackA = new List<Card>();
            List<Card> TempPackB = new List<Card>();

            for (int i = 0; i < 26; i++)
                TempPackA.Add(pack.pack[i]);//adding the first half

            for (int i = 26; i < 52; i++)
                TempPackB.Add(pack.pack[i]);//adding the second half
            pack.pack.Clear();//emptying the deck
            for (int i = 0; i < 52; i++)
            {
                Random random = new Random();
                Random rIndex = new Random();
                int rDex = rIndex.Next(0, 26);
                int rNum = random.Next(0, 26);
                //alternating adding to pack from one list the from the other like the natural shuffle
                pack.pack.Add(TempPackA[rDex]);//adding the first half back to the pack randomly 
                pack.pack.Add(TempPackB[rNum]);//adding the second half back to the pack randomly
            }




        }

        //Dealing methods
        public static Card Deal(Pack pack)
        {
            //Deals one card
            Card card;
            card = pack.pack[0];
            Console.WriteLine(card.aface);
            return card;
        }
        public static List<Card> DealCard(int amount, Pack pack)
        {


            //Deals the number of cards specified by 'amount'
            int Inx = 0;

            for (int i = 0; i < amount; i++)
            {

                playerHand.Add(pack.pack[Inx]);
                Console.WriteLine(playerHand[Inx].aface);
                Inx++;

            }
            return playerHand;
        } 



        public static List<Card> DealHand(Pack pack)
            //Decided due to code review to add this

        {
            try//try to catch erroneous input
            {
                Console.WriteLine("Please enter how many cards you would like");
                xAmount = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < xAmount; i++)
                {
                    if (xAmount <= 0 || xAmount >= 53)//to make sure the user cant select more cards than the deck holds
                    {

                        Console.WriteLine("Please enter a valid number");
                        DealHand(pack);//loop to deal method if invalid
                    }
                    else if (pack.pack.Count == 0)//back up to check if pack is empty. Potentially useful
                                                  //for later iterations with more than one player



                    { Console.WriteLine("out of cards"); break; }//exit loop for now

                    else
                    {
                        hand.Add(pack.pack[i]);//adding i index to hand
                        Console.WriteLine(hand[i].aface);
                       //removed so not to interfere with othe process  pack.pack.Remove(pack.pack[i]);
                        
                    }
                    
                }
                return hand;
            }
            catch (Exception ex)//catching exceptio 
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please try again as you have entered an invalid amount");
                return DealHand(pack);//loop to deal hand
                
            }

            }
        }
    }
          
            
     
        
        
   

    
  
