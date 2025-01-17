using System;
using System.Globalization;

internal class Program
{
    // Define a method (special function). Using Main from the program class.
    private static void Main()
    {
        // initialize rollCount to 0 as integer type.
        int rollCount = 0;
        // Initialize an instance of the Random class.
        Random random = new Random();
        // Initialize a new instance of the DiceRoller class
        DiceRoller diceRoller = new DiceRoller();

        System.Console.WriteLine("Welcome to the dice throwing simulator!");

        //Get the user input for the number of dice rolls to simulate and store in a variable called rollCount
        System.Console.WriteLine("How many dice rolls would you like to simulate?");
        rollCount = int.Parse(System.Console.ReadLine());


        System.Console.WriteLine("DICE ROLLING SIMULATION RESULTS");
        System.Console.WriteLine("Each '*' represents 1% of the total number of rolls.");
        // Display the total number of rolls requested by the user.
        System.Console.WriteLine("Total number of rolls = " + rollCount);

        // Call the SimulateRolls method from the DiceRoller class and store the result in an array called rolls.
        // Method passes rollCount and random into the local version of the rolls array
        int[] rolls = diceRoller.SimulateRolls(rollCount, random);

        // For loop running between numbers 2 to 12 (all possible dice roll values with 2 standard dices)
        for (int j = 2; j <= 12; j++)
        {
            // j-2 because the array starts from position 0, even though the key numnerically begins at 2.
            // Calculate the percentage of each roll
            double percent = (rolls[j - 2] / (double)rollCount) * 100;
            //Converts  percentages of stars into whole numbers.
            int stars = (int)percent;
            // prints the sum and number of stars for each roll value.
            System.Console.WriteLine($"{j, 2}: {new string('*', stars)}");
        }

    }
}
// Define Class. Public means other parts of the program can use this class
public class DiceRoller
{
    // Define a method (special function).
    // Put in 2 parameters: rollCount and random (from the Random class).
    // Method returns an array of integers.
    public int[] SimulateRolls(int rollCount, Random random)
    {
        // Create an array of integers with 11 elements (2 to 12).
        int[] rolls = new int[11];


        // For Loop. Repeats the code untill the number of rolls determined by the user.
        // Since it is starting from 0, it will end 1 less than the rollCount.
        for (int i = 0; i < rollCount; i++)
        {
            // Generate a random number between 1 and 6 for each dice, separately.
            int dice1Roll = random.Next(1, 7);
            int dice2Roll = random.Next(1, 7);

            // Add the two dice rolls together. The result will always be between 2 and 12
            var diceTally = dice1Roll + dice2Roll;

            // Since the first slot in the array is assigned for 2 and not 0, we have to subtract 2 from the diceTally.
            // It checks that position in the array and adds 1 to it.
            rolls[diceTally - 2] += 1;
        }
        // return the array of counts outside of the method so it can be use elsewhere, like the main method
        return rolls;
    }
    
}