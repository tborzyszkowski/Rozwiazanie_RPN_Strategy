using System;
using System.Collections.Generic;

namespace RPNCalulator
{
    class OneArgsStrategy : IArgStrategy
    {
        private Dictionary<AtomicOperation, Func<int, int>> _singleArgumentOperationFunction;
        public OneArgsStrategy()
        {
            _singleArgumentOperationFunction = new Dictionary<AtomicOperation, Func<int, int>>
            {
                [AtomicOperation.Factorial] = (arg) => factorial(arg)
            };
        }
        public int computeExpression(AtomicOperation operation, RPNCalulator.Stack<int> stack)
        {
            return _singleArgumentOperationFunction[operation](stack.Pop());
        }
        private int factorial(int input)
        {
            if (input < 0)
                throw new InvalidOperationException("can't use factorial with negative numbers");
            if (input == 1)
                return 1;

            int result = 1;
            for (int i = 1; i <= input; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
