namespace SlowMachine_API.Utils
{
    public static class Utils
    {
        public static string[][] ConvertToJaggedArray(string[,] twoDimensionalArray)
        {
            int rows = twoDimensionalArray.GetLength(0);
            int columns = twoDimensionalArray.GetLength(1);

            string[][] jaggedArray = new string[rows][];

            for (int i = 0; i < rows; i++)
            {
                jaggedArray[i] = new string[columns];
                for (int j = 0; j < columns; j++)
                {
                    jaggedArray[i][j] = twoDimensionalArray[i, j];
                }
            }

            return jaggedArray;
        }

    }
}
