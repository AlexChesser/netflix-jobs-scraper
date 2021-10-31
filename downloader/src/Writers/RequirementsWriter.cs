using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace netflix_jobs_api_scraper
{

    public class RequirementsWriter
    {
        public async Task WriteAsync()
        {
            using(TextWriter tr = new StreamWriter(Program.FILENAME_REQUIREMENTS)){
                string joiner = "\n";
                var getter = new RequirementsGetter();
                foreach (var jobsPage in await JobsModel.LoadJobs())
                {
                    foreach (var posting in jobsPage.records.postings)
                    {
                        List<string> req = getter.GetRequirements(posting.description);
                        await tr.WriteLineAsync(string.Join(joiner, req.ToArray()));
                    }
                }
            }
        }
    }
}
