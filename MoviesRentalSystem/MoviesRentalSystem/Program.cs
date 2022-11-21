using DAL;
using MoviesRentalSystem.DAL;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;





Console.WriteLine("-------------Menu-------------");
Console.WriteLine("Type 'list' to list all Movies.");
Console.WriteLine("Type 'add' to add an Movie.");
Console.WriteLine("Type 'del' to delete an Movie.");
Console.WriteLine("Type 'exit' exit the console window");
Console.WriteLine("------------------------------");
string response = "";
while (response != "exit")
{
    Console.Write("Movies Store>");
    response = Console.ReadLine();
    switch (response.ToLower())
    {
        case "add":
            getInfo();
            break;
        case "list":
            list();
            break;
        case "del":
            del();
            break;
        case "exit":
            exit();
            break;

        default:
            Console.WriteLine("Invalid Command\n");

            break;
    }
}

static void getInfo()
{
    Console.WriteLine("Enter Movie name: ");
    string MovieName = Console.ReadLine();

    Console.WriteLine("Enter movie rental cost: ");
    int RentalCost = int.Parse(Console.ReadLine());

    var RentalDuration = DateOnly.FromDateTime(DateTime.Now);
    Movie movie = new Movie();

    //Adding new movie
    movie.AddMovie(MovieName, RentalCost);

    Console.WriteLine("Successfully added movie");
}
static void list()
{
    Movie movie = new Movie();
    movie.RetrieveMovies();
}
static void del()
{
    Console.WriteLine("Enter id of the movie you want to delete");
    int id = int.Parse(Console.ReadLine());
    Movie movie = new Movie();
    movie.deleteMovie(id);
    Console.WriteLine("Deleted successfully");
}
static void exit()
{
    Environment.Exit(0);
}
