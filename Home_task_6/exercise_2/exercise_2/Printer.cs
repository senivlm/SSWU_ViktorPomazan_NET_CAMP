namespace exercise_2
{
    public static class Printer
    {
        public static void Print()
        {
            int[] array1 = { 4, 1, 5, 9, 2 };
            int[] array2 = { 2, 7, 3, 8, 1 };
            int[] array3 = { 6, 9, 8, 4, 3 };
            int[] array4 = { 5, 7, 2, 1, 6 };
            int[] array5 = { 3, 6, 8, 2, 4 };
            int[][] arrays = { array1, array2, array3, array4, array5 };
            ArraySorter sorter = new ArraySorter(arrays);
            Console.WriteLine(sorter.ToString());
        }
    }
}
