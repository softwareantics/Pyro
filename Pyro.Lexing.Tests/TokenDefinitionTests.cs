// <copyright file="TokenDefinitionTests.cs" company="MTO Software">
//     Copyright (c) MTO Software. All rights reserved.
// </copyright>

namespace Pyro.Lexing.Tests
{
    using System;
    using Moq;
    using NUnit.Framework;
    using Pyro.Lexing.Matching;

    public sealed class TokenDefinitionTests
    {
        [Test]
        public void Constructor_Should_Not_Throw_Exception()
        {
            // Arrange
            IPatternMatcher matcher = new Mock<IPatternMatcher>().Object;

            // Act and assert
            Assert.DoesNotThrow(() => new TokenDefinition(string.Empty, matcher));
        }

        [Test]
        public void Constructor_Should_Throw_ArgumentNullException_When_Matcher_Is_Null()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new TokenDefinition(string.Empty, null));
        }

        [Test]
        public void Constructor_Should_Throw_ArgumentNullException_When_Name_Is_Null()
        {
            // Arrange
            IPatternMatcher matcher = new Mock<IPatternMatcher>().Object;

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => new TokenDefinition(null, matcher));
        }

        [Test]
        public void TryGenerateToken_Should_Out_Default_Token_When_Matcher_Cant_Match_Input()
        {
            // Arrange
            var mockMatcher = new Mock<IPatternMatcher>();

            string lexeme = null;
            mockMatcher.Setup(x => x.TryMatchInput(It.IsAny<string>(), out lexeme)).Returns(false);

            var tokenDefinition = new TokenDefinition(string.Empty, mockMatcher.Object);

            // Act
            bool actual = tokenDefinition.TryGenerateToken("Test", out Token token);

            // Assert
            Assert.AreEqual(default(Token), token);
        }

        [Test]
        public void TryGenerateToken_Should_Out_Token_When_Matcher_Can_Match_Input()
        {
            // Arrange
            var mockMatcher = new Mock<IPatternMatcher>();

            string lexeme = "Test";
            mockMatcher.Setup(x => x.TryMatchInput("Test", out lexeme)).Returns(true);

            var tokenDefinition = new TokenDefinition("Name", mockMatcher.Object, "Category");

            // Act
            bool actual = tokenDefinition.TryGenerateToken("Test", out Token token);

            // Assert
            Assert.AreEqual("Name", token.Name);
            Assert.AreEqual("Category", token.Category);
            Assert.AreEqual("Test", token.Value);

            Assert.AreNotEqual(default(Token), token);
        }

        [Test]
        public void TryGenerateToken_Should_Return_False_When_Matcher_Cant_Match_Input()
        {
            // Arrange
            var mockMatcher = new Mock<IPatternMatcher>();

            string lexeme = null;
            mockMatcher.Setup(x => x.TryMatchInput(It.IsAny<string>(), out lexeme)).Returns(false);

            var tokenDefinition = new TokenDefinition(string.Empty, mockMatcher.Object);

            // Act
            bool actual = tokenDefinition.TryGenerateToken("Test", out _);

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void TryGenerateToken_Should_Return_True_When_Matcher_Can_Match_Input()
        {
            // Arrange
            var mockMatcher = new Mock<IPatternMatcher>();

            string lexeme = null;
            mockMatcher.Setup(x => x.TryMatchInput(It.IsAny<string>(), out lexeme)).Returns(true);

            var tokenDefinition = new TokenDefinition(string.Empty, mockMatcher.Object);

            // Act
            bool actual = tokenDefinition.TryGenerateToken("Test", out _);

            // Assert
            Assert.True(actual);
        }

        [Test]
        public void TryGenerateToken_Should_Throw_ArgumentNullException_When_Input_Is_Null()
        {
            // Arrange
            IPatternMatcher matcher = new Mock<IPatternMatcher>().Object;
            var tokenDefinition = new TokenDefinition(string.Empty, matcher);

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => tokenDefinition.TryGenerateToken(null, out _));
        }

        [Test]
        public void TryGenerateToken_Should_Throw_ArgumentNullException_When_Input_Is_String_Empty()
        {
            // Arrange
            IPatternMatcher matcher = new Mock<IPatternMatcher>().Object;
            var tokenDefinition = new TokenDefinition(string.Empty, matcher);

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => tokenDefinition.TryGenerateToken(string.Empty, out _));
        }
    }
}