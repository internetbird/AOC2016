using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Utility
{
    public static class StringExtensions
    {
            public static string Repeat(this string s, int n)
                => new StringBuilder(s.Length * n).Insert(0, s, n).ToString();
    }
}
