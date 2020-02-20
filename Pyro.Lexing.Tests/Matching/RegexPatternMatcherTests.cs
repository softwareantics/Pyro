// <copyright file="RegexPatternMatcherTests.cs" company="MTO Software">
//     Copyright (c) MTO Software. All rights reserved.
// </copyright>

namespace Pyro.Lexing.Tests.Matching
{
    using System;
    using NUnit.Framework;
    using Pyro.Lexing.Matching;

    public sealed class RegexPatternMatcherTests
    {
        [Test]
        public void Constructor_Should_Not_Throw_Exception()
        {
            // Arrange, act and assert
            Assert.DoesNotThrow(() => new RegexPatternMatcher("."));
        }

        [Test]
        public void Constructor_Should_Throw_ArgumentNullException_When_Pattern_Is_Null()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new RegexPatternMatcher(null));
        }

        [Test]
        public void Constructor_Should_Throw_ArgumentNullException_When_Pattern_Is_String_Empty()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new RegexPatternMatcher(string.Empty));
        }

        [Test]
        public void TryMatchInput_Should_Out_Lexeme_When_Input_Does_Match()
        {
            // Arrange
            var matcher = new RegexPatternMatcher("test");

            // Act
            matcher.TryMatchInput("test this", out string lexeme);

            // Assert
            Assert.AreEqual("test", lexeme);
        }

        [Test]
        public void TryMatchInput_Should_Out_Null_When_Input_Does_Not_Match()
        {
            // Arrange
            var matcher = new RegexPatternMatcher("test");

            // Act
            matcher.TryMatchInput("apple", out string lexeme);

            // Assert
            Assert.AreEqual(null, lexeme);
        }

        [Test]
        public void TryMatchInput_Should_Return_False_When_Input_Does_Not_Match()
        {
            // Arrange
            var matcher = new RegexPatternMatcher("test");

            // Act
            bool result = matcher.TryMatchInput("apple", out _);

            // Assert
            Assert.False(result);
        }

        [Test]
        public void TryMatchInput_Should_Return_True_When_Input_Does_Match()
        {
            // Arrange
            var matcher = new RegexPatternMatcher("test");

            // Act
            bool result = matcher.TryMatchInput("test", out _);

            // Assert
            Assert.True(result);
        }

        [Test]
        public void TryMatchInput_Should_Throw_ArgumentNullException_When_Input_Is_Empty()
        {
            // Arrange
            var matcher = new RegexPatternMatcher(".");

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => matcher.TryMatchInput(string.Empty, out _));
        }

        [Test]
        public void TryMatchInput_Should_Throw_ArgumentNullException_When_Input_Is_Null()
        {
            // Arrange
            var matcher = new RegexPatternMatcher(".");

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => matcher.TryMatchInput(null, out _));
        }
    }
}