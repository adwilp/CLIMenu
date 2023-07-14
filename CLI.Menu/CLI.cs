namespace CLI.Menu
{
    public static class CLI
    {
        private const int INIT_INDEX = 0;
        private const int START_INDEX_Y = 8;
        private const int START_INDEX_X = 10;
        private const string SELECTOR = "X";

        public static int SelectOption(params string[] items)
        {
            PrintMenu(items);

            var option = ChooseOption(items.Length);

            Console.Clear();

            return option;
        }

        private static int ChooseOption(int optionCount)
        {
            bool selected = false;
            int selectedIndex = INIT_INDEX;

            WriteAt(SELECTOR, INIT_INDEX, selectedIndex);

            do
            {
                ConsoleKeyInfo result = Console.ReadKey(true);
                int currentIndex = selectedIndex;

                switch (result.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = MoveUp(currentIndex, selectedIndex, optionCount);
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex = MoveDown(currentIndex, selectedIndex, optionCount);
                        break;
                    case ConsoleKey.Enter:
                        selected = true;
                        break;
                    default:
                        break;
                }

            } while (!selected);

            return selectedIndex;
        }

        private static int MoveUp(int currentIndex, int selectedIndex, int optionCount)
        {
            if (selectedIndex == INIT_INDEX)
            {
                selectedIndex = optionCount - 1;
            }
            else
            {
                selectedIndex--;
            }

            MoveCursor(currentIndex, selectedIndex);

            return selectedIndex;
        }

        private static int MoveDown(int currentIndex, int selectedIndex, int optionCount)
        {
            if (selectedIndex == optionCount - 1)
            {
                selectedIndex = INIT_INDEX;
            }
            else
            {
                selectedIndex++;
            }

            MoveCursor(currentIndex, selectedIndex);

            return selectedIndex;
        }

        private static void MoveCursor(int currentIndex, int newIndex)
        {
            WriteAt(" ", INIT_INDEX, currentIndex);
            WriteAt(SELECTOR, INIT_INDEX, newIndex);
            SetCursor(INIT_INDEX, newIndex);
        }

        private static void WriteAt(string s, int x, int y)
        {
            try
            {
                SetCursor(x, y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        private static void SetCursor(int x, int y)
        {
            Console.SetCursorPosition(START_INDEX_X + x, START_INDEX_Y + y);
        }

        private static void PrintMenu(string[] items)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("   /////////////////////////////////////////////");
            Console.WriteLine("   /////////////////////////////////////////////");
            Console.WriteLine("   ///// Was möchtest du als nächstes machen?");
            Console.WriteLine("   /////////////////////////////////////////////");
            Console.WriteLine("   /////////////////////////////////////////////");
            Console.WriteLine();

            foreach (var item in items)
            {
                Console.WriteLine($"         [ ] - {item}");
            }
        }
    }
}
