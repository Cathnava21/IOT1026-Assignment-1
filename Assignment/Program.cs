namespace Assignment
{
    public static class ArrayReplicator
    {
        /// <summary>
        /// Replicates (deep copies) the incoming array
        /// </summary>
        /// <param name="original">The array to be replicated</param>
        /// <returns>A deep copy of the original array</returns>
        public static int[] ReplicateArray(int[] original)
        {
            // Create a new array with the same size as the original array
            int[] replicatedArray = new int[original.Length];
            for (int i = 0; i < original.Length; i++)
            {
                // Copy the values from the original array to the replicated array
                replicatedArray[i] = original[i];
            }
            return replicatedArray; // Return the copied array
        }

        /// <summary>
        /// Asks the user for a number. Will crash if the user input is not convertible to an int (throw exception?)
        /// </summary>
        /// <param name="text">Text to prompt the user</param>
        /// <returns>The user input as an integer</returns>
        public static int AskForNumber(string text)
        {
            int v = 1;
            int number = 0;
            do
            {
                Console.Write(text);
                try
                {
                    //Convert the input data to an integer
                    number = Convert.ToInt32(Console.ReadLine());
                    v = 1;
                }
                catch (Exception error)
                {
                    v = 0;
                    //Print a error if the type of data is incorrect 
                    Console.Write(error.Message + "\n");
                }
            } while (v == 0);
            return number;
        }

        /// <summary>
        /// Asks the user for a number within a certain range [min, max]. If the number is not in the range, re-prompt the user for a new number.
        /// Will crash if the user input is not convertible to an int (throw exception?)
        /// </summary>
        /// <param name="text">Text to prompt the user</param>
        /// <param name="min">Smallest permissible value</param>
        /// <param name="max">Largest permissible value</param>
        /// <returns>The user input as an integer</returns>
        public static int AskForNumberInRange(string text, int min, int max)
        {
            int m = 0;
            int arraySize = 0;
            do
            {
                Console.Write(text);
                //Convert the input data to an integer
                arraySize = Convert.ToInt32(Console.ReadLine());
                if (arraySize > max || arraySize < min)
                {
                    //Send a error if the size is not in the range
                    Console.WriteLine($"{arraySize} is not in the specified range. Try again ");
                }
                else
                {
                    m = 1;
                }
            } while (m == 0);
            return arraySize;
        }
    }

    static class Program
    {
        static void Main()
        {

            const int Min = 0;
            const int Max = 10;
            const int PrintOffset = 4;

            int size = ArrayReplicator.AskForNumberInRange("Enter the array size: ", Min, Max);
            int[] original = new int[size];

            // Fill the original array with user specified integers
            for (int item = 0; item < size; ++item)
            {
                original[item] = ArrayReplicator.AskForNumber("Enter a number: ");
            }

            int[] copy = ArrayReplicator.ReplicateArray(original);
            // Verify original and replicated array are the same
            for (int index = 0; index < size; ++index)
                Console.WriteLine($"Original {original[index],-PrintOffset}  {copy[index],4} Copy");
        }
    }
}
