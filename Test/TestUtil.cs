using EzCodeProblems.Util;

namespace Test
{
    public class TestUtil
    {
        [Fact]
        public void TestReplaceMethodBody()
        {
            string sampleMethod =
            """
            // single-line comment int CodeInComments(int a, int b) => a + b;
            /* multi-line
               comment
                public int ThisIsCodeInComments(int a, int b)
                {
                    return a + b;
                }
            */
            public Dictionary<char, int> CountCharacters(string text)
            {
                // this body will be replaced
                var result = new Dictionary<char, int>();
                return result;
            }
            """;

            string methodWithReplacedBody = Util.ReplaceMethodBody(sampleMethod, "    // write your code here\n");
            Assert.Contains("// write your code here", methodWithReplacedBody);
            Assert.DoesNotContain("// this body will be replaced", methodWithReplacedBody);
        }
    }
}