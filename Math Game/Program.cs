using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        bool gameON = true;
        List<string> Results = new List<string>();
        List<int> numbers = new List<int>();
        int currentGame = 0;
        int number1 = 0;
        int number2 = 0;
        int victory = 0;
        int lose = 0;
        int result = 0;
        int gameLenght = 0;
        int userAnswer = 0;
        int operationChoice = 0;
        for (int i = 0; i < 100; i++)
        {
            numbers.Add(i);
        }
        while (gameON)
        {
            currentGame++;
            Console.WriteLine("Welcome to Math Game!\n");
            Console.WriteLine("How many questions the game should have?\n");
            bool unvalidLenght = true;
            while (unvalidLenght)
            {
                Console.WriteLine("Min = [5] / Max = [10]\n");
                Console.Write("Your answer: ");
                if (int.TryParse(Console.ReadLine(), out gameLenght))
                {
                    if (gameLenght >= 5 && gameLenght <= 10)
                    {
                        unvalidLenght = false;
                        continue;
                    }
                }              
                Console.WriteLine("Please, choose a valid number of questions.");
            }

            for (int i = 0; i < gameLenght; i++)
            {
                bool unvalidOperation = true;
                while (unvalidOperation)
                {
                    Console.WriteLine("Choose an operation: \n");
                    Console.WriteLine("[1]Sum\n[2]Subtraction\n[3]Multiplication\n[4]Division\n");
                    Console.Write("User choice: ");
                    if (int.TryParse(Console.ReadLine(), out operationChoice))
                    {
                        if (operationChoice == 1 || operationChoice == 2 || operationChoice == 3 || operationChoice == 4)
                        {
                            unvalidOperation = false;
                            continue;
                        }
                    }
                    
                    Console.WriteLine("Please, choose a valid option.");
                }
                result = questionGenerator(operationChoice, numbers, ref number1, ref number2, ref userAnswer);
                resultCheck(ref victory, ref lose, result, userAnswer);
            }
            if (victory > lose)
            {
                Console.WriteLine($"Congratulations, you won!\n Victories: {victory}  Loses: {lose}");
                Results.Add($"Game {currentGame} - Victory! Score: {victory}w / {lose}l");
            }
            else
            {
                Console.WriteLine($"You lose!\nVictories: {victory}  Loses: {lose}");
                Results.Add($"Game {currentGame} - Lose! Score: {victory}w / {lose}l");
            }

            bool gameEndOption = true;
            while (gameEndOption)
            {
                Console.WriteLine("Do you wanna play again? [1]play again -- [2]end game -- [3]Check placar status");
                Console.Write("User option: ");
                String userEndOption = Console.ReadLine();
                if (userEndOption == "1")
                {
                    gameEndOption = false;
                    continue;
                }
                if (userEndOption == "2")
                {
                    gameEndOption = false;
                    gameON = false;
                    continue;
                }
                if (userEndOption == "3")
                {
                    for (int i = 0; i < Results.Count; i++)
                    {
                        Console.WriteLine(Results[i]);
                        continue;
                    }
                }
                Console.WriteLine("Please choose a valid option.");
            }
        }
    }
    //[1ADD / 2SUB / 3MULT / 4DIV]
    public static int questionGenerator(int operationChoice, List<int> numbers, ref int number1, ref int number2, ref int userAnswer)
    {
        int result = 0;
        bool userAnswerNotValid = true;
        bool restNot0 = true;
        Random rnd = new Random();
        int index = rnd.Next(numbers.Count);
        number1 = numbers[index];
        index = rnd.Next(numbers.Count);
        number2 = numbers[index];


        if (operationChoice == 1)
        {
            result = number1 + number2;
            while (userAnswerNotValid)
            {
                Console.WriteLine($"Question: {number1} + {number2}");
                Console.Write("Your answer: ");
                if (int.TryParse(Console.ReadLine(), out userAnswer))
                {
                    userAnswerNotValid = false;
                }
                else { 
                    Console.WriteLine("Please, enter a valid number.");
                }
            }          
        }
        if (operationChoice == 2)
        {
            result = number1 - number2;
            while (userAnswerNotValid)
            {
                Console.WriteLine($"Question: {number1} - {number2}");
                Console.Write("Your answer: ");
                if (int.TryParse(Console.ReadLine(), out userAnswer))
                {
                    userAnswerNotValid = false;
                }
                else
                {
                    Console.WriteLine("Please, enter a valid number.");
                }
            }
        }
        if (operationChoice == 3)
        {
            result = number1 * number2;
            while (userAnswerNotValid)
            {
                Console.WriteLine($"Question: {number1} * {number2}");
                Console.Write("Your answer: ");
                if (int.TryParse(Console.ReadLine(), out userAnswer))
                {
                    userAnswerNotValid = false;
                }
                else
                {
                    Console.WriteLine("Please, enter a valid number.");
                }
            }
        }
        if (operationChoice == 4)
        {

            number2 = rnd.Next(1, numbers.Count);
            int multiplier = rnd.Next(1, 11);
            number1 = number2 * multiplier;
            result = number1 / number2;
            while (userAnswerNotValid)
            {
                Console.WriteLine($"Question: {number1} / {number2}");
                Console.Write("Your answer: ");
                if (int.TryParse(Console.ReadLine(), out userAnswer))
                {
                    userAnswerNotValid = false;
                }
                else
                {
                    Console.WriteLine("Please, enter a valid number.");
                }
            }
        }
        return result;
    }
    public static void resultCheck(ref int victory, ref int lose, int result, int userAnswer)
    {
        if (userAnswer == result)
        {
            victory++;
        }
        else
        {
            lose++;
        }
    }
}

