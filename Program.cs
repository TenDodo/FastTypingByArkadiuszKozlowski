using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;
using System.Windows.Forms;


namespace Fast_Typing_by_Arkadiusz_Kozłowski
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Start();
        }
        public const string textDefault = "abcdefghijklmnopqrstuvwxyz";
        public const string textPolish = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";
        public const string numbers = "0123456789";
        public static bool includeNumbers = false;
        public static string selectedText = textDefault;
        public static char[] selectedTextCharArray = selectedText.ToCharArray();

        public static void Start()
        {
        startstart:
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Welcome to Fast Typing by Arkadiusz Kozłowski");
            Console.WriteLine();
            Console.WriteLine("S - Start practice | O - Options | H - How to type fast | Q - Exit program");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.S:
                    SelectMode();
                    break;
                case ConsoleKey.O:
                    Options();
                    break;
                case ConsoleKey.H:
                    Process.Start("https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi.pinimg.com%2Foriginals%2F00%2F84%2F75%2F008475696645b6d9b0810f4c2609626e.jpg&f=1&nofb=1");
                    goto startstart;
                case ConsoleKey.Q:
                    break;
                default:
                    goto startstart;
            }
        }

        public static void SelectMode()
        {
        startSelectMode:
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Select practice");
            Console.WriteLine();
            Console.WriteLine("1. Default");
            Console.WriteLine();
            Console.WriteLine("2. Continuous text");
            Console.WriteLine();
            Console.WriteLine("3. Default (import text from file)");
            Console.WriteLine();
            Console.WriteLine("4. Continuous text (import text from file)");
            Console.WriteLine();
            Console.WriteLine("1-4 - Start | O - Options | B - Back");
            string yourChars = "";
            for (int i = 0; i < selectedTextCharArray.Length; i++)
            {
                yourChars += selectedTextCharArray[i];
                if (i != selectedTextCharArray.Length - 1)
                {
                    yourChars += ", ";
                }
            }
            Console.WriteLine("\n\n\n\n");
            Console.Write("Your character set: " + yourChars);
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    defaultPractice();
                    break;
                case ConsoleKey.D2:
                    continuousText();
                    break;
                case ConsoleKey.D3:
                    defaultPracticeImport();
                    break;
                case ConsoleKey.D4:
                    continuousTextImport();
                    break;
                case ConsoleKey.B:
                    Start();
                    break;
                case ConsoleKey.O:
                    Options();
                    break;
                default:
                    goto startSelectMode;
            }
        }

        public static void Options()
        {
        startoptions:
            Console.Clear();
            string letters = "null";
            Console.WriteLine();
            Console.WriteLine("Options");
            switch (selectedText)
            {
                case textDefault:
                    letters = "Character set: Default";
                    break;
                case textDefault + numbers:
                    letters = "Character set: Default";
                    break;
                case textPolish:
                    letters = "Character set: Polish";
                    break;
                case textPolish + numbers:
                    letters = "Character set: Polish";
                    break;
            }
            Console.WriteLine();
            Console.WriteLine(letters);
            Console.WriteLine("Include numbers: " + includeNumbers);
            Console.WriteLine();
            Console.WriteLine("1 - Change character set | 2 - Are numbers included? | B - Back");
            string yourChars = "";
            for (int i = 0; i < selectedTextCharArray.Length; i++)
            {
                yourChars += selectedTextCharArray[i];
                if (i != selectedTextCharArray.Length - 1)
                {
                    yourChars += ", ";
                }
            }
            Console.WriteLine("\n\n\n\n");
            Console.Write("Your character set: " + yourChars);
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    if (selectedText == textDefault)
                    {
                        selectedText = textPolish;
                        selectedTextCharArray = selectedText.ToCharArray();
                    }
                    else if (selectedText == textPolish)
                    {
                        selectedText = textDefault;
                        selectedTextCharArray = selectedText.ToCharArray();
                    }
                    else if (selectedText == textDefault + numbers)
                    {
                        selectedText = textPolish + numbers;
                        selectedTextCharArray = selectedText.ToCharArray();
                    }
                    else if (selectedText == textPolish + numbers)
                    {
                        selectedText = textDefault + numbers;
                        selectedTextCharArray = selectedText.ToCharArray();
                    }
                    goto startoptions;
                case ConsoleKey.D2:
                    if (includeNumbers)
                    {
                        if (selectedText.Contains(textDefault))
                        {
                            selectedText = textDefault;
                        }
                        else
                        {
                            selectedText = textPolish;
                        }
                        includeNumbers = false;
                    }
                    else
                    {
                        selectedText += numbers;
                        includeNumbers = true;
                    }
                    selectedTextCharArray = selectedText.ToCharArray();
                    goto startoptions;
                case ConsoleKey.B:
                    Start();
                    break;
                default:
                    goto startoptions;
            }
        }
        public static void defaultPractice()
        {
        startDefaultPractice:
            Stopwatch time = new Stopwatch();
            int miss = 0;
            Random rand = new Random();
            int number = 10;
            Console.Clear();
            Console.WriteLine();
            Console.Write("Choose the number of characters: ");
            try
            {
                number = int.Parse(Console.ReadLine());
            }
            catch
            {
                goto startDefaultPractice;
            }
            char[] currentChars = new char[number];
            for (int i = 0; i < currentChars.Length; i++)
            {
                currentChars[i] = selectedTextCharArray[rand.Next(0, selectedTextCharArray.Length)];
            }
            Console.Clear();
            Console.WriteLine("Press any key to start!");
            Console.ReadKey();
            time.Start();
            for (int i = 0; i < currentChars.Length; i++)
            {
            missLoop:
                Console.Clear();

                Console.Write(currentChars[i]);
                if (Console.ReadKey().KeyChar != currentChars[i])
                {
                    miss += 1;
                    goto missLoop;
                }
            }
            time.Stop();
            Console.Clear();
            Console.WriteLine();
            char[] timeEl = time.ElapsedMilliseconds.ToString().ToCharArray();
            string timeElapsed = "";
            for (int i = 0; i < timeEl.Length; i++)
            {
                if (i == timeEl.Length - 3)
                {
                    timeElapsed += ",";
                }
                timeElapsed += timeEl[i];
            }
            string yourChars = "";
            for (int i = 0; i < currentChars.Length; i++)
            {
                yourChars += currentChars[i];
                if (i != currentChars.Length - 1)
                {
                    yourChars += ", ";
                }
            }
            Console.WriteLine("Total characters: " + number);
            Console.WriteLine("Misses: " + miss);
            Console.WriteLine("Time: " + timeElapsed + " seconds");
            Console.WriteLine();
            Console.WriteLine("R - Retry | O - Options | B - Back");
            Console.WriteLine("\n\n\n\n");
            Console.Write("Characters: " + yourChars);
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.R:
                    goto startDefaultPractice;
                case ConsoleKey.O:
                    Options();
                    break;
                case ConsoleKey.B:
                    SelectMode();
                    break;
                default:
                    SelectMode();
                    break;
            }
        }


        public static void continuousText()
        {
        startContinuousText:
            Stopwatch time = new Stopwatch();
            int miss = 0;
            Random rand = new Random();
            int number = 10;
            Console.Clear();
            Console.WriteLine();
            Console.Write("Choose the number of characters: ");
            try
            {
                number = int.Parse(Console.ReadLine());
            }
            catch
            {
                goto startContinuousText;
            }
            char[] currentChars = new char[number];

            for (int i = 0; i < currentChars.Length; i++)
            {
                currentChars[i] = selectedTextCharArray[rand.Next(0, selectedTextCharArray.Length)];
            }
            Console.Clear();
            Console.WriteLine("Press any key to start!");
            Console.ReadKey();
            time.Start();
            for (int i = 0; i < currentChars.Length; i++)
            {
            missLoop:
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;
                for (int j = 0; j < currentChars.Length; j++)
                {
                    Console.Write(" ");
                    if (i == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(currentChars[j]);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else
                    {
                        Console.Write(currentChars[j]);
                    }

                }
                if (Console.ReadKey().KeyChar != currentChars[i])
                {
                    miss += 1;
                    goto missLoop;
                }
            }
            time.Stop();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine();
            char[] timeEl = time.ElapsedMilliseconds.ToString().ToCharArray();
            string timeElapsed = "";
            for (int i = 0; i < timeEl.Length; i++)
            {
                if (i == timeEl.Length - 3)
                {
                    timeElapsed += ",";
                }
                timeElapsed += timeEl[i];
            }
            string yourChars = "";
            for (int i = 0; i < currentChars.Length; i++)
            {
                yourChars += currentChars[i];
                if (i != currentChars.Length - 1)
                {
                    yourChars += ", ";
                }
            }
            Console.WriteLine("Total characters: " + number);
            Console.WriteLine("Misses: " + miss);
            Console.WriteLine("Time: " + timeElapsed + " seconds");
            Console.WriteLine();
            Console.WriteLine("R - Retry | O - Options | B - Back");
            Console.WriteLine("\n\n\n\n");
            Console.Write("Characters: " + yourChars);
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.R:
                    goto startContinuousText;
                case ConsoleKey.O:
                    Options();
                    break;
                case ConsoleKey.B:
                    SelectMode();
                    break;
                default:
                    SelectMode();
                    break;
            }
        }
        [STAThread]
        public static void defaultPracticeImport()
        {
        startDefaultPractice:
            Console.Clear();
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "File to open:";
            string text = "";
            if (open.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(open.FileName))
                {
                    text = sr.ReadToEnd();
                    text = text.Replace("\n", " ");
                    sr.Close();
                }
            }
            else
            {
                SelectMode();
            }
            Stopwatch time = new Stopwatch();
            int miss = 0;
            char[] currentChars = new char[text.Length];
            currentChars = text.ToCharArray();
            Console.Clear();
            Console.WriteLine("Press any key to start!");
            Console.ReadKey();
            time.Start();
            for (int i = 0; i < currentChars.Length; i++)
            {
            missLoop:
                Console.Clear();
                switch (currentChars[i] == ' ')
                {
                    case true:
                        Console.Write(@"[space]");
                        break;
                    case false:
                        Console.Write(currentChars[i]);
                        break;
                }
                
                if (Console.ReadKey().KeyChar != currentChars[i])
                {
                    miss += 1;
                    goto missLoop;
                }
            }
            time.Stop();
            Console.Clear();
            Console.WriteLine();
            char[] timeEl = time.ElapsedMilliseconds.ToString().ToCharArray();
            string timeElapsed = "";
            for (int i = 0; i < timeEl.Length; i++)
            {
                if (i == timeEl.Length - 3)
                {
                    timeElapsed += ",";
                }
                timeElapsed += timeEl[i];
            }
            string yourChars = "";
            for (int i = 0; i < currentChars.Length; i++)
            {
                yourChars += currentChars[i];
                if (i != currentChars.Length - 1)
                {
                    yourChars += ", ";
                }
            }
            Console.WriteLine("Total characters: " + text.Length);
            Console.WriteLine("Misses: " + miss);
            Console.WriteLine("Time: " + timeElapsed + " seconds");
            Console.WriteLine();
            Console.WriteLine("R - Retry | O - Options | B - Back");
            Console.WriteLine("\n\n\n\n");
            Console.Write("Characters: " + yourChars);
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.R:
                    goto startDefaultPractice;
                case ConsoleKey.O:
                    Options();
                    break;
                case ConsoleKey.B:
                    SelectMode();
                    break;
                default:
                    SelectMode();
                    break;
            }
        }



        [STAThread]
        public static void continuousTextImport()
        {
        startContinuousText:
            Console.Clear();
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "File to open:";
            string text = "";
            if (open.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(open.FileName))
                {
                    text = sr.ReadToEnd();
                    text = text.Replace("\n", " ");
                    sr.Close();
                }
            }
            else
            {
                SelectMode();
            }
            Stopwatch time = new Stopwatch();
            int miss = 0;
            char[] currentChars = new char[text.Length];
            currentChars = text.ToCharArray();
            Console.Clear();
            Console.WriteLine("Press any key to start!");
            Console.ReadKey();
            time.Start();
            for (int i = 0; i < currentChars.Length; i++)
            {
            missLoop:
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;
                for (int j = 0; j < currentChars.Length; j++)
                {
                    Console.Write(" ");
                    if (i == j)
                    {
                        switch (currentChars[j] == ' ')
                        {
                            case true:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.Write(currentChars[j]);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;
                            case false:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(currentChars[j]);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                break;
                        }
                        
                    }
                    else
                    {
                        Console.Write(currentChars[j]);
                    }

                }
                if (Console.ReadKey().KeyChar != currentChars[i])
                {
                    miss += 1;
                    goto missLoop;
                }
            }
            time.Stop();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine();
            char[] timeEl = time.ElapsedMilliseconds.ToString().ToCharArray();
            string timeElapsed = "";
            for (int i = 0; i < timeEl.Length; i++)
            {
                if (i == timeEl.Length - 3)
                {
                    timeElapsed += ",";
                }
                timeElapsed += timeEl[i];
            }
            string yourChars = "";
            for (int i = 0; i < currentChars.Length; i++)
            {
                yourChars += currentChars[i];
                if (i != currentChars.Length - 1)
                {
                    yourChars += ", ";
                }
            }
            Console.WriteLine("Total characters: " + text.Length);
            Console.WriteLine("Misses: " + miss);
            Console.WriteLine("Time: " + timeElapsed + " seconds");
            Console.WriteLine();
            Console.WriteLine("R - Retry | O - Options | B - Back");
            Console.WriteLine("\n\n\n\n");
            Console.Write("Characters: " + yourChars);
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.R:
                    goto startContinuousText;
                case ConsoleKey.O:
                    Options();
                    break;
                case ConsoleKey.B:
                    SelectMode();
                    break;
                default:
                    SelectMode();
                    break;
            }
        }
    }
}
