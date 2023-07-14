namespace CLI.Menu
{
    public static class CLI
    {
        private const int START_INDEX_Y = 8;
        private const int START_INDEX_X = 10;

        public static int SelectOption(params string[] items)
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

            var option = ChooseOption(items.Length);

            Console.Clear();

            return option;
        }

        private static int ChooseOption(int optionCount)
        {
            bool selected = false;
            int selectedIndex = 0;

            WriteAt("X", 0, selectedIndex);

            do
            {
                ConsoleKeyInfo result = Console.ReadKey(true);
                int currentIndex = selectedIndex;

                switch (result.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (selectedIndex == 0)
                        {
                            selectedIndex = optionCount - 1;
                        }
                        else
                        {
                            selectedIndex--;
                        }
                        MoveCursor(currentIndex, selectedIndex);
                        break;
                    case ConsoleKey.DownArrow:
                        if (selectedIndex == optionCount - 1)
                        {
                            selectedIndex = 0;
                        }
                        else
                        {
                            selectedIndex++;
                        }

                        MoveCursor(currentIndex, selectedIndex);
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

        private static void MoveCursor(int currentIndex, int newIndex)
        {
            WriteAt(" ", 0, currentIndex);
            WriteAt("X", 0, newIndex);
            SetCursor(0, newIndex);
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
    }
}
