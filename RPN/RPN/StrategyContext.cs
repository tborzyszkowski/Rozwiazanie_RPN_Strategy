
namespace RPNCalulator
{
    class StrategyContext
    {
        private IArgStrategy strategy;

        public void setStrategy(IArgStrategy strategy)
        {
            this.strategy = strategy;
        }

        public IArgStrategy setStrategy(AtomicOperation operation)
        {
            this.strategy = AbstractStrategyFactory
                .createStrategyBasedOnOperation(operation);
            return this.strategy;
        }

        public int executeOperation(AtomicOperation operation, Stack<int> stack)
        {
            if (this.strategy is null)
                strategy = setStrategy(operation);
            return strategy.computeExpression(operation, stack);
        }
    }
}
