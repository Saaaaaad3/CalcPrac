namespace Practice.Calculator.Services.Exceptions
{
    // More dynamiic Exception class. Easier to throw custom exceptions.
    public sealed class CalculatorException : InvalidOperationException
    {
        public CalculatorException()
            : base("Invalid Operation") { }

        public CalculatorException(string message)
            : base(message) { }
    }
}