
namespace RPNCalulator
{
    interface IArgStrategy
    {
        int computeExpression(AtomicOperation operation, Stack<int> stack);
    }
}
