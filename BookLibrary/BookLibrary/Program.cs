using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            bool success = false;
            while (!success)
            {
                Console.WriteLine("Welcome to your library!\n" +
                               Environment.NewLine + "What would you like to do" +
                               Environment.NewLine + "1) Add a book to your library." +
                               Environment.NewLine + "2) Search your library." +
                               Environment.NewLine + "3) Export your library to a text file." +
                               Environment.NewLine + "4) Exit application.\n");

                Console.Write("Enter your choice: ");
                var userChoice = Console.ReadLine();
                int choice = 0;

                if (int.TryParse(userChoice, out choice))
                {
                    switch (choice)
                    {

                        case 1:
                            success = true;
                            Console.Clear();
                            AddBook();
                            break;

                        case 2:
                            success = true;
                            Console.Clear();
                            SearchLibrary();
                            break;

                        case 3:
                            success = true;
                            Console.Clear();
                            ExportLibrary();
                            break;

                        case 4:
                            success = true;
                            Console.Clear();
                            Environment.Exit(0);
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("You've input an incorrect value, please try again.");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You must only input numeric values, please try again.");
                }
            }
           
        }

        private static void DrawStarLine()
        {
            Console.WriteLine("********************");
        }

        private static void AddBook()
        {
            Console.WriteLine("Add a book to your library"); //I need some help here too. I'm kind of new to working with classes and such.
            DrawStarLine();
            Console.WriteLine("What is the Title of the book?");
            Console.WriteLine("What is the author's name?");
            UserInputAuthor author = UserInputAuthor.CreateAuthor("", "");
            // ask for the book name
            UserInputBook book = UserInputBook.CreateBook("", author);
            // Store in Database

            ////using (IDbConnection connection = new SqlConnection(""))
            ////using (IDbCommand command = connection.CreateCommand())
            ////{
            ////}

                Console.ReadLine();
            Environment.Exit(0);
        }

        private static void SearchLibrary()
        {
            bool success = false;
            while (!success)
            {
                Console.WriteLine("Search your library");
                DrawStarLine();
                Console.WriteLine("Search by: " +
                    Environment.NewLine + "1) Author" +
                    Environment.NewLine + "2) Title" +
                    Environment.NewLine + "3) Genre" +
                    Environment.NewLine + "4) Go back to main menu");
                Console.Write("Enter your choice: ");
                var userChoice = Console.ReadLine();
                int choice = 0;

                if (int.TryParse(userChoice, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            success = true;
                            //SearchAuthor();
                            break;
                        case 2:
                            success = true;
                            //SearchTitle();
                            break;
                        case 3:
                            success = true;
                            //SearchGenre();
                            break;
                        case 4:
                            //How would I be able to return to the main method and start over again from there?
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("You have input an invalid choice. Try again.");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You must put in a valid numeric choice. Try again.");
                }
            }

            Console.ReadLine();
            Environment.Exit(0);
        }

        private static void ExportLibrary() //This part will be a bit off, since it requires parsing data from the database and writing it out.
        {
            Console.WriteLine("Export your library to text file");
            DrawStarLine();
            Console.WriteLine("You can export your library here!");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }

    public class UserInputBook
    {
        protected UserInputBook(string title, UserInputAuthor author)
        {
            Title = title;
        }

        public string Title { get; private set; }
        public UserInputAuthor Author { get; set; }

        public static UserInputBook CreateBook(string title, UserInputAuthor author)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("The title cannot be null or empty", nameof(title));
            }

            if (author == null)        /* Wasn't exactly sure what was going on here.*/
            {

            }

            return new UserInputBook(title, author);
        }
    }

    public class UserInputAuthor
    {
        protected UserInputAuthor(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public static UserInputAuthor CreateAuthor(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentException("The author must have a first name.", nameof(firstName));
            }

            if (string.IsNullOrEmpty(lastName))
            {   
                throw new ArgumentException("The author must have a last name.", nameof(lastName));
            }
            return new UserInputAuthor(firstName, lastName);
        }
    }
}
