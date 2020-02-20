// <copyright file="IPatternMatcher.cs" company="MTO Software">
//     Copyright (c) MTO Software. All rights reserved.
// </copyright>

namespace Pyro.Lexing.Matching
{
    /// <summary>
    ///   Defines an interface that represents a generic pattern matcher.
    /// </summary>
    public interface IPatternMatcher
    {
        /// <summary>
        ///   Tries to match the first occurance of this <see cref="IPatternMatcher"/> with the specified <paramref name="input"/>.
        /// </summary>
        /// <param name="input">
        ///   Specifies the source input to search for a match.
        /// </param>
        /// <param name="lexeme">
        ///   Specifies the found sequence of characters that have matched this <see cref="IPatternMatcher"/>.
        /// </param>
        /// <returns>
        ///   <c>true</c> if a match has been made; otherwise, <c>false</c>.
        /// </returns>
        bool TryMatchInput(string input, out string lexeme);
    }
}