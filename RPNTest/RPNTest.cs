using NUnit.Framework;
using System;
using RPNCalulator;

namespace RPNTest {
	[TestFixture]
	public class RPNTest {
		private RPN _sut;
		[SetUp]
		public void Setup() {
			_sut = new RPN();
		}
		[Test]
		public void CheckIfTestWorks() {
			Assert.Pass();
		}

		[Test]
		public void CheckIfCanCreateSut() {
			Assert.That(_sut, Is.Not.Null);
		}

		[Test]
		public void SingleDigitOneInputOneReturn() {
			var result = _sut.EvalRPN("1");

			Assert.That(result, Is.EqualTo(1));

		}
		[Test]
		public void SingleDigitOtherThenOneInputNumberReturn() {
			var result = _sut.EvalRPN("2");

			Assert.That(result, Is.EqualTo(2));

		}
		[Test]
		public void TwoDigitsNumberInputNumberReturn() {
			var result = _sut.EvalRPN("12");

			Assert.That(result, Is.EqualTo(12));

		}
		[Test]
		public void TwoNumbersGivenWithoutOperator_ThrowsExcepton() {
			Assert.Throws<InvalidOperationException>(() => _sut.EvalRPN("1 2"));

		}
		[Test]
		public void OperatorPlus_AddingTwoNumbers_ReturnCorrectResult() {
			var result = _sut.EvalRPN("1 2 +");

			Assert.That(result, Is.EqualTo(3));
		}
		[Test]
		public void OperatorTimes_AddingTwoNumbers_ReturnCorrectResult() {
			var result = _sut.EvalRPN("2 2 *");

			Assert.That(result, Is.EqualTo(4));
		}
		[Test]
		public void OperatorMinus_SubstractingTwoNumbers_ReturnCorrectResult() {
			var result = _sut.EvalRPN("1 2 -");

			Assert.That(result, Is.EqualTo(1));
		}
		[Test]
		public void ComplexExpression() {
			var result = _sut.EvalRPN("15 7 1 1 + - / 3 * 2 1 1 + + -");

			Assert.That(result, Is.EqualTo(4));
		}
		[Test]
		public void WhenUsedFactorialOnNumberShouldReturnCorrectResult()
		{
			var result = _sut.EvalRPN("1 !");
			Assert.AreEqual(1, result);

			var result2 = _sut.EvalRPN("2 !");
			Assert.AreEqual(2, result2);

			var result3 = _sut.EvalRPN("3 !");
			Assert.AreEqual(6, result3);

			var result4 = _sut.EvalRPN("4 !");
			Assert.AreEqual(24, result4);

			var result5 = _sut.EvalRPN("5 !");
			Assert.AreEqual(120, result5);

			var result6 = _sut.EvalRPN("6 !");
			Assert.AreEqual(720, result6);
		}
		[Test]
		public void WhenUsedFactorialOnMoreThanOneNumberShouldThrowInvalidOperationException()
        {
			Assert.Throws<InvalidOperationException>(() => _sut.EvalRPN("5 6 !"));
		}
		[Test]
		public void WhenNegativeNumberShouldThrowInvalidOperationException()
		{
			Assert.Throws<InvalidOperationException>(() => _sut.EvalRPN("-6 !"));
		}
        [Test]
        public void WhenMoreComplexExpressionShouldReturnCorrectResult()
        {
            var result = _sut.EvalRPN("15 7 + 3 5 ! + * 1 +");
            Assert.That(result, Is.EqualTo(2707));
        }
    }
}