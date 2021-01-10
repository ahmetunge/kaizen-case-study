using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.CodeGenerator.Helpers
{
    public class KaizenKeyValueLetters : IKeyValueLetters
    {
        public Dictionary<string, int> GetKeyValueLetters()
        {
            var letterKeyValues = new Dictionary<string, int>();

            letterKeyValues.Add("A", 1907);
            letterKeyValues.Add("C", 1924);
            letterKeyValues.Add("D", 1915);
            letterKeyValues.Add("E", 1940);
            letterKeyValues.Add("F", 1923);
            letterKeyValues.Add("G", 1930);
            letterKeyValues.Add("H", 1910);
            letterKeyValues.Add("K", 1935);
            letterKeyValues.Add("L", 1944);
            letterKeyValues.Add("M", 1927);
            letterKeyValues.Add("N", 1932);
            letterKeyValues.Add("P", 1934);
            letterKeyValues.Add("R", 1912);
            letterKeyValues.Add("T", 1918);
            letterKeyValues.Add("X", 1920);
            letterKeyValues.Add("Y", 1943);
            letterKeyValues.Add("Z", 1926);
            letterKeyValues.Add("2", 1911);
            letterKeyValues.Add("3", 1908);
            letterKeyValues.Add("4", 1937);
            letterKeyValues.Add("5", 1917);
            letterKeyValues.Add("7", 1946);
            letterKeyValues.Add("9", 1921);

            return letterKeyValues;
        }
    }
}
