using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.CodeGenerator.Extensions
{
    public static class Extensions
    {
        public static List<int> GetASCIIValues(this string letters)
        {
            Char[] characters = letters.ToCharArray();

            List<int> asciiList = new();

            foreach (var @char in characters)
            {
                asciiList.Add((int)@char);
            }

            return asciiList;
        }

        public static char GetAsciiCharacter(this int asciiValue)
        {
            return (char)asciiValue;
        }

        public static (string character, int value) GetRandomElement(this Dictionary<string,int> keyValues,int count)
        {
            var random = new Random();


            int index = random.Next(count);
            int value = keyValues.ElementAt(index).Value;
            string key = keyValues.ElementAt(index).Key;

            return (key,value);
        }
    }
}
