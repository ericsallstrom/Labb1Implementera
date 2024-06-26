using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1Implementera.Navigations
{
    internal class Navigation
    {
        // Fields that define keys for navigation
        private const ConsoleKey _keyUp = ConsoleKey.UpArrow;
        private const ConsoleKey _keyDown = ConsoleKey.DownArrow;
        private const ConsoleKey _keySelect = ConsoleKey.Enter;

        // Properties for presenting, controlling and retrieving menu information
        public string Prompt { get; set; }
        public string[] MenuOptions { get; set; }
        private ConsoleKeyInfo KeyInfo { get; set; }
        private ConsoleKey KeyPressed { get; set; }
        private int SelectedIndex { get; set; }

        public Navigation()
        {
            Prompt = string.Empty;
            MenuOptions = Array.Empty<string>();
            SelectedIndex = 0;
        }

        public int GetMenuChoice()
        {
            do
            {
                DisplayMenu();
                KeyInfo = Console.ReadKey();
                KeyPressed = KeyInfo.Key;

                switch (KeyPressed)
                {
                    case _keyUp:
                        SelectedIndex = (SelectedIndex - 1 + MenuOptions.Length) % MenuOptions.Length;
                        break;
                    case _keyDown:
                        SelectedIndex = (SelectedIndex + 1 + MenuOptions.Length) % MenuOptions.Length;
                        break;
                }
            } while (KeyPressed != _keySelect); // Continue loop until ENTER key is pressed
            return SelectedIndex;
        }

        private void DisplayOption(string currentMenuOption, int menuOptionIndex)
        {
            string prefix;

            if (SelectedIndex == menuOptionIndex)
            {
                prefix = ">";
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
            }
            else
            {
                prefix = " ";
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.WriteLine($"{prefix} {currentMenuOption}");
        }

        private void DisplayMenu()
        {
            Console.Clear();
            Console.CursorVisible = false;
            StringBuilder menuBuilder = new();
            menuBuilder.AppendLine(Prompt);

            Console.Write(menuBuilder);

            for (int i = 0; i < MenuOptions.Length; i++)
            {
                string currentMenuOption = MenuOptions[i];
                DisplayOption(currentMenuOption, i);
            }
            Console.ResetColor();
        }
    }
}
