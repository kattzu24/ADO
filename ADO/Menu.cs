using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
    public class Menu
    {
        private readonly MovieRepository _repository;

        public Menu(MovieRepository repository)
        {
            _repository = repository;
        }

        public void ShowMainMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n~~~~ Huvudmeny ~~~~");
                Console.WriteLine("1. Sök filmer med en skådespelare");
                Console.WriteLine("2. Avsluta");
                Console.WriteLine("Välj ett alternativ: ");
                string choice = Console.ReadLine();
                exit = HandleMenuChoice(choice);
            }
        }
        private bool HandleMenuChoice(string choice)
        {
            Console.Clear();
            switch (choice)
            {
                case "1":
                    SearchMovieByActor();
                    return false;
                case "2":
                    Console.WriteLine("Avslutar programmet....");
                    return true;
                default:
                    Console.WriteLine("Ogiltigt val");
                    BackToMenu();
                    return false;
            }
        }
        public static void BackToMenu()
        {
            Console.WriteLine("Tryck Enter för att återgå till menyn...");
            Console.ReadLine();
            Console.Clear();

        }
        private void SearchMovieByActor()
        {
            Console.Write("Ange skådespelarens förnamn: ");
            string firstName = Console.ReadLine();

            Console.Write("Ange skådespelarens efternamn: ");
            string lastName = Console.ReadLine();

            Actor actor = new Actor(firstName, lastName);
            var movies = _repository.GetMoviesByActor(actor);

            if (movies.Count > 0)
            {
                Console.WriteLine($"\nFilmer med {actor.FullName}:");
                foreach (var movie in movies)
                {
                    Console.WriteLine($"- {movie}");
                }
            }
            else
            {
                Console.WriteLine($"\nInga filmer hittades för {actor.FullName}.");
            }
            BackToMenu();
        }
        private string ReadValidName(string prompt)
        {
            string name;
            do
            {
                Console.Write(prompt);
                name = Console.ReadLine()?.Trim();
            } while (string.IsNullOrWhiteSpace(name)); 
            return name;
        }
    }    
}
