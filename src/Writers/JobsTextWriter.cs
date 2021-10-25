using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace netflix_jobs_api_scraper
{

    public class JobsTextWriter
    {
        public async Task WriteAsync()
        {
            using(TextWriter tr = new StreamWriter(Program.FILENAME_CSV)){
                string joiner = "\t";
                await tr.WriteLineAsync(string.Join(joiner, Posting.Header));
                foreach (var jobsPage in await JobsModel.LoadJobs())
                {
                    foreach (var posting in jobsPage.records.postings)
                    {
                        await tr.WriteLineAsync(string.Join(joiner, posting.ToArray()));
                    }
                }
            }
        }
    }
}
