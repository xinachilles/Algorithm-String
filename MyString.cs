using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class MyString
    {
        private string testString;

        private static void sortStr(ref string s)
        {

        }

        #region 1.1
        /*Implement an algorithm to determine if a string has all unique characters. What if
        you cannot use additional data structures
        string assume only for low case 'a-z' 
        */

        public bool IsUniqueChars2(String str)
        {
            bool[] char_set = new bool[256];
            foreach (char item in str)
            {
                int i = (int)item;
                if (char_set[i]) { return false; }
                else { 
                    char_set[i] = true; 
                }

            }

            return true; 
        
        }

        public bool IsUniqueChars(String str)
        {


            int checker = 0;
            for (int i = 0; i < str.Length; i++)
            {
                int val = str[i] - 'a';
                if ((checker & (1 << val)) > 0)
                {
                    return false;
                }
                checker |= (1 << val);
            }
            return true;
        }


        #endregion

        #region 1.2


        #endregion

        #region 1.3
        //   Given two strings, write a method to decide if one is a permutation of the other.
        public Boolean Permutation2(String str1, String str2)
        {
            if (str1.Length != str2.Length)
            {
                Console.WriteLine("Not permutation of the other.");
                return false;
            }

            int[] check = new int[256]; // assumption if ASCII code   
            foreach (char c in str1)
            {
                check[(int)c] = check[(int)c] + 1;
            }


            for (int i = 0; i < str2.Length; i++)
            {
                int m = (int)str2[i];
                if (--check[m] < 0)
                {
                    Console.WriteLine("Not permutation of the other.");
                    return false;
                }
            }
            return true;
        }

        // print all of the permutation string 

        private void swap(ref char a, ref char b)
        {
            if (a == b) return;
            char temp;
            temp = a;
            a = b;
            b = temp;

            //a ^= b;
            //b ^= a;
            //a ^= b;
        }

        public void AllPermuteString(char[] list)
        {
            int x = list.Length - 1;
            permute(list, 0, x);
        }

        private void permute(char[] list, int k, int m)
        {
            int i;
            if (k == m)
            {
                Console.Write(list);
                Console.WriteLine(" ");
            }
            else
                for (i = k; i <= m; i++)
                {
                    swap(ref list[k], ref list[i]);
                    permute(list, k + 1, m);
                    swap(ref list[k], ref list[i]);
                }
        }
        #endregion "1.3"

        #region 1.4
        //Write a method to replace all spaces in a string with '%20'. You may assume that the
        //string has sufficient space at the end of the string to hold the additional characters,
        //and that you are given the "true" length of the string. (Note: if implementing in Java,
        //please use a character array so that you can perform this operation in place.)
        public char[] ReplaceSpeces(char[] str)
        {
            int i = 0;

            foreach (char s in str)
            {
                if (char.IsWhiteSpace(s))
                {
                    i = i + 1;
                }

            }


            char[] newStr = new char[i * 3 + (str.Length - i)];
            int j = str.Length - i;
            int k = 0;

            foreach (char item in str)
            {
                if (Char.IsWhiteSpace(item) == false)
                {
                    newStr[k] = item;
                    k = k + 1;
                }
            }

            while (j < newStr.Length)
            {
                newStr[j] = '%';
                newStr[j + 1] = '2';
                newStr[j + 2] = '0';
                j = j + 3;
            }

            return newStr;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        public char[] ReplaceSpacesTwo(char[] str)
        {
            int spaceCount = 0, newLength, i;
            for (i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    spaceCount++;
                }
            }
            newLength = str.Length + spaceCount * 2;
            char[] newStr = new char[newLength];



            for (i = str.Length - 1; i >= 0; i--)
            {
                if (Char.IsWhiteSpace(str[i]))
                {
                    newStr[newLength - 1] = '0';
                    newStr[newLength - 2] = '2';
                    newStr[newLength - 3] = '%';
                    newLength = newLength - 3;
                }
                else
                {
                    newStr[newLength - 1] = str[i];
                    newLength = newLength - 1;
                }
            }

            return newStr;
        }

        #endregion

        #region 1.5
        //This code doesn't handle the case when the compressed string is longer than the original//
//string, but it otherwise works. Is it efficient though? Take a look at the runtime of
//this code.

        // bad example 
        public String compressBad(String str)
        {
            String mystr = "";
            char last = str[0];
            int count = 1;
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == last)
                { // Found repeat char
                    count++;
                }
                else
                { // Insert char count, and update last char
                    mystr += last + "" + count;
                    last = str[i];
                    count = 1;
                }
            }
            return mystr + last + count;
        }

        public string CompressBetter(string str)
        {

            char last = str[0];
            int count = 0;
            List<string> newStr = new List<string>();
            for (int i = 1; i <str.Length; i++)
            {
                if (str[i] == last)
                {
                    count++;
                }
                else {
                    newStr.Add(last.ToString());
                    newStr.Add(count.ToString());
                    count = 0;
                    last = str[i];
                    
                } 

            }

            newStr.Add(last.ToString());
            newStr.Add(count.ToString());

            return newStr.ToArray().ToString();
        }


        public int CountCdmpression(String str)
        {
            int size = 0;
            if (string.IsNullOrEmpty(str) == false)
            {
                char last = str[0];

                int count = 1;
                for (int i = 1; i < str.Length; i++)
                {
                    if (str[i] == last)
                    {
                        count++;
                    }
                    else
                    {
                        last = str[i];
                        size += 1 + count.ToString().Length;
                        count = 1;
                    }
                }
                size += 1 + count.ToString().Length;

            }
            return size;
        }
        #endregion

  
        #region 1.6

        //Given an image represented by an nxn matrix, where each pixel in the image is 4 bytes, write a method to rotate the image by 90 degrees. Can you do this in place?

        public void Rotate(int[,] matrix, int n)
        {
            for (int layer = 0; layer < n / 2; ++layer)
            {
                int first = layer;
                int last = n - 1 - layer;
                for (int i = first; i < last; ++i)
                {
                    int offset = i - first;
                    // save top
                    int top = matrix[first,i];

                    // left -> top
                    matrix[first,i] = matrix[last - offset,first];

                    // bottom -> left
                    matrix[last - offset,first] = matrix[last,last - offset];

                    // right -> bottom
                    matrix[last,last - offset] = matrix[i,last];

                    // top -> right
                    matrix[i,last] = top;
                }
            }
        }



        #endregion
        # region 1.8
        //Assume you have a method isSubstring which checks if one word is a substring of another. Given two strings, s1 and s2, write code to check If s2 is a rotation of s1
        // using only onecalltoisSubstring (e.g., "waterbottLe" is a rotation of "erbottLewat").

        // So, we need to check if there's a way to split si into x and y such that xy = s1 and yx =
        //s2. Regardless of where the division between x and y is, we can see that yx will always
        //be a substring of xyxy.That is, s2 will always be a substring of slsl.

        public bool IsRotation(String s1, String s2)
        {
            int len = s1.Length;
            /* check that si and s2 are equal length and not empty */
            if (len == s2.Length && len > 0)
            {
                /* concatenate si and si within new buffer */
                String s1s1 = s1 + s1;
                return IsSubstring(s1s1, s2);
            }
            return false;
        }

        public bool IsSubstring(string strMainString, string strSubString)
        {


            int[] letters = new int[256];
            foreach (char c in strSubString)
            {
                letters[(int)c] = letters[(int)c] + 1;
            }

            foreach (char c in strMainString)
            {
                letters[(int)c] = letters[(int)c] - 1;

            }

            foreach (int item in letters)
            {
                if (item > 0)
                {
                    return false;
                }
            }

            return true;

        }


        #endregion





        private string revStr()
        {

            if (testString != null)
            {
                char[] r = new char[testString.Length];
                int i;
                int n;
                n = testString.Length - 1;


                for (i = 0; i < testString.Length; i++)
                {
                    r[n] = testString[i];
                    n--;
                }

                return new string(r);


            }

            return null;


        }

        private void contactString(ref string a1, ref string a2)
        {
            string s1 = "A string is more ";
            string s2 = "than the sum of its chars.";

            // Concatenate s1 and s2. This actually creates a new 
            // string object and stores it in s1, releasing the 
            // reference to the original object.
            s1 += s2;

            System.Console.WriteLine(s1);

            s1 = "Hello";
            s2 = s1;
            s1 += "World";

            System.Console.WriteLine(s2);

        }


        private string Uniquecharacters()
        {
            string result = null;
            if (testString != null)
            {

                int i;


                for (i = 0; i <= testString.Length - 1; i++)
                {
                    char a = testString[i];
                    bool unique = true;
                    for (int j = 0; j < testString.Length; j++)
                    {
                        if (a == testString[j] && j != i)
                        {
                            unique = false;
                            break;

                        }

                    }

                    if (unique) result += a;


                }


            }

            return result;

        }


        public static void repSpa(ref string s)
        {
            char[] n = s.ToArray();
            char[] space = new char[0];


            for (int i = 0; i < s.Length; i++)
            {
                if (n[i] == space[0])
                {
                    InsStr(ref n, "aa", i);
                }
            }

        }

        //public MyString(string t)
        //{ 
        //    testString  = t;
        //}


        public static void InsStr(ref char[] old, string s, int index)
        {
            string n = new string(old);
            n.Insert(index, s);
            old = n.ToArray();
        }

        public string ComStr()
        {

            for (int i = 0; i < testString.Length - 1; i++)
            {

                int j = i;
                int number = 1;


                while ((testString[j] == testString[j + 1]))
                {


                    j = j + 1;
                    number = number + 1;

                    if (j >= (testString.Length - 1))
                    {
                        break;
                    }
                }


                if (number > 0)
                {
                    testString = testString.Remove(i + 1, number - 1);
                    testString = testString.Insert(i + 1, number.ToString());
                    i = i + 1;
                }


            }

            return testString;


        }
        public string RepStr(string inString)
        {
            for (int i = 0; i < testString.Length; i++)
            {
                if (testString[i] == ' ')
                {
                    testString = testString.Remove(i, 1);
                    testString = testString.Insert(i, inString);

                }


            }

            return testString;
        }



    }
}



