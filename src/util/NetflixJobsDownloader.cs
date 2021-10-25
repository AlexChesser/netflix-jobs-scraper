using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace netflix_jobs_api_scraper
{

    public class NetflixJobsDownloader
    {
        private async Task<JobsModel> GetJobs(int? page = null)
        {
            using (HttpClient client = new HttpClient())
            {
                string pagevalue = null;
                if (page.HasValue)
                {
                    pagevalue = $"&page={page}";
                }
                client.BaseAddress = new Uri($"https://jobs.netflix.com/api/search?q=senior software engineer{pagevalue}");
                var response = await client.GetAsync("");
                if (response != null)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<JobsModel>(body);
                }
                return null;
            }
        }

        public async Task Run()
        {
            using (var fs = File.CreateText(Program.FILENAME_JSON))
            {
                var AllJobs = new List<JobsModel>();
                Console.WriteLine("Creating HttpClient");
                var jobs = await GetJobs();
                AllJobs.Add(jobs);
                for (int i = 2; i <= jobs.info.postings.num_pages; i++)
                {
                    Console.WriteLine($"adding page {i}");
                    AllJobs.Add(await GetJobs(i));
                }
                await fs.WriteAsync(JsonConvert.SerializeObject(AllJobs));
            }
        }
    }
}
