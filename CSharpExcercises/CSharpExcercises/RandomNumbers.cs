using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExcercises
{
    class RandomNumbers
    {
        public int Random()
        {
            //List<int> randomNumbers = new List<int>();
            var randomNumber = new Random();
            int number =  randomNumber.Next(0, 100);

            //randomNumbers.Add(number);
            //Console.WriteLine(randomNumbers[0]);

            return number;
        }

        public void Compare(int deflautNumber, int userNumber, int randomPCNumber)
        {
            Console.WriteLine("Deflaut number: {0}\n\nComputer's choise: {1}\nYour choice: {2}\n\n", deflautNumber, randomPCNumber, userNumber);

            int userNumberDifference = Math.Abs(deflautNumber - userNumber);
            int PCNumberDifference = Math.Abs(deflautNumber - randomPCNumber);

            if (userNumberDifference < PCNumberDifference)
                Console.WriteLine("You win!");
            else if (userNumberDifference == PCNumberDifference)
                Console.WriteLine("Draw!");
            else
                Console.WriteLine("You lost ;(((");
        }

        public int UserNumber()
        {
            
            Console.WriteLine("Enter your number between 0 - 100, and check who was closer");

            UserNumber:
            int userNumber = Convert.ToInt32(Console.ReadLine());
            if (userNumber < 0 || userNumber > 100)
            {
                Console.WriteLine("Wrong number! Try again...");
                goto UserNumber;
            }
            return userNumber;
        }

        static void Main(string[] args)
        {
            var random = new RandomNumbers();

            Start:
            Console.WriteLine("Welcome in the game, where You and the computer try to guess mistery number.");
            Console.WriteLine("TEST YOUR LUCK!\n");

            int deflautNumber = random.Random();
            int userNumber = random.UserNumber();
            int randomPCNumber = random.Random();

            random.Compare(deflautNumber, userNumber, randomPCNumber);

            Console.WriteLine("Do you want to play again? Y/N");
            Sign:
            string sign = Convert.ToString(Console.ReadLine());
            if (sign == "y" || sign == "Y")
            {
                Console.Clear();
                goto Start;
            }
            else if(sign != "n" && sign != "N")
            {
                Console.WriteLine("Type Y/N!!!!!!1");
                goto Sign;
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
