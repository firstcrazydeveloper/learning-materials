using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingInterview.TechGig
{
    public class StringSample
    {
        public static void removeDuplicates(char[] str)
        {
            if (str == null) return;
            int len = str.Length;
            if (len < 2) return;

            int tail = 1;

            for (int i = 1; i < len; ++i)
            {
                int j;
                for (j = 0; j < tail; ++j)
                {
                    if (str[i] == str[j])
                        break;
                }
                if (j == tail)
                {
                    str[tail] = str[i];
                    ++tail;
                }
            }
            str[tail] = ' ';
        }

        public static void removeDuplicatesWithExtraSpace(char[] str)
        {
            if (str == null) return;
            int len = str.Length;
            if (len < 2) return;


            Dictionary<int, bool> hashVal = new Dictionary<int, bool>();
            hashVal[str[0]] = true;
            int tail = 1;

            for (int i = 1; i < len; ++i)
            {
                if (!hashVal.ContainsKey(str[i]))
                {
                    str[tail] = str[i];
                    ++tail;
                    hashVal[str[i]] = true;
                }
            }
            str[tail] = ' ';
        }


        public static bool IsAnagram(string source, string dest)
        {
            char[] sArray = source.ToCharArray();
            char[] dArray = dest.ToCharArray();
            Dictionary<char, int> sDict = new Dictionary<char, int>();
            Dictionary<char, int> tDict = new Dictionary<char, int>();

            if (sArray.Length != dArray.Length)
                return false;

            for (int i = 0; i < sArray.Length; i++)
            {
                if (!sDict.ContainsKey(sArray[i]))
                    sDict.Add(sArray[i], 0);

                sDict[sArray[i]] = sDict[sArray[i]] + 1;

                if (!tDict.ContainsKey(dArray[i]))
                    tDict.Add(dArray[i], 0);

                tDict[dArray[i]] = tDict[dArray[i]] + 1;
            }


            for (int i = 0; i < sArray.Length; i++)
            {
                if (!tDict.ContainsKey(sArray[i]))
                    return false;
                if (sDict[sArray[i]] != tDict[sArray[i]])
                    return false;
            }

            return true;
        }

        public static string GetBinaryFormat(int num)
        {
            string result = string.Empty;
            while (num > 0)
            {
                int rem = num % 2;
                result = Convert.ToString(rem) + result;
                num = num / 2;

            }

            return result;
        }

        public static int GetDecimalFormat(string s)
        {
            int result = 0, baseValue = 1;
            int num = int.Parse(s);
            while (num > 0)
            {
                int rem = num % 10;
                result = result + rem * baseValue;
                num = num / 10;
                baseValue = baseValue * 2;
            }

            return result;
        }

        public static int GetLongestSubstring(int num1, int num2)
        {
            string binData1 = "00111"; // GetBinaryFormat(num1);
            string binData2 = "11001";//etBinaryFormat(num2);

            string firstResult = BinaryCompare(binData1, binData2);
            string secondResult = BinaryCompare(binData2, binData1);
            string result = firstResult.Length > secondResult.Length ? firstResult : secondResult;
            return GetDecimalFormat(result);

        }

        public static string BinaryCompare(string baseStr, string sourceStr)
        {
            string result = string.Empty, tempResult = string.Empty;
            int innerLength = sourceStr.Length;
            int j = 0;
            for (int i = 0; i < baseStr.Length;)
            {
                if (i < innerLength && baseStr[i] == sourceStr[j])
                {
                    tempResult = tempResult + baseStr[i];
                    if (tempResult.Length > result.Length)
                    {
                        result = tempResult;
                    }

                    j++;
                }
                else
                {
                    if (result.Length >= (baseStr.Length - i))
                        break;
                    j = 0;
                }

                i++;
            }

            return result;

        }

        public static List<string> BinaryPossibleCombination(string str)
        {
            string maxValue = string.Empty;
            Dictionary<int, int> patternIndex = new Dictionary<int, int>();
            List<string> result = new List<string>();
            char[] pattern = str.ToCharArray();
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '?')
                {
                    patternIndex.Add(count, i);
                    maxValue = maxValue + "1";
                    count++;
                }
            }

            int numValue = GetDecimalFormat(maxValue);
            

            while (numValue >= 0)
            {
                var a= Convert.ToString(numValue, 2).PadLeft(2, '0');
                char[] tempStr = a.ToCharArray();
                foreach (var index in patternIndex)
                {
                    pattern[index.Value] = tempStr[index.Key];

                }

                result.Add(string.Concat(pattern));
                numValue--;
            }

            return result;
        }
    }
}
