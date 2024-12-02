using Microsoft.Data.SqlClient;
namespace ADO

{
    public class Program
    {                                                   
        static void Main(string[] args)
        {
            string connectionString = DatabaseConfig.GetConnectionString();
            MovieRepository movieRepository = new MovieRepository(connectionString);
            Menu menu = new Menu(movieRepository);
            menu.ShowMainMenu();
        }
    }
}
