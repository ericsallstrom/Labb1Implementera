using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb1Implementera.Models;
using Labb1Implementera.Services;

namespace Labb1Implementera.Navigations
{
    internal class Menu
    {
        public int SelectedOption { get; private set; }    

        private void InitializeMenu(string prompt, string[] menuOptions)
        {
            Navigation nav = new()
            {
                Prompt = prompt,
                MenuOptions = menuOptions
            };
            SelectedOption = nav.GetMenuChoice();
        }

        public void DisplayMainMenu()
        {
            string prompt = Logo.Instance.GetLogo();
            string[] menuOptions =
            {
                "Log in",
                "Register",
                "Exit"
            };
            InitializeMenu(prompt, menuOptions);
        }

        public void DisplayUserMenu(User user)
        {
            string prompt = $"{Logo.Instance.GetLogo()}\nWelcome {user.FirstName} {user.LastName}!\n";
            string[] menuOptions =
            {
                "Add run entry",
                "Run entries history",
                "Running data",
                "Log out"
            };
            InitializeMenu(prompt, menuOptions);
        }

        public void DisplayWorkoutMenu(string prompt)
        {
            string[] menuOptions = Enum.GetNames(typeof(WorkoutType));
            InitializeMenu(prompt, menuOptions);
        }
    }
}
