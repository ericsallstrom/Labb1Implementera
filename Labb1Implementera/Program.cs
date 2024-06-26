namespace Labb1Implementera
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 
             * Jag har skapat en fitness app där användaren kan fylla i data efter att ha genomfört en löprunda, maraton, etc.
             * De designmönster som jag har implmenterat i min kod är Factory Method, Singleton och Adapter. 
             */

            App app = new();
            app.Run();
        }
    }
}
