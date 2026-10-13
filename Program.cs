using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horoscope.C_
{
    class Program
    {
        static string[] signs =
        {"Capricorn","Aquarius","Pisces","Aries","Taurus","Gemini","Cancer","Leo","Virgo","Libra","Scorpio","Sagittarius"};

        static string[] stones =
        {"Garnet","Amethyst","Aquamarine","Diamond","Emerald","Pearl","Ruby","Peridot","Sapphire","Opal","Topaz","Turquoise"};

        static string[] elements =
        {
         "Earth","Air","Water","Fire",
         "Earth","Air","Water","Fire",
         "Earth","Air","Water","Fire"
        };

        static string[] personalities =
        {
        "Responsible and Disciplined",
        "Deep thinker and helpful",
        "Kind and caring",
        "Passionate and determined",
        "Practical and resourceful",
        "Curious and humorous",
        "Intelligent and strong-willed",
        "Idealistic and courageous",
        "Efficient and calm",
        "Wise and friendly",
        "Emotional and determined",
        "Fair-minded and intelligent"
    };

        static string[] predictions =
        {
        "Challenges and opportunities",
        "Personal development and financial gains",
        "Career growth through persistence",
        "A year of transition",
        "Balance and growth",
        "Dynamic transitions",
        "Potential career changes",
        "Opportunities and challenges",
        "Steady growth and achievements",
        "Prosperity and balance",
        "Transformation and opportunities",
        "Growth and new opportunities"
    };

        static void Main()
        {
            Console.Title = "Horoscope System";

            while (true)
            {
                ColorLine("\n===== HOROSCOPE SYSTEM =====", ConsoleColor.Cyan);

                Console.WriteLine("\n1. Check Your Horoscope");
                Console.WriteLine("2. View All Zodiac Signs");
                Console.WriteLine("3. Exit");

                Console.Write("Enter your choice: ");
                int choice;

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    ColorLine("Enter a valid number!", ConsoleColor.Red);
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        RunHoroscope();
                        break;

                    case 2:
                        DisplaySigns();
                        break;

                    case 3:
                        ColorLine("\nThank you for using Horoscope System!", ConsoleColor.Green);
                        return;

                    default:
                        ColorLine("Invalid choice!", ConsoleColor.Red);
                        continue;
                }
            }
        }



        static void RunHoroscope()
        {
            int month, day;

            Console.Write("\nEnter birth month (1-12): ");
            month= Convert.ToInt32(Console.ReadLine());

            Console.Write("\nEnter birth day: ");
            day= Convert.ToInt32(Console.ReadLine());

            int maxDay;

            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    maxDay = 31;
                    break;

                case 4:
                case 6:
                case 9:
                case 11:
                    maxDay = 30;
                    break;

                case 2:
                    maxDay = 29;
                    break;

                default:
                    ColorLine("\nInvalid birth month!", ConsoleColor.Red);
                    return;
            }

            if (day < 1 || day > maxDay)
            {
                ColorLine("\nInvalid birth day!", ConsoleColor.Red);
                return;
            }

            int index = GetZodiacIndex(month, day);

            string monthName = GetMonthName(month);

            ColorLine("\nBirth Month: " + monthName,
                      ConsoleColor.White);

            ShowHoroscope(index);
        }

        static int GetZodiacIndex(int m, int day)
        {
            if ((m == 12 && day >= 22) || (m == 1 && day <= 19))
                return 0;

            else if ((m == 1 && day >= 20) || (m == 2 && day <= 17))
                return 1;

            else if ((m == 2 && day >= 18) || (m == 3 && day <= 19))
                return 2;

            else if ((m == 3 && day >= 20) || (m == 4 && day <= 19))
                return 3;

            else if ((m == 4 && day >= 20) || (m == 5 && day <= 20))
                return 4;

            else if ((m == 5 && day >= 21) || (m == 6 && day <= 20))
                return 5;

            else if ((m == 6 && day >= 21) || (m == 7 && day <= 22))
                return 6;

            else if ((m == 7 && day >= 23) || (m == 8 && day <= 22))
                return 7;

            else if ((m == 8 && day >= 23) || (m == 9 && day <= 22))
                return 8;

            else if ((m == 9 && day >= 23) || (m == 10 && day <= 22))
                return 9;

            else if ((m == 10 && day >= 23) || (m == 11 && day <= 21))
                return 10;

            else
                return 11;
        }

        static string GetMonthName(int month)
        {
            switch (month)
            {
                case 1: return "January";
                case 2: return "February";
                case 3: return "March";
                case 4: return "April";
                case 5: return "May";
                case 6: return "June";
                case 7: return "July";
                case 8: return "August";
                case 9: return "September";
                case 10: return "October";
                case 11: return "November";
                case 12: return "December";
                default: return "Unknown";
            }
        }

        static void ShowHoroscope(int index)
        {
            ColorLine("Zodiac Sign: " + signs[index], ConsoleColor.Green);
            ColorLine("Birthstone: " + stones[index], ConsoleColor.Yellow);
            ColorLine("Element: " + elements[index], ConsoleColor.Cyan);
            ColorLine("Personality: " + personalities[index], ConsoleColor.Magenta);
            ColorLine("Prediction: " + predictions[index],ConsoleColor.White);

            Console.ResetColor();
        }

        static void DisplaySigns()
        {
            Console.WriteLine("\nAvailable Zodiac Signs:");

            for (int i = 0; i < signs.Length; i++)
            {
                Console.Write((i + 1) + ". ");
                ColorLine(signs[i], ConsoleColor.Green);
            }

            Console.WriteLine("\nZodiac Elements:");

            foreach (string element in elements)
            {
                Console.WriteLine(element);
            }
        }

        static void ColorLine(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}