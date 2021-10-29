using System;

namespace RPNCalulator
{
	public class RPN
	{
		private Stack<int> _operators;
		private StrategyContext context = new StrategyContext();

		public int EvalRPN(string input)
		{
			_operators = new Stack<int>();

			var splitInput = input.Split(' ');
			foreach (var op in splitInput)
			{
				if (IsNumber(op))
					_operators.Push(Int32.Parse(op));
				else
                {
					AtomicOperation operation;
					try{
  						operation =
						(AtomicOperation)Enum.ToObject(typeof(AtomicOperation), op[0]);
					}catch (ArgumentException) { 
						throw new InvalidOperationException(
							"Operation: " + op + " isn't supported !");
					}
					context.setStrategy(operation);
					var num = context.executeOperation(operation, _operators);
					_operators.Push(num);
				}
			}

			var result = _operators.Pop();
			if (_operators.IsEmpty)
			{
				return result;
			}
			throw new InvalidOperationException("Invalid expression provided !");
		}

		private bool IsNumber(String input) => Int32.TryParse(input, out _);

	}
}
