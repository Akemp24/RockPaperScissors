//basic system and environmental functions
using System;

//creating class named Rock paper scissors
class RockPaperScissors
{
    //keeps track of user wins, ties, and losses
    //why static int variables?
    //single copy of the variable is created and shared among all objects at the class level
    //Variable that has been allocated "statically" meaning its lifetime is the entire run of the program.
    static int userWins = 0;
    static int ties = 0;
    static int userLosses = 0;

    //Random object to generate computers choice
    //look up random function?
    static Random random = new Random();

    //How to generate the computers choice
    static string ComputerPlay()
    {
        //array of choices
        string[] choices = { "Rock", "Paper", "Scissors" };
        //what does this do
        //randomly selects from the choices array
        int randomIndex = random.Next(choices.Length);
        //return the computers random choice
        return choices[randomIndex];
    }

    //Playing a round of rock, paper, scissors
    //takes in the userChoice and the computerChoice
    static void PlayRound(string userChoice, string computerChoice)
    {
        //logic for a tie
        if (userChoice == computerChoice)
        {
            ties++;
            Console.WriteLine("It's a tie!");
        }
        //logic for winning
        else if ((userChoice == "Rock" && computerChoice == "Scissors") ||
                  (userChoice == "Paper" && computerChoice == "Rock") ||
                  (userChoice == "Scissors" && computerChoice == "Paper"))
        {
            userWins++;
            Console.WriteLine($"You win! {userChoice} beats {computerChoice}");
        }
        //logic for losing
        else
        {
            userLosses++;
            Console.WriteLine($"You lose! {computerChoice} beats {userChoice}");
        }
    }

    //Main method is the entry point for the program
    static void Main(string[] args)
    {
        //game loop that continues until the user decides to quit playing
        while (true)
        {
            Console.Write("Enter Rock, Paper, or Scissors:");
            string userChoice = Console.ReadLine();
            if (userChoice != "Rock" && userChoice != "Paper" && userChoice != "Scissors")
            {
                Console.WriteLine("Invalid choice. Please try again.");
                continue;
            }
            string computerChoice = ComputerPlay();
            PlayRound(userChoice, computerChoice);
            Console.WriteLine($"Wins: {userWins}, Losses: {userLosses}, Ties: {ties}");
            Console.Write("Play again? (y/n): ");
            string playAgain = Console.ReadLine();
            if (playAgain != "y")
            {
                Console.WriteLine("Thanks for playing!");
                break;
            }
        }
    }
}