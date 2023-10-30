using Microsoft.VisualBasic;
using System.Collections.Immutable;
using System.Diagnostics;

namespace JoeMckee
{
    public struct Contestants
    {
        public string lastname;
        public string firstname;
        public string interest;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Contestants[] contestants = new Contestants[20];
            contestants = GenerateContestants();
            Menu(contestants);
        }

        static Contestants[] GenerateContestants()
        {
            StreamReader sr = new StreamReader(@"H:\DealOrNoDeal.txt");
            Contestants[] contestants = new Contestants[19];
            for (int i = 0; i < contestants.Length; i++)
            {
                contestants[i].firstname = sr.ReadLine();
                contestants[i].lastname = sr.ReadLine();
                contestants[i].interest = sr.ReadLine();
            }
            sr.Close();
            return contestants;
        }

        static void ListContestants(Contestants[] contestants)
        {
            for (int i = 0;i < contestants.Length;i++)
            {
                for (int j = 0; j < contestants.Length - 1; j++)
                {
                    if (contestants[j + 1].lastname.CompareTo(contestants[j].lastname) < 0)
                    {
                        Contestants temp = contestants[j];
                        contestants[j] = contestants[j + 1];
                        contestants[j + 1] = temp;
                    }
                    else
                    {
                        //
                    }
                }
            }
            for (int i = 0; i < contestants.Length; i++)
            {
                Console.WriteLine(contestants[i].firstname + " " + contestants[i].lastname + " " + contestants[i].interest);
                Thread.Sleep(1000);
            }
        }

        static void ChangeInterest(Contestants[] contestants)
        {
            int contestantnum;
            bool contains = false;
            int doesntcontain = 0;
            while (contains == false)
            {
                Console.WriteLine("What is the first name of the contestant?");
                string firstname = Console.ReadLine();
                for (int i = 0; i < contestants.Length; i++)
                {
                    if (contestants[i].firstname == firstname)
                    {
                        contains = true;
                        contestantnum = i;
                    }
                    else
                    {
                        doesntcontain += 1;
                        if (doesntcontain == 19)
                        {
                            Console.WriteLine("That first name is not in the dataset.");
                        }
                    }
                }
            }
            contains = false;
            while (contains == false)
            {
                Console.WriteLine("What is the last name of the contestant?");
                string lastname = Console.ReadLine();
                doesntcontain = 0;
                for (int i = 0; i < contestants.Length; i++)
                {
                    if (contestants[i].lastname == lastname)
                    {
                        contains = true;
                        contestantnum = i;
                        Console.WriteLine("What is the interest of this person?");
                        string interest = Console.ReadLine();
                        contestants[contestantnum].interest = interest;
                        // now need to save these changes to the file
                    }
                    else
                    {
                        doesntcontain += 1;
                        if (doesntcontain == 19)
                        {
                            Console.WriteLine("That last name is not in the dataset.");
                        }
                    }
                }
            }
        }

        static void Finalists(Contestants[] contestants)
        {
            int[] topten = new int[10];
            Random num = new Random();
            for (int i = 0; i < 10; i++)
            {
                int usernum = num.Next(1, 19);
                while (topten.Contains(usernum))
                {
                    usernum = num.Next(0, 19);
                }
                topten[i] = usernum;
            }
            string[] finalists = new string[10];
            for (int i = 0; i < 10; i++)
            {
                int j = topten[i];
                finalists[i] = contestants[j].firstname + " " + contestants[j].lastname + " " + " " + contestants[j].interest;
            }
            for (int i = 0;i < 10; i++)
            {
                Console.WriteLine(finalists[i]);
            }
        }

        //static void ChoosePlayer(finalists)
        //{
            
        //}

        static void Menu(Contestants[] contestants)
        {
            int num = 5;
            do
            {
                Console.WriteLine("The menu options are:\n 1\tLIST ALL CONTESTANTS\n 2\tUPDATE CONTESTANT INTEREST\n 3\tGENERATE FINALISTS\n 4\tCHOOSE PLAYER AND PLAY\n 0\tExit menu system");
                string temp = Console.ReadLine();
                Console.Clear();
                switch (temp)
                {
                    case "0":
                        Console.WriteLine("You have chosen to exit the menu");
                        num = 6;
                        break;
                    case "1":
                        ListContestants(contestants);
                        break;
                    case "2":
                        ChangeInterest(contestants);
                        break;
                    case "3":
                        int[] topten = new int[10];
                        Finalists(contestants);
                        break;
                    case "4":
                        //ChoosePlayer(finalists);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
                Thread.Sleep(100);
            }
            while (num == 5);
        }
        static void TaskFour()
        {
            Console.WriteLine("THIS IS SPARTA (task4)");
        }
    }
}