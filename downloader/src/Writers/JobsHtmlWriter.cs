using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace netflix_jobs_api_scraper
{

    public class JobsHtmlWriter
    {
        public async Task WriteAsync()
        {
            using (TextWriter tw = new StreamWriter(Program.FILENAME_HTML))
            {
                List<string[]> postings = new List<string[]>();
                foreach (var jobsPage in await JobsModel.LoadJobs())
                {
                    foreach (var posting in jobsPage.records.postings)
                    {
                        postings.Add(posting.ToArray());
                    }
                }
                await new JobsTableWriter().WriteAsync(tw, Posting.Header, postings);
            }
        }
    }
}
