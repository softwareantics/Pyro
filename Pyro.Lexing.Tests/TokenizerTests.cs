namespace Pyro.Lexing.Tests
{
    using System;
    using System.Collections.Generic;
    using Moq;
    using NUnit.Framework;
    using Pyro.Lexing.Matching;

    public sealed class TokenizerTests
    {
        [Test]
        public void Constructor_Should_Not_Throw_Exception()
        {
            // Arrange, act and assert
            Assert.DoesNotThrow(() => new Tokenizer(new List<TokenDefinition>()));
        }

        [Test]
        public void Constructor_Should_Throw_ArgumentNullException_When_Definitions_Is_Null()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new Tokenizer(null));
        }

        [Test]
        public void Tokenize_Should_Throw_ArgumentNullException_When_Input_Is_Null()
        {
            // Arrange
            var definitions = new List<TokenDefinition>();
            var tokenizer = new Tokenizer(definitions);

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => tokenizer.Tokenize(null));
        }

        [Test]
        public void Tokenize_Should_Throw_ArgumentNullException_When_Input_Is_String_Empty()
        {
            // Arrange
            var definitions = new List<TokenDefinition>();
            var tokenizer = new Tokenizer(definitions);

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => tokenizer.Tokenize(string.Empty));
        }

        [Test]
        public void Tokenize_Should_Throw_Exception_When_No_Tokens_Are_Matched()
        {
            // Arrange
            var mockMatcher = new Mock<IPatternMatcher>();

            string lexeme = null;
            mockMatcher.Setup(x => x.TryMatchInput(It.IsAny<string>(), out lexeme)).Returns(false);

            TokenDefinition[] definitions =
            {
                new TokenDefinition(string.Empty, mockMatcher.Object),
            };

            var tokenizer = new Tokenizer(definitions);

            // Act and assert
            Assert.Throws<Exception>(() => tokenizer.Tokenize("test"));
        }
    }
}