using System;
using System.Collections.Generic;

namespace RPNCalulator
{
    class TwoArgsStrategy : IArgStrategy
    {

        private Dictionary<AtomicOperation, Func<int, int, int>> _operationFunction;

        public TwoArgsStrategy()
        {
            _operationFunction = new Dictionary<AtomicOperation, Func<int, int, int>>
            {
                [AtomicOperation.Add] = (fst, snd) => (fst + snd),
                [AtomicOperation.Sub] = (fst, snd) => (fst - snd),
                [AtomicOperation.Multi] = (fst, snd) => (fst * snd),
                [AtomicOperation.Div] = (fst, snd) => (fst / snd),
            };
        }
        public int computeExpression(AtomicOperation operation, RPNCalulator.Stack<int> stack)
        {
            return _operationFunction[operation](stack.Pop(), stack.Pop());
        }
    }
}
