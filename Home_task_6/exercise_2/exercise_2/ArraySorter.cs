using System.Text;

namespace exercise_2
{
    public class ArraySorter
    {
        private int[][] _arrays;
        public ArraySorter(int[][] arrays)
        {// можна Array.Copy також
            _arrays = (int[][])arrays.Clone();
        }
        public IEnumerable<int> SortArrays()
        {
            List<int> fullArray = new List<int>();
            foreach (var array in _arrays)
            {
                fullArray.AddRange(array);
            }
            fullArray.Sort();
            foreach (var item in fullArray)
            {
                yield return item;
            }
        }
        // про ефективність цього  - на занятті.
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Arrays:");
            foreach (int[] array in _arrays)
            {
                sb.AppendLine(string.Join(", ", array));
            }
            sb.AppendLine("Sorted Array:");
            sb.AppendLine(string.Join(", ", SortArrays()));
            return sb.ToString();
        }

    }
}
