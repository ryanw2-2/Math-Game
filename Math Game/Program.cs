using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    static Random rnd = new Random();

    public static void Main(string[] args)
    {
        bool gameStatus = true;
        List<string> results = new List<string>();
        List<int> numbers = Enumerable.Range(0, 100).ToList();
        int currentGame = 0;
        int victory = 0;
        int losses = 0;
        int result = 0;
        int userAnswer = 0;
        int gameLength = 0;
        int operationChoice = 0;

        while (gameStatus)
        {
            currentGame++;
            victory = 0;
            losses = 0;
            result = 0;
            Console.WriteLine("Welcome to Math Game!\n");

            gameLength = getGameLength();

            for (int i = 0; i < gameLength; i++)
            {
                operationChoice = chooseOperation();
                (result, userAnswer) = questionGenerator(operationChoice, numbers);
                updateScore(ref victory, ref losses, result, userAnswer);
            }
            resultCheck(ref victory, ref losses, currentGame, results);
            gameStatus = getGameStatus(results);
        }
    }
    //[1ADD / 2SUB / 3MULT / 4DIV]
    public static (int result, int userAnswer) questionGenerator(int operationChoice, List<int> numbers)
    {
        int result = 0;
        int number1; int number2;
        int userAnswer = 0;
        int index = rnd.Next(numbers.Count);
        number1 = numbers[index];
        index = rnd.Next(numbers.Count);
        number2 = numbers[index];


        switch (operationChoice)
        {
            case 1:
                result = number1 + number2;
                userAnswer = getUserAnswer($"Question: {number1} + {number2}");
                break;

            case 2:
                result = number1 - number2;
                userAnswer = getUserAnswer($"Question: {number1} - {number2}");
                break;

            case 3:
                result = number1 * number2;
                userAnswer = getUserAnswer($"Question: {number1} * {number2}");
                break;
            case 4:     
                number2 = rnd.Next(1, numbers.Count);
                int multiplier = rnd.Next(1, 11);
                number1 = number2 * multiplier;
                result = number1 / number2;
                userAnswer = getUserAnswer($"Question: {number1} / {number2}");
                break;
        }
        return (result, userAnswer);
    }
    public static void updateScore(ref int victory, ref int losses, int result, int userAnswer)
    {
        if (userAnswer == result)
        {
            victory++;
        }
        else
        {
            losses++;
        }
    }
    public static int getUserAnswer(string question)
    {
        int userAnswer = 0;
        while (true)
        {
            Console.WriteLine(question);
            Console.Write("Your answer: ");
            if (int.TryParse(Console.ReadLine(), out userAnswer))
            {
                return userAnswer;
            }
            Console.WriteLine("Please, enter a valid number.");
        }
    }
    public static int getGameLength()
    {
        int gameLength = 0;

        while (true)
        {
            Console.WriteLine("How many questions the game should have?\n");
            Console.WriteLine("Min = [5] / Max = [10]\n");
            Console.Write("Your answer: ");
            if (int.TryParse(Console.ReadLine(), out gameLength))
            {
                if (gameLength >= 5 && gameLength <= 10)
                {
                    return gameLength;
                }
            }
            Console.WriteLine("Please, choose a valid number of questions.");
        }
    }
    public static int chooseOperation()
    {
        int operationChoice = 0;
        Console.WriteLine("Choose an operation: \n");
        while (true)
        {
            Console.WriteLine("[1]Sum\n[2]Subtraction\n[3]Multiplication\n[4]Division\n");
            if (int.TryParse(Console.ReadLine(), out operationChoice))
            {
                if (operationChoice == 1 || operationChoice == 2 || operationChoice == 3 || operationChoice == 4)
                {
                    return operationChoice;
                }
            }
            Console.WriteLine("Please, select a valid operation.");
        }
    }
    public static void resultCheck(ref int victory, ref int losses, int currentGame, List<string> results)
    {
        if (victory > losses)
        {
            Console.WriteLine($"Congratulations, you won!\nVictories: {victory}  Loses: {losses}");
            results.Add($"Game {currentGame} - Victory! Score: {victory} Wins / {losses} Losses");
        }
        else
        {
            Console.WriteLine($"You lose!\nVictories: {victory}  Loses: {losses}");
            results.Add($"Game {currentGame} - Lose! Score: {victory} Wins / {losses} Losses");
        }
    }
    public static bool getGameStatus(List<string> results)
    {
        while (true)
        {
            Console.WriteLine("Do you wanna play again? [1]play again -- [2]end game -- [3]Check placar status");
            Console.Write("User option: ");
            int userStatusOption;
            if (int.TryParse(Console.ReadLine(), out userStatusOption))
            {
                if (userStatusOption == 1)
                {
                    return true;
                }
                if (userStatusOption == 2)
                {
                    return false;
                }
                if (userStatusOption == 3)
                {
                    for (int i = 0; i < results.Count; i++)
                    {
                        Console.WriteLine(results[i]);
                        continue;
                    }
                }
            }
            Console.WriteLine("Please choose a valid option.");
        }
    }
}