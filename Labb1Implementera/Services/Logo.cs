using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1Implementera.Services
{
    /// <summary>
    /// Represents a Singleton instance of a logo generator. This class ensures that only one instance of Logo can
    /// exist throughout the application. The static property Instance provides access to the single instance of Logo.
    /// </summary>
    internal sealed class Logo
    {
        private static readonly Logo _instance = new();

        static Logo() { }

        private Logo() { }

        public static Logo Instance => _instance;

        public string GetLogo()
        {
            return @"
  _______             _      _____                             
 |__   __|           | |    |  __ \                            
    | |_ __ __ _  ___| | __ | |__) _   _ _ __  _ __   ___ _ __ 
    | | '__/ _` |/ __| |/ / |  _  | | | | '_ \| '_ \ / _ | '__|
    | | | | (_| | (__|   <  | | \ | |_| | | | | | | |  __| |   
    |_|_|  \__,_|\___|_|\_\ |_|  \_\__,_|_| |_|_| |_|\___|_|   
                                                               
                                                               
";
        }
    }
}
