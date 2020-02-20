// <copyright file="TokenDefinition.cs" company="MTO Software">
//     Copyright (c) MTO Software. All rights reserved.
// </copyright>

namespace Pyro.Lexing
{
    using System;
    using Pyro.Lexing.Matching;

    /// <summary>
    ///   Represents the definition of a lexical token, in other words; a lexer rule.
    /// </summary>
    public sealed class TokenDefinition
    {
        private readonly string category;

        private readonly IPatternMatcher matcher;

        private readonly string name;

        /// <summary>
        ///   Initializes a new instance of the <see cref="TokenDefinition"/> class.
        /// </summary>
        /// <param name="name">
        ///   Specifies the name of this <see cref="TokenDefinition"/>.
        /// </param>
        /// <param name="matcher">
        ///   Specifies the matcher of this <see cref="TokenDefinition"/>, used to determine if a token should be generated.
        /// </param>
        /// <param name="category">
        ///   Specifies the category of this <see cref="TokenDefinition"/>.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        ///   The specified <paramref name="name"/> or <paramref name="matcher"/> parameter is null.
        /// </exception>
        public TokenDefinition(string name, IPatternMatcher matcher, string category = null)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.matcher = matcher ?? throw new ArgumentNullException(nameof(matcher));
            this.category = category;
        }

        /// <summary>
        ///   Tries to generate a token that matches this <see cref="TokenDefinition"/>.
        /// </summary>
        /// <param name="input">
        ///   Specifies the input to search for a match.
        /// </param>
        /// <param name="token">
        ///   Specifies the generated token that mas matched this <see cref="TokenDefinition"/>.
        /// </param>
        /// <returns>
        ///   <c>true</c> if a token has been generated; otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        ///   The specified <paramref name="input"/> parameter is null.
        /// </exception>
        public bool TryGenerateToken(string input, out Token token)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (this.matcher.TryMatchInput(input, out string lexeme))
            {
                token = new Token()
                {
                    Name = this.name,
                    Category = this.category,
                    Value = lexeme,
                };

                return true;
            }

            token = default;
            return false;
        }
    }
}