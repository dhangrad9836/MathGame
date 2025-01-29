using System;
using static System.Formats.Asn1.AsnWriter;

string name = GetName();
//string name = Console.ReadLine();
DateTime date = DateTime.Now;
int gamesPlayed = 0;
char userOption;
decimal averageScore;
bool isScoreEmpty = true;
//store game history in the list
List<string> gamesHistory = new List<string>();

Console.WriteLine("------------------------------------------");
Console.WriteLine($"Hello {name}! Today is {date}. This is your math's game. That's great that you're improving yourself");
Console.WriteLine("Press any key to continue.");
Console.ReadKey();

//boolean to dictate when the game continues or user ends
var isGameOn = true;

do
{
    Console.Clear();
    Console.WriteLine($"Games played: {gamesPlayed}");
    Console.WriteLine(@"What game would you like to play?
                        A - Addition
                        S - Subtraction
                        M - Multiplication
                        D - Division
                        V - View Previous Games
                        Q - Quit The Program");
    Console.WriteLine("------------------------------------------");

    userOption = Console.ReadKey().KeyChar;
    
    switch (char.ToLower(userOption))
    {
        case 'a':
            AdditionGame();
            break;
        case 's':
            SubtractionGame();
            break;
        case 'm':
            MultiplicationGame();
            break;
        case 'd':
            DivisionGame("Division game:");
            break;
        case 'v':
            ViewPreviousGames();
            break;
        case 'q':
            Console.WriteLine("Goodbye");
            isGameOn = false;   //we to change isGameOn to false to exit out of the loop when 'q' is selected
            break;
        default:
            Console.WriteLine("Invalid input");
            break;
    }
    //increase the games played
    gamesPlayed++;
} while (isGameOn);


//math game methods
void AdditionGame()
{
    Console.Clear();

    var random = new Random();
    var score = 0;

    int firstNumber;
    int secondNumber;

    Console.WriteLine($"How many times would you like to play? ");
    var numberOfRounds = int.Parse(Console.ReadLine());

    for (int i = 0; i < numberOfRounds; i++)
    {

        //store two random numbers btw 1 - 9
        firstNumber = random.Next(1, 9);
        secondNumber = random.Next(1, 9);

        Console.WriteLine($"{firstNumber} + {secondNumber}");
        Console.WriteLine("What does that add up to? ");
        var result = Console.ReadLine();

        if (int.Parse(result) == firstNumber + secondNumber)
        {
            Console.WriteLine("Correct Type a key for the next question.");
            score++;
            Console.ReadLine(); //get input from user
        }
        else
        {
            Console.WriteLine("Incorrect!. Type a key for the next question.");
            Console.ReadLine(); //get input from user
        }
    }
    Console.WriteLine($"Game over. Your final score is {score} out of {numberOfRounds}");
    Console.ReadKey();

    //add game history score to AddToHistory method
    AddToHistory(score, "Addition");
    //gamesHistory.Add($"{DateTime.Now} - Addition - Score: {score} out of {numberOfRounds}");
}

void SubtractionGame()
{
    Console.Clear();

    var random = new Random();
    var score = 0;

    int firstNumber;
    int secondNumber;

    Console.WriteLine($"How many times would you like to play? ");
    var numberOfRounds = int.Parse(Console.ReadLine());

    for (int i = 0; i < numberOfRounds; i++)
    {

        //store two random numbers btw 1 - 9
        firstNumber = random.Next(1, 9);
        secondNumber = random.Next(1, 9);

        Console.WriteLine($"{firstNumber} - {secondNumber}");
        Console.WriteLine("What is the difference between two inputs? ");
        var result = Console.ReadLine();

        if (int.Parse(result) == firstNumber - secondNumber)
        {
            Console.WriteLine("Correct Type a key for the next question.");
            score++;
            Console.ReadLine(); //get input from user
        }
        else
        {
            Console.WriteLine("Incorrect!. Type a key for the next question.");
            Console.ReadLine(); //get input from user
        }
    }
    Console.WriteLine($"Game over. Your final score is {score} out of {numberOfRounds}");
    Console.ReadKey();

    AddToHistory(score, "Subtraction");
}

void MultiplicationGame()
{
    Console.Clear();

    var random = new Random();
    var score = 0;

    int firstNumber;
    int secondNumber;

    Console.WriteLine($"How many times would you like to play? ");
    var numberOfRounds = int.Parse(Console.ReadLine());

    for (int i = 0; i < numberOfRounds; i++)
    {

        //store two random numbers btw 1 - 9
        firstNumber = random.Next(1, 9);
        secondNumber = random.Next(1, 9);

        Console.WriteLine($"{firstNumber} * {secondNumber}");
        Console.WriteLine("What does that multiply up to? ");
        var result = Console.ReadLine();

        if (int.Parse(result) == firstNumber * secondNumber)
        {
            Console.WriteLine("Correct Type a key for the next question.");
            score++;
            Console.ReadLine(); //get input from user
        }
        else
        {
            Console.WriteLine("Incorrect!. Type a key for the next question.");
            Console.ReadLine(); //get input from user
        }
    }
    //Console.WriteLine($"Game over. Your final score is {score} out of {numberOfRounds}");
    //Console.ReadKey();

    AddToHistory(score, "Multiplication");
}

void DivisionGame(string message)
{
    var score = 0;

    Console.WriteLine($"How many times would you like to play? ");
    var numberOfRounds = int.Parse(Console.ReadLine());
    
    for (int i = 0; i < numberOfRounds; i++)
    {
        Console.Clear();
        Console.WriteLine(message);
        var divisionNumbers = GetDivisionNumbers(); //return array of two random numbers
        var firstNumber = divisionNumbers[0];
        var secondNumber = divisionNumbers[1];

        Console.WriteLine($"{firstNumber} / {secondNumber}");
        var result = Console.ReadLine();

        if (int.Parse(result) == firstNumber / secondNumber)
        {
            Console.WriteLine("Correct Type a key for the next question.");
            score++;
            Console.ReadLine(); //get input from user
        }
        else
        {
            Console.WriteLine("Incorrect!. Type a key for the next question.");
            Console.ReadLine(); //get input from user
        }
        if (i == 1) Console.WriteLine($"Game over. Your final score is {score} out of {numberOfRounds} ");
    }
    
    Console.ReadKey();

    AddToHistory(score, "Division");
}

void AddToHistory(int gameScore, string gameType)
{
    gamesHistory.Add($"{DateTime.Now} - {gameType} - Score: {gameScore}");
}

void ViewPreviousGames()
{
    Console.Clear();
    if (gamesHistory.Count == 0)
    {
        Console.WriteLine("No games have been played yet. Pres any key to go back to main menu.");
        Console.ReadKey();
        return;
    }

    Console.WriteLine("Games List");
    Console.WriteLine("----------------------------------");
    foreach (var game in gamesHistory)
    {
        //print out each game stored in the list
        Console.WriteLine(game);
    }
    Console.WriteLine("----------------------------------\n");

    Console.WriteLine($"\nPress any key to go back to main menu.");
    Console.ReadKey();
}// end ViewPreviousGames

//GetDivisionNumbers()
int[] GetDivisionNumbers()
{
    var random = new Random();
    //store two random numbers btw 1 - 99
    var firstNumber = random.Next(0, 99);
    var secondNumber = random.Next(0, 99);

    var result = new int[2];

    //this checks if the remainder is 0
    while (firstNumber % secondNumber != 0)
    {
        firstNumber = random.Next(0, 99);
        secondNumber = random.Next(0, 99);
    }

    result[0] = firstNumber;
    result[1] = secondNumber;

    //Console.WriteLine(result);

    return result;
}

string GetName()
{
    Console.WriteLine("Enter your name: ");
    var name = Console.ReadLine();
    return name;
}