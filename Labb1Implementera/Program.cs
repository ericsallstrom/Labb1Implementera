namespace Labb1Implementera
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * I have created a fitness app where the user can input data after completing a run, marathon, etc.
             * The design patterns I have implemented in my code are Factory Method, Singleton, and Adapter.
             */

            App app = new();
            app.Run();
        }
    }
}
