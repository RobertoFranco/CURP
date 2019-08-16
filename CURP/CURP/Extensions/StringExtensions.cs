//-----------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="">
//     Copyright (c). All rights reserved.
// </copyright>
// <author>Roberto Franco</author>
//-----------------------------------------------------------------------

// ReSharper disable once CheckNamespace
namespace System
{
    using System.Text.RegularExpressions;

    /// <summary>
    ///     String extension methods
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///     Retrieves the n internal consonant of a text.
        /// </summary>
        /// <param name="str"> The text to filter.</param>
        /// <param name="number">
        ///     The number of consonant to find.
        /// </param>
        /// <remarks> Internal means that it will exclude the first letter of the text. </remarks>
        /// <returns> The n constant. If no consonant found returns null. </returns>
        public static char? InternalConsonant(this string str, int number)
        {
            if (str.Length < 2)
            {
                return null;
            }

            // Validatiosn
            if (str.Trim().Split(' ').Length > 1)
            {
                throw new ArgumentException("The str must be a single word.");
            }

            var constantRegex = new Regex(@"[b-df-hj-np-tv-z]|[ñ]", RegexOptions.IgnoreCase);

            var count = 0;

            // Starts from the second char to exclude the firs
            for (var i = 1; i < str.Length; i++)
            {
                if (!constantRegex.IsMatch(str[i].ToString()))
                {
                    continue;
                }

                count++;

                if (count == number)
                {
                    return str[i];
                }
            }

            return null;
        }

        /// <summary>
        ///     Retrieves the n internal vowel of a text.
        /// </summary>
        /// <param name="str"> The text to filter.</param>
        /// <param name="number">
        ///     The number of vowel to find.
        /// </param>
        /// <remarks> Internal means that it will exclude the first letter of the text. </remarks>
        /// <returns> The n vowel. If no vowel found returns null. </returns>
        public static char? InternalVowel(this string str, int number)
        {
            if (str.Length < 2)
                return null;

            // Validatiosn
            if (str.Trim().Split(' ').Length > 1)
                throw new ArgumentException("The str must be a single word.");

            var constantRegex = new Regex(@"[aeiou]", RegexOptions.IgnoreCase);

            var count = 0;

            // Starts from the second char to exclude the firs
            for (var i = 1; i < str.Length; i++)
            {
                if (!constantRegex.IsMatch(str[i].ToString()))
                    continue;

                count++;

                if (count == number)
                    return str[i];
            }

            return null;
        }

        /// <summary>
        ///     Validate if a text is a valid CURP.
        /// </summary>
        /// <param name="str"> The text to validate.</param>
        /// <returns> True if is a valid CURP.</returns>
        public static bool IsCURP(this string str)
        {
            var curpRegex = new Regex(@"^[A-Z][AEIOUX][A-Z]{2}(\d{2})(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])(H|M)(?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d]\d$");
            return curpRegex.IsMatch(str);
        }

        /// <summary>
        ///     Remove all accent marks in vowels of a string.
        /// </summary>
        /// <param name="str">The text to filter.</param>
        /// <returns> The <see cref="string" /> resultant. </returns>
        public static string RemoveAccentMarks(this string str)
        {
            str = str.Replace('á', 'a')
                .Replace('é', 'e')
                .Replace('í', 'i')
                .Replace('ó', 'o')
                .Replace('ú', 'u')
                .Replace('Á', 'A')
                .Replace('É', 'E')
                .Replace('Í', 'I')
                .Replace('Ó', 'O')
                .Replace('Ú', 'U');

            return str;
        }

        /// <summary>
        ///     Replace all vowel letters that contains dieresis with this letter without dieresis.
        /// </summary>
        /// <param name="str">The text to filter.</param>
        /// <returns> The <see cref="string" /> resultant. </returns>
        public static string RemoveVowelDieresis(this string str)
        {
            return str.Replace('Ä', 'A')
                .Replace('Ë', 'E')
                .Replace('Ï', 'I')
                .Replace('Ö', 'O')
                .Replace('Ü', 'U');
        }
    }
}
