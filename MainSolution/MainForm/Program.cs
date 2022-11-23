using MainForm.Products;
using MainForm.Repositories;
using MainForm.Users;

namespace MainForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            var unitOfWork = new UnitOfWork(new List<Product>()
                {
                    new Product("Cola","drinks","Kill your teeth",32.4),
                    new Product("Juice","drinks","Fresh and tasty",27.4),
                    new Product("Vodka","drinks","Not for kids",102.1),
                    new Product("Water","drinks","U won`t survive without it",17.2),
                    new Product("Carp","fish","don`t mess with carp",124.7),
                    new Product("Salmon","fish","don`t mess with salmon",159.9),
                    new Product("Mahi-mahi","fish","don`t mess with mahi-mahi",221),
                    new Product("Tuna","fish","don`t mess with tuna",186.9),
                    new Product("Banana","fruits","Yellow and tasty",44.3),
                    new Product("Orange","fruits","Orange and tasty",53.3),
                    new Product("Apple","fruits","Red and tasty",28.5),
                    new Product("Pear","fruits","Green and tasty",30.2),
                    new Product("Tomato","vegetables","Nice red vegetable",29.6),
                    new Product("Cabbage","vegetables","Nice green vegetable",65.4),
                    new Product("Potato","vegetables","Nice brown vegetable",15),
                    new Product("Onion","vegetables","Make u cry",26.3)
                },
                new List<User>
                {
                    new RegisteredPerson("R","R"),
                    new RegisteredPerson("Q","Q")
                },
                new List<User>()
                {
                    new Administrator("A", "A"),
                    new Administrator("W", "W")
                }
                ,null);
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(unitOfWork));
        }
    }
}