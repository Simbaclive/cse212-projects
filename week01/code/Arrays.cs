using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;

public static class Arrays
{

    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //Plan of implementation
        /**
            From example: MultiplesOf(3,5) => {3,6,9,12,15}
            3 should be reserved for position [0] in the array
            using For Loop, (index + 1) * first val to find next values
            then return the arr created
         **/

        double[] arr = new double[length]; // initialise the arr and setting the size 

        arr[0] = number; // allocating the index 0 of the array to the first number that depends on arguments of the function

        for (int i = 1; i < length; i++) // starting from index 1 since index 0 is already populated
        {
            arr[i] = (i + 1) * number; // calculating and allocating the next value into the array
        }

        return arr; // Return the created array
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    

    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        /**
        I need 2* for loops so far one for loop for the number of shifts that need to occur 
        Then second for shifting the data 
        I need to find a way of storing the last element before we replace it

        **/


        int size = data.Count;

        for (int i = 0; i < amount; i++) //Loop restricted by numbers we need to shift
        {
            // We have Save the last element
            int last = data[size - 1];

            // Shift everything to the right by 1 by reversing with a reverse loop
            for (int j = size - 1; j > 0; j--)
            {
                data[j] = data[j - 1];
            }

            //Put the saved element at the front
            data[0] = last;
        }
    }
}
