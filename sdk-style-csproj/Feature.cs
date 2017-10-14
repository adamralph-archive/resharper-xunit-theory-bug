using System.Collections.Generic;
using Xbehave;
using Xunit;

public class Feature
{
    [Theory]
    [InlineData(123)]
    [InlineData(456)]
    public void XunitTheoryWithTestsEvaluatedAtDiscoveryTime(int x)
    {
    }

    [Theory]
    [MemberData("Foos")]
    public void XunitTheoryWithTestsEvaluatedAtExecutionTime(Foo x)
    {
    }

    public static IEnumerable<object[]> Foos()
    {
        yield return new object[] { new Foo { Bar = 123 } };
        yield return new object[] { new Foo { Bar = 456 } };
    }

    public class Foo
    {
        public int Bar { get; set; }
    }

    [Scenario]
    public void XbehaveScenario(int one, int two, int res)
    {
        "Given AAA"
            .x(() =>
            {
                one = 1;
                two = 2;
            });

        "When BBB"
            .x(() => res = one + two);

        "Then CCC"
            .x(() => Assert.Equal(res, 3));
    }
}
