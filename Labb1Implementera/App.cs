using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb1Implementera.Models;
using Labb1Implementera.Navigations;
using Labb1Implementera.Services;

namespace Labb1Implementera
{
    internal class App
    {
        private readonly UserManager _userManager;
        private readonly Menu _menu;
        private bool _isRunning;
        private bool _isAuthenticated;
        private User _currentUser;

        public App()
        {
            _userManager = UserManager.Instance;
            _menu = new Menu();
            _isRunning = true;
            _isAuthenticated = false;
            _currentUser = null;
        }

        public void Run()
        {
            try
            {                
                while (_isRunning)
                {
                    if (_isAuthenticated)
                    {
                        _menu.DisplayUserMenu(_currentUser);
                        HandleUserMenuChoice();
                    }
                    else
                    {
                        _menu.DisplayMainMenu();
                        HandleMainMenuChoice();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void HandleMainMenuChoice()
        {
            switch (_menu.SelectedOption)
            {
                case 0:
                    HandleLogin();
                    break;
                case 1:
                    _userManager.Register();
                    break;
                case 2:
                    _isRunning = false;
                    Console.Write("\nClosing app... Please wait.");
                    Thread.Sleep(3000);
                    Console.Clear();
                    Console.WriteLine(Logo.Instance.GetLogo());
                    Console.Write("Welcome back and have a great day!\n");                    
                    break;
            }
        }

        private void HandleUserMenuChoice()
        {
            switch (_menu.SelectedOption)
            {
                case 0:
                    _currentUser.AddRunEntry();
                    break;                    
                case 1:
                    _currentUser.PrintUserRunEntries();
                    break;
                case 2:
                    _currentUser.PrintRunnersData();
                    break;
                case 3:
                    _isAuthenticated = false;
                    _currentUser = null;
                    Console.Write("\nLogging out... Please wait.");
                    Thread.Sleep(2000);
                    break;
            }
        }

        private void HandleLogin()
        {
            Console.CursorVisible = true;

            do
            {
                Console.Clear();
                Console.WriteLine(Logo.Instance.GetLogo());
                string email = PromptForInput("Email: ");
                string password = MaskPassword();

                User authenticatedUser = _userManager.AuthenticateUser(email, password);

                if (authenticatedUser != null)
                {
                    _isAuthenticated = true;
                    _currentUser = authenticatedUser;
                }
                else
                {
                    Console.Write("\nLogin failed. Press ENTER and try again.");
                    Console.ReadKey();
                }

            } while (!_isAuthenticated);            
        }

        private string PromptForInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine()!;
        }

        private string MaskPassword()
        {
            string password = "";
            char maskChar = '*';
            Console.Write("Password: ");

            while (true)
            {                
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (password.Length > 0)
                    {
                        password = password.Remove(password.Length - 1);
                        Console.Write("\b \b"); // Delete the latest char
                    }
                }
                else
                {
                    password += keyInfo.KeyChar;
                    Console.Write(maskChar);
                }                
            }
            
            return password;
        }    
    }
}
