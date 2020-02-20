namespace Pyro.Lexing
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public sealed class Tokenizer : ITokenizer
    {
        private readonly IEnumerable<TokenDefinition> definitions;

        private int caratPosition;

        private int lineNumber;

        public Tokenizer(IEnumerable<TokenDefinition> definitions)
        {
            this.definitions = definitions ?? throw new ArgumentNullException(nameof(definitions));
        }

        public IEnumerable<Token> Tokenize(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input));
            }

            var result = new List<Token>();

            using (var reader = new StringReader(input))
            {
                string line = null;

                while ((line = reader.ReadLine()) != null)
                {
                    this.lineNumber++;
                    this.caratPosition = 0;

                    result.AddRange(this.TokenizeLine(line));

                    result.Add(new Token()
                    {
                        Name = "__NEW_LINE__",
                        Category = "__INTERNAL__",
                        Value = this.lineNumber.ToString(),
                    });
                }
            }

            return result;
        }

        private IEnumerable<Token> TokenizeLine(string line)
        {
            var result = new List<Token>();

            while (line.Length != 0)
            {
                if ((line = this.TryMatchDefinition(line, out Token token)) != null)
                {
                    result.Add(token);

                    result.Add(new Token()
                    {
                        Name = "__CARAT_POSITION__",
                        Category = "__INTERNAL__",
                        Value = this.caratPosition.ToString(),
                    });
                }
            }

            return result;
        }

        private string TryMatchDefinition(string line, out Token token)
        {
            foreach (TokenDefinition definition in this.definitions)
            {
                if (definition.TryGenerateToken(line, out token))
                {
                    int length = token.Value.Length;
                    this.caratPosition += length;

                    return line.Substring(length);
                }
            }

            throw new Exception($"Unable to match against token at line {this.lineNumber} position {this.caratPosition} : {line}");
        }
    }
}