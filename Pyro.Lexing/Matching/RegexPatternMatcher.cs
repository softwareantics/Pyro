// <copyright file="RegexPatternMatcher.cs" company="MTO Software">
//     Copyright (c) MTO Software. All rights reserved.
// </copyright>

namespace Pyro.Lexing.Matching
{
    using System;
    using System.Text.RegularExpressions;

    public sealed class RegexPatternMatcher : IPatternMatcher
    {
        private readonly Regex regex;

        public RegexPatternMatcher(string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
            {
                throw new ArgumentNullException(nameof(pattern));
            }

            this.regex = new Regex($"^{pattern}");
        }

        public bool TryMatchInput(string input, out string lexeme)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input));
            }

            Match match = this.regex.Match(input);

            if (match.Success)
            {
                lexeme = input.Substring(0, match.Length);
                return true;
            }

            lexeme = null;
            return false;
        }
    }
}