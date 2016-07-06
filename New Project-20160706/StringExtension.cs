namespace DataWorks
{
    internal static class StringExtension
    {
        public static void Swap(char[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public static string ReverseVowels(this string str)
        {
            int i = 0, j = str.Length - 1;
            var arr = str.ToCharArray();
            const string vowels = "аеёиоуыэюяАЕЁИОУЭЮЯaeiouAEIOU";

            while (i < j)
            {
                while (i < j && vowels.IndexOf(arr[i]) == -1)
                {
                    i++;
                }
                while (i < j && vowels.IndexOf(arr[j]) == -1)
                {
                    j--;
                }

                if (i < j)
                {
                    Swap(arr, i, j);
                    i++;
                    j--;
                }
            }
            return new string(arr);
        }
    }
}