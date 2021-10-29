using System;

namespace RPNCalulator
{
    class AbstractStrategyFactory
    {
        public static IArgStrategy createStrategyBasedOnOperation(AtomicOperation atomicOperation)
        {
            switch (atomicOperation) {
                case AtomicOperation.Add:
                    return new TwoArgsStrategy();
                case AtomicOperation.Div:
                    return new TwoArgsStrategy();
                case AtomicOperation.Multi:
                    return new TwoArgsStrategy();
                case AtomicOperation.Sub:
                    return new TwoArgsStrategy();
                case AtomicOperation.Factorial:
                    return new OneArgsStrategy();
                default: break;
            }
            throw new InvalidOperationException("Strategy isn't exists for provided operation");
        }

        public static IArgStrategy createOneArgOperation()
        {
            return new OneArgsStrategy();
        }

        public static IArgStrategy createTwoArgOperation()
        {
            return new TwoArgsStrategy();
        }
    }
}
