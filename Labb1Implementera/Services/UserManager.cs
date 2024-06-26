using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb1Implementera.Models;

namespace Labb1Implementera.Services
{
    /// <summary>
    /// This class implements Singleton to ensure only one instance of UserManager exists throughout the application
    /// </summary>
    internal sealed class UserManager
    {
        private static readonly UserManager _instance = new();
        private List<User> Users { get; } = [];

        static UserManager() { }

        private UserManager()
        {
            // Example initialization of a default user
            Users.Add(new User
            {
                FirstName = "Eric",
                LastName = "Sällström",
                Email = "eric",
                Password = "123"
            });
        }

        // Gets the singleton instance of the UserManager
        public static UserManager Instance => _instance;

        public User Register()
        {
            Console.Clear();
            Console.CursorVisible = true;

            Console.WriteLine($"{Logo.Instance.GetLogo()}\nYou need to enter name, email and password to register a new user.\n" +
                              $"Press ENTER after each input to proceed to the next field.\n");

            string firstName = PromptAndValidateInput("First name: ", ValidateName);
            string lastName = PromptAndValidateInput("Last name: ", ValidateName);
            string email = PromptAndValidateInput("Email: ", ValidateEmail);
            string password = PromptAndValidateInput("Password: ", ValidatePassword);

            User newUser = new()
            {
                FirstName = firstName.Trim(),
                LastName = lastName.Trim(),
                Email = email.Trim(),
                Password = password.Trim()
            };

            Users.Add(newUser);

            Console.Write("\nYou've successfully registered a new user.\nPress ENTER to return to the main menu.");
            Console.ReadKey();

            return newUser;
        }

        public User AuthenticateUser(string email, string password)
        {
            User authenticatedUser = Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (authenticatedUser != null)
            {
                return authenticatedUser;
            }

            Console.Write("\nInvalid email or password.");
            return null;
        }
      
        // Prompts the user to enter an specific input and validates it. Keeps looping until input is valid.
        private string PromptAndValidateInput(string prompt, Func<string, string> validate)
        {
            string input;
            string validationResult;

            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()!;
                validationResult = validate(input);

                if (!string.IsNullOrWhiteSpace(validationResult))
                {
                    Console.WriteLine(validationResult);
                }
            } while (!string.IsNullOrWhiteSpace(validationResult));

            return input;
        }

        private string ValidateName(string name)
        {
            return string.IsNullOrWhiteSpace(name) ? "A name input field cannot be empty. Please try again.\n" : string.Empty;
        }

        private string ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return "Email input field cannot be empty. Please try again.\n";
            }
            else if (!email.Contains('@') || !email.Contains('.'))
            {
                return "Email must contain a '@' and a domain. Please try again.\n";
            }

            return string.Empty;
        }

        private string ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return "Password input field cannot be empty. Please try again.\n";
            }
            else if (password.Length < 6)
            {
                return "Your password must be longer than 6 characters. Please try again.\n";
            }

            return string.Empty;
        }
    }
}
