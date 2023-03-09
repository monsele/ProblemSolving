namespace CrackingTheCodingInterview
{
    public class ArraysAndStrings
    {
        public bool isUniqueFirst(string str)
        {
            if (str == null) return false;

            var dict = new Dictionary<char, int>();
            foreach (var item in str)
            {
                if (dict.ContainsKey(item))
                {
                    dict[item]++;
                }
                dict.Add(item, 1);
            }
            return !dict.Values.Any(x => x > 1);

        }
        public bool isUniqueGeekForGeeks(string str)
        {
            var charArr = str.ToCharArray();
            Array.Sort(charArr);
            for (int i = 0; i < charArr.Length; i++)
            {
                if (charArr[i] == charArr[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        public bool StringPermutation(string str1, string str2)
        {
            var a = new SortedList<char, int>();

            var sortedString1 = string.Join("", str1.OrderBy(x => x).ToArray());
            var sortedString2 = string.Join("", str2.OrderBy(x => x).ToArray());

            if (sortedString1.Equals(sortedString2))
            {
                return true;
            }
            return false;
        }

        public string UrlIfy(string sentence)
        {
            var res = sentence.Replace(" ", "%20%");
            return res;
        }
        public class Q1_03_URLify
        {
            int Count_the_number_of_spaces(char[] input)
            {
                var spaceCount = 0;
                foreach (var character in input)
                {
                    if (character == ' ')
                        spaceCount++;
                }
                return spaceCount;
            }

            private void ReplaceSpaces(char[] input, int length)
            {
                var space = new[] { '0', '2', '%' };
                var spaceCount = Count_the_number_of_spaces(input);
                // calculate new string size
                var index = length + spaceCount * 2;
                void SetCharsAndMoveIndex(params char[] chars)
                {
                    foreach (var c in chars)
                    {
                        var val = input[index--];
                        input[index--] = c;
                    }
                }
                // copying the characters backwards and inserting %20
                for (var indexSource = length - 1; indexSource >= 0; indexSource--)
                    if (input[indexSource] == ' ')
                        SetCharsAndMoveIndex(space);
                    else SetCharsAndMoveIndex(input[indexSource]);
            }

            public void Run()
            {
                const string input = "abc d e f";
                var characterArray = new char[input.Length + 3 * 2 + 1];

                for (var i = 0; i < input.Length; i++)
                {
                    characterArray[i] = input[i];
                }
                ReplaceSpaces(characterArray, input.Length);
                Console.WriteLine("{0} -> {1}", input, new string(characterArray));
            }
        }

        public bool isPermutationPalindrome(string phrase)
        {
            //Implementing this algorithm is fairly straightforward. We use a hash table to count how many times each 
            //character appears. Then, we iterate through the hash table and ensure that no more than one character has
            //an odd count.
            //Create dictionary of char to number of occurrences
            bool foundOdd = false;
            var hashTable = new Dictionary<char, int>();
            foreach (var item in phrase.ToArray())
            {
                if (hashTable.ContainsKey(item))
                {
                    hashTable[item]++;
                }
                hashTable.Add(item, 1);
            }
            #region conditions
            //If letter count
            #endregion

            foreach (var item in hashTable.Values)
            {
                if (item % 2 == 1)
                {
                    if (foundOdd)
                    {
                        return false;
                    }
                    foundOdd = true;

                }
            }
            return true;
        }


        public string Compression(string word)
        {
            string result = String.Empty;
            var hashTable = new Dictionary<char, int>();
            foreach (var item in word)
            {
                if (hashTable.ContainsKey(item))
                {
                    hashTable[item]++;
                    continue;
                }
                hashTable.Add(item, 1);
            }
            foreach (var key in hashTable.Keys)
            {
                var occ = hashTable[key].ToString();
                result = result + (key + occ);
            }
            return result;
        }
        public bool OneEditAway(string phrase1, string phrase2)
        {
            int diffrences = 0;
            if (phrase1.Length == phrase2.Length)
            {
                //Consider Replace
                for (int i = 0; i < phrase1.Length; i++)
                {

                    if (phrase1[i] != phrase2[i])
                    {
                        diffrences++;
                    }

                }
                return diffrences > 1;
            }
            if (phrase1.Length < phrase2.Length)
            {
                int letterDiff = 0;
                for (int i = 0; i < phrase2.Length; i++)
                {
                    if (!phrase1.Contains(phrase2[i]))
                    {
                        letterDiff++;
                    }

                }
                return letterDiff > 1;
                //Consider insertion
            }
            return false;
        }

        public static int[] TwoNumberSum(int[] array, int targetSum)
        {
            // Write your code here.

            for (int i = 0; i < array.Length; i++)
            {
                var list = new List<int>().Count();
                var lookUp = targetSum - array[i];
                if (array.Any(x => x == lookUp))
                {
                    return new int[] { lookUp, array[i] };
                }
            }
            return new int[0];

        }
        public static List<int> MoveElementToEnd(List<int> array, int toMove)
        {
            // Write your code here.
            var newList = new int[array.Count];
            int countOfmove = 0;
            int counter = 0;
            foreach (var item in array)
            {
                if (item != toMove)
                {
                    newList[counter] = item;
                    counter++;
                }
                countOfmove++;
            }
            for (int i = counter; i < newList.Length; i++)
            {
                newList[i] = 2;
                counter++;
            }
            var res = newList.ToList();
            return res;
        }
        public int FirstDuplicateValue(int[] array)
        {
            // Write your code here.
            var dict = new Dictionary<int, int>();
            foreach (var item in array)
            {
                int val = 0;
                if (dict.TryGetValue(item, out val))
                {
                    return item;
                }
                dict.Add(item, val++);
            }
            return -1;
        }
        //public int FirstDuplicateValue(int[] array)
        //{
        //    // Write your code here.
        //    var dict = new Dictionary<int, int>();
        //    foreach (var item in array)
        //    {
        //        int val = 0;
        //        if (dict.TryGetValue(item, out val))
        //        {
        //            return item;
        //        }
        //        dict.Add(item, val++);
        //    }
        //    return -1;
        //}

        public int[] ArrayOfProducts(int[] array)
        {
            // Write your code here.
            var leftArr = new int[array.Length];
            var rightArr = new int[array.Length];
            var result = new int[array.Length];

            var leftRunningProduct = 1;
            for (int i = 0; i < array.Length; i++)
            {
                leftArr[i] = leftRunningProduct;
                leftRunningProduct = leftRunningProduct * array[i];
            }
            int rightRunningProduct = 1;
            for (int i = array.Length - 1; i > -1; i--)
            {
                rightArr[i] = rightRunningProduct;
                rightRunningProduct = rightRunningProduct * array[i];
            }
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = rightArr[i] * leftArr[i];
            }
            return result;
        }
        public static bool IsValidSubsequence(List<int> array, List<int> sequence)
        {
            // Write your code here
            var compute = array;
            foreach (var item in sequence)
            {
                if (array.Contains(item))
                {
                    continue;
                }
                compute.Remove(item);
            }

            return compute == (sequence);
        }

        public int GetNthFib(int n)
        {
            // Write your code here.
            var list = new List<int>();
            int sum = 0;
            if (n == 1)
                return 0;
            if (n == 2)
            {
                return 1;
            }
            for (int i = 1; i <= n; i++)
            {

                if (i == 1)
                {
                    sum = 0;
                    list.Add(sum);
                    sum = 0;
                    continue;
                }
                if (i == 2)
                {
                    sum = 1;
                    list.Add(sum);
                    sum = 0;
                    continue;
                }
                sum = list[i - 2] + list[i - 3];
                list.Add(sum);
                sum = 0;
            }
            return list.Last();

        }




        public static int[] SubarraySort(int[] array)
        {
            // Write your code here.
            //find all the unsorted numbers
            var minOutOfOrder = float.PositiveInfinity;
            var maxOutOfOrder = float.NegativeInfinity;
            int minIndex = 0;
            int maxIndex = array.Length - 1;
            for (int i = 0; i < array.Length; i++)
            {
                var num = array[i];
                if (isOutOfOrder(i, num, array))
                {
                    minOutOfOrder = Math.Min(minOutOfOrder, num);
                    maxOutOfOrder = Math.Max(maxOutOfOrder, num);
                }
            }
            if (minOutOfOrder == float.PositiveInfinity)
            {
                return new int[] { -1, -1 };
            }
            while (minOutOfOrder >= array[minIndex])
            {
                minIndex++;
            }
            while (maxOutOfOrder <= array[maxIndex])
            {
                maxIndex--;
            }
            return new int[] { minIndex, maxIndex };
        }

        public int[] LargestRange2(int[] array)
        {
            // Write your code here. 
            var result = new int[2];
            var longestLength = 0;
            var dict = new Dictionary<int, bool>();
            foreach (var item in array)
            {
                dict.Add(item, true);
            }

            foreach (int num in array)
            {
                if (!dict[num])
                {
                    continue;
                }
                dict[num] = false;
                int currentLength = 1;
                int left = num - 1;
                int right = num + 1;
                var leftCon = dict.TryGetValue(left, out var val);
                var rightCon = dict.TryGetValue(right, out var valRight);
                while (val)
                {
                    while (dict[left])
                    {
                        dict[left] = false;
                        currentLength++;
                        left--;
                    }
                }
                while (valRight)
                {
                    while (dict[right])
                    {
                        dict[right] = false;
                        currentLength++;
                        right++;
                    }
                }
                if (currentLength > longestLength)
                {
                    longestLength = currentLength;
                    result = new int[] { left + 1, right - 1 };
                }
            }
            return result;
        }

        public int[] LargestRange(int[] array)
        {
            var list = new List<int>() { 1, 2, 4 };
            Array.Sort(array);
            int maxRange = 0;
            int countRange = 0;
            //int counter = 0;
            int start = array[0], end = array[0];
            var result = new int[] { start, end };
            //populate a HashMap
            var dict = new HashSet<int>();
            foreach (var item in array)
            {
                dict.Add(item);
            }

            for (int i = 0; i < array.Length; i++)
            {
                var num = array[i];
                var expected = num + 1;
                var check = dict.TryGetValue(expected, out int actual);
                if (check)
                {
                    countRange++;
                    end = expected;
                    continue;
                }
                if (countRange > maxRange)
                {
                    maxRange = countRange;
                    result = new int[] { start, end };
                    start = (i + 1) >= array.Length ? start : array[i + 1];
                    end = 0;
                    countRange = 0;
                }
                start = (i + 1) >= array.Length ? start : array[i + 1];
            }
            return result;
        }


        public bool ZeroSumSubarray2(int[] nums)
        {
            // Write your code here.
            var sums = new int[nums.Length];
            var verifySums = new HashSet<int>();
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {

                if (i == 0)
                {
                    sum = nums[i];
                    sums[i] = sum;
                    continue;
                }
                sum = +nums[i];
                sums[i] = sum;
                if (sum == 0)
                {
                    return true;
                }
            }
            if (sum == 0 && nums.Length > 1)
            {
                return true;
            }
            for (int i = 1; i < sums.Length; i++)
            {
                if (verifySums.Contains(sums[i]))
                {
                    return true;
                }
                verifySums.Add(sums[i]);
            }
            return false;
        }


        public bool ZeroSumSubarray(int[] nums)
        {
            // Write your code here.
            var verify = new HashSet<int>();
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (sum == 0)
                {
                    return true;
                }
                if (verify.Contains(sum))
                {
                    return true;
                }
                else
                {
                    verify.Add(sum);
                }
            }
            return false;
        }

        public static bool isOutOfOrder(int i, int num, int[] array)
        {
            if (i == 0)
            {
                return num > array[i + 1];
            }
            if (i == array.Length - 1)
            {
                return num < array[i - 1];
            }
            return num > array[i + 1] || num < array[i - 1];
        }


        public List<int[]> ThreeNumberSum(int[] array, int targetSum)
        {
            // Write your code here.
            var result = new List<int[]>();
            int lp, rp;
            Array.Sort(array);
            for (int i = 0; i < array.Length; i++)
            {
                lp = i + 1;
                rp = array.Length - 1;
                int cn = array[i];
                while (lp < rp)
                {
                    var sum = cn + array[lp] + array[rp];
                    if (sum == targetSum)
                    {
                        result.Add(new int[] { array[i], array[lp], array[rp] });

                        lp++;
                        rp--;
                    }
                    if (sum > targetSum)
                    {
                        rp--;
                    }
                    if (sum < targetSum)
                    {
                        lp++;
                    }
                }
            }
            return result;
        }


        public static int LongestPeak(int[] array)
        {
            // Write your code here.
            int longestPeak = 0;
            int i = 1;
            while (i < array.Length - 1)
            {
                bool isPeak = array[i - 1] < array[i] && array[i] > array[i + 1];
                if (!isPeak)
                {
                    i++;
                    continue;
                }
                int leftIndex = i - 2;
                int rightIndex = i + 2;
                while (leftIndex >= 0 && array[leftIndex] < array[leftIndex + 1])
                {
                    leftIndex--;
                }
                while (rightIndex < array.Length && array[rightIndex] < array[rightIndex - 1])
                {
                    rightIndex++;
                }
                int currentPeakLength = rightIndex - leftIndex - 1;
                longestPeak = Math.Max(longestPeak, currentPeakLength);
                i = rightIndex;
            }
            return longestPeak;
        }



    }
}
