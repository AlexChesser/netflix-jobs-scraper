using System;
using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;

namespace netflix_jobs_api_scraper
{
    public class JobsModelTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetPostingIds()
        {
            // var foo = await JobsModel.LoadPostingIDs();
            // Assert.IsTrue(foo.Count == 160, $"expected 160 records in {Program.FILENAME_JSON} got {foo.Count}");
        }

        
    }
}