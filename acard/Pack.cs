///OOP assignment 1///
//class to create the deck of cards
////

namespace CMP1903M_A01_2223
{
    class Pack
    {



        public List<Card> pack = new List<Card>();
        public static List<Card> playerHand = new List<Card>();
        public static List<Card> shuffledPack = new List<Card>();

        //main constructor
        public Pack()
        {


            for (int i = 0; i < 4; i++)
            {
                for (int j = 2; j < 15; j++)
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

            foreach (Card c in pack.pack)
            {
                Console.Write(" " + c.aface + "\t" + "\t" + "\t" + "\t");

            }
            Console.WriteLine("\n\n");
        }

        //Decide which shuffle to perform and validate input
        public static bool ShuffleCardPack( int typeOfShuffle, Pack pack)
        {
    

            if (typeOfShuffle == 1)
            {



                Console.WriteLine("Fisher shuffle");
                Console.WriteLine("\n");
                Fisher(pack);
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
                foreach (Card c in pack.pack)
                {
                    Console.WriteLine(c.aface);
                }
                Console.WriteLine("\n");
                return true;
            }
            //covers non valid int input
            else
            {
                Console.WriteLine("Erroneous input\n Goodbye");
                Environment.Exit(1); return true;
            }
           
        }



        //Shuffle specifics

        public static void Fisher(Pack pack)
        {


            Card temp;


            Random random = new Random();
            int n = 51;


            for (int i = 0; i < n; i++)

            // foreach (Card c in pack.pack)
            {

                int k = random.Next(n - 1);
                temp = pack.pack[i];
                pack.pack[i] = pack.pack[k];
                pack.pack[k] = temp;




            }
            foreach (Card d in pack.pack)
            {

                Console.WriteLine(d.aface);
            }
        }


        public static void Riffle(Pack pack)
        {

            List<Card> TempPackA = new List<Card>();
            List<Card> TempPackB = new List<Card>();

            for (int i = 0; i < 26; i++)
                TempPackA.Add(pack.pack[i]);

            for (int i = 26; i < 52; i++)
                TempPackB.Add(pack.pack[i]);
            pack.pack.Clear();
            for (int i = 0; i < 52; i++)
            {
                Random random = new Random();
                Random rIndex = new Random();
                int rDex = rIndex.Next(0, 26);
                int rNum = random.Next(0, 26);
                pack.pack.Add(TempPackA[rDex]);
                pack.pack.Add(TempPackB[rNum]);
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

            int Ind = 0;
            for (int i = 0; i < amount; i++)
            {

                playerHand.Add(pack.pack[Ind]);
                Console.WriteLine(playerHand[Ind].aface);
                Ind++;

            }
            return playerHand;
        }
    }
}           
            
     
        
        
   

    
  
