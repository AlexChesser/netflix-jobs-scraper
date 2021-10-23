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
                var jobPages = Newtonsoft.Json.JsonConvert.DeserializeObject<List<JobsModel>>(await File.ReadAllTextAsync(Program.FILENAME_JSON));
                List<string[]> postings = new List<string[]>();
                foreach (var jobsPage in jobPages)
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
