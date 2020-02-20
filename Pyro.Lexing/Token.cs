// <copyright file="Token.cs" company="MTO Software">
//     Copyright (c) MTO Software. All rights reserved.
// </copyright>

// A small change.

namespace Pyro.Lexing
{
    /// <summary>
    ///   Represents a lexical token with an assigned name and value.
    /// </summary>
    public struct Token
    {
        private string category;

        private string name;

        private string value;

        /// <summary>
        ///   Gets or sets the category of this <see cref="Token"/>.
        /// </summary>
        /// <value>
        ///   The category of this <see cref="Token"/>.
        /// </value>
        /// <remarks>
        ///   The <see cref="Category"/> property can be useful when defining a token that might need a more detailed description during the parsing stage, for example: If a token represents an integer, it's category might be defined as "Data Type".
        /// </remarks>
        public string Category
        {
            get { return this.category ?? string.Empty; }
            set { this.category = value; }
        }

        /// <summary>
        ///   Gets the length of this <see cref="Token"/>'s <see cref="Value"/> property.
        /// </summary>
        /// <value>
        ///   The length of this <see cref="Token"/>'s value property.
        /// </value>
        public int Length
        {
            get { return string.IsNullOrEmpty(this.value) ? 0 : this.value.Length; }
        }

        /// <summary>
        ///   Gets or sets the name of this <see cref="Token"/>.
        /// </summary>
        /// <value>
        ///   The name of this <see cref="Token"/>.
        /// </value>
        public string Name
        {
            get { return this.name ?? string.Empty; }
            set { this.name = value; }
        }

        /// <summary>
        ///   Gets or sets the value of this <see cref="Token"/>.
        /// </summary>
        /// <value>
        ///   The value of this <see cref="Token"/>.
        /// </value>
        public string Value
        {
            get { return this.value ?? string.Empty; }
            set { this.value = value; }
        }
    }
}