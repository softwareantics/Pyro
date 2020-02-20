// <copyright file="ITokenizer.cs" company="MTO Software">
//     Copyright (c) MTO Software. All rights reserved.
// </copyright>

namespace Pyro.Lexing
{
    using System.Collections.Generic;

    /// <summary>
    ///   Defines an interface that a lexer or tokenizer.
    /// </summary>
    public interface ITokenizer
    {
        /// <summary>
        ///   Tokenizes the specified <paramref name="input"/> and returns the tokens.
        /// </summary>
        /// <param name="input">
        ///   Specifies the source input to tokenize.
        /// </param>
        /// <returns>
        ///   An <see cref="IEnumerable{Token}"/> containing all tokens matched by the lexers definitions.
        /// </returns>
        IEnumerable<Token> Tokenize(string input);
    }
}