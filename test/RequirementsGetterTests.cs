using System;
using NUnit.Framework;

namespace netflix_jobs_api_scraper
{
    public class RequirementsGetterTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetsRequirements()
        {
            RequirementsGetter r = new RequirementsGetter();
            var results = r.GetRequirements("<div><ul><li>here</li></ul></div>");
            Assert.IsTrue(results.Count == 1, "expected a string length 1");
            Assert.IsTrue(results[0] == "here", "expected the word 'here'");
        }

        [Test]
        public void GetsRequirementsWithBrokenHtml()
        {
            RequirementsGetter r = new RequirementsGetter();
            var results = r.GetRequirements("<div><ul><li>here</li></ul><div>");
            Console.WriteLine(string.Join("\n", results));
            Assert.IsTrue(results.Count == 1, "expected a string length 1");
            Assert.IsTrue(results[0] == "here", "expected the word 'here'");
        }
  
        [Test]
        public void GetsRequirementsWithBrokenHtml_MultiLI()
        {
            RequirementsGetter r = new RequirementsGetter();
            var results = r.GetRequirements("<div><ul><li>here1</li><li>here2</li></ul><div>");
            Console.WriteLine(string.Join("\n", results));
            Assert.IsTrue(results.Count == 2, "expected a string length 1");
            Assert.IsTrue(results[0] == "here1", "expected the word 'here1'");
            Assert.IsTrue(results[1] == "here2", "expected the word 'here2'");
        }

    }
}