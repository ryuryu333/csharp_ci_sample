using Xunit;
using MyConsoleApp;
using System.Collections;
using System.Collections.Generic;
using Xunit.Abstractions;
using System;

namespace MyTest
{
    public class CalculatorTest
    {
        // MyConsoleApp のテストしたいクラスをインスタンス化
        private readonly Calculator _calculator = new();

        private readonly ITestOutputHelper _output;

        public CalculatorTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void AddTestLog()
        {
            Assert.Equal(3, _calculator.Add(1, 2));
            _output.WriteLine("Log output is visible");
            Console.WriteLine("This one will not be shown");
        }

        [Fact(DisplayName = "Custom display name is shown")]
        public void AddTestDisplayName()
        {
            Assert.Equal(3, _calculator.Add(1, 2));
        }

        [Fact]
        public void AddTestFact()
        {
            Assert.Equal(3, _calculator.Add(1, 2));
        }

        // InlineData を使ったパターン
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(2, 3, 5)]
        public void AddTestTheory(int input1, int input2, int expected)
        {
            int actual = _calculator.Add(input1, input2);
            Assert.Equal(expected, actual);
        }

        // MemberData を使ったパターン
        [Theory]
        [MemberData(nameof(AddTestMemberData))]
        public void AddTestMember(int a, int b, int expected)
        {
            Assert.Equal(expected, _calculator.Add(a, b));
        }

        public static IEnumerable<object[]> AddTestMemberData =>
            new List<object[]>
            {
                    new object[] { 1, 2, 3 },
                    new object[] { 5, 7, 12 }
            };

        // ClassData を使ったパターン
        [Theory]
        [ClassData(typeof(AddTestData))]
        public void AddTestClassData(int a, int b, int expected)
        {
            int result = _calculator.Add(a, b);
            Assert.Equal(expected, result);
        }
    }

    // ClassData 用のテストデータクラス
    public class AddTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 10, 20, 30 };
            yield return new object[] { -5, 5, 0 };
            yield return new object[] { 100, 200, 300 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
