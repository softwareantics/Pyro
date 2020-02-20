// <copyright file="TokenTests.cs" company="MTO Software">
//     Copyright (c) MTO Software. All rights reserved.
// </copyright>

namespace Pyro.Lexing.Tests
{
    using NUnit.Framework;

    public sealed class TokenTests
    {
        [Test]
        public void Category_Should_Return_String_Empty_When_Assigned_To_Null()
        {
            // Arrange
            Token token;

            // Act
            token.Category = null;

            // Assert
            Assert.AreEqual(string.Empty, token.Category);
        }

        [Test]
        public void Category_Should_Return_String_Empty_When_Not_Assigned()
        {
            // Arrange
            Token token;

            // Act
            string actual = token.Category;

            // Assert
            Assert.AreEqual(string.Empty, actual);
        }

        [Test]
        public void Category_Should_Return_Test_When_Assigned_To_Test()
        {
            // Arrange
            Token token;

            // Act
            token.Category = "Test";

            // Assert
            Assert.AreEqual("Test", token.Category);
        }

        [Test]
        public void Length_Should_Return_Four_When_Value_Is_Assigned_To_Test()
        {
            // Arrange
            Token token;

            // Act
            token.Value = "Test";

            // Assert
            Assert.AreEqual(4, token.Length);
        }

        [Test]
        public void Length_Should_Return_Zero_When_Value_Is_Assigned_To_Null()
        {
            // Arrange
            Token token;
            token.Value = null;

            // Act
            int actual = token.Length;

            // Assert
            Assert.Zero(actual);
        }

        [Test]
        public void Length_Should_Return_Zero_When_Value_Is_Assigned_To_String_Empty()
        {
            // Arrange
            Token token;
            token.Value = string.Empty;

            // Act
            int actual = token.Length;

            // Assert
            Assert.Zero(actual);
        }

        [Test]
        public void Length_Should_Return_Zero_When_Value_Is_Not_Assigned()
        {
            // Arrange
            Token token;

            // Act
            int actual = token.Length;

            // Assert
            Assert.Zero(actual);
        }

        [Test]
        public void Name_Should_Return_String_Empty_When_Assigned_To_Null()
        {
            // Arrange
            Token token;

            // Act
            token.Name = null;

            // Assert
            Assert.AreEqual(string.Empty, token.Name);
        }

        [Test]
        public void Name_Should_Return_String_Empty_When_Not_Assigned()
        {
            // Arrange
            Token token;

            // Act
            string actual = token.Name;

            // Assert
            Assert.AreEqual(string.Empty, actual);
        }

        [Test]
        public void Name_Should_Return_Test_When_Assigned_To_Test()
        {
            // Arrange
            Token token;

            // Act
            token.Name = "Test";

            // Assert
            Assert.AreEqual("Test", token.Name);
        }

        [Test]
        public void Value_Should_Return_String_Empty_When_Assigned_To_Null()
        {
            // Arrange
            Token token;

            // Act
            token.Value = null;

            // Assert
            Assert.AreEqual(string.Empty, token.Value);
        }

        [Test]
        public void Value_Should_Return_String_Empty_When_Not_Assigned()
        {
            // Arrange
            Token token;

            // Act
            string actual = token.Value;

            // Assert
            Assert.AreEqual(string.Empty, actual);
        }

        [Test]
        public void Value_Should_Return_Test_When_Assigned_To_Test()
        {
            // Arrange
            Token token;

            // Act
            token.Value = "Test";

            // Assert
            Assert.AreEqual("Test", token.Value);
        }
    }
}