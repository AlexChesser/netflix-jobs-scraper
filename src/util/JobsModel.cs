using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace netflix_jobs_api_scraper
{
    public class JobsModel
    {
        public int record_count { get; set; }
        public Records records { get; set; }
        public Info info { get; set; }
        public Errors errors { get; set; }

        public static async Task<List<JobsModel>> LoadJobs() => JsonConvert.DeserializeObject<List<JobsModel>>(await File.ReadAllTextAsync(Program.FILENAME_JSON));
        public static Dictionary<string, Posting> MapJobs(List<JobsModel> jobs)
        {
            var postmap = new Dictionary<string, Posting>();
            foreach (var j in jobs)
            {
                foreach (var p in j.records.postings)
                {
                    postmap.Add(p.id, p);
                }
            }
            return postmap;
        }

    }

    public class Records
    {
        public List<Posting> postings { get; set; }
    }

    public class Posting
    {
        public static string[] Header
        {
            get
            {
                return new string[] {
                    "external_id",
                    "days old",
                    "status",
                    "text",
                    "location",
                    "organization",
                    "team",
                    "subteam",
                    "description"
                };
            }
        }

        private string JoinIf(string[] data, string prepend = "")
        {
            string output = data == null ? "" : string.Join("|", data);
            return output.Length > 0 ? $"{prepend}{output}" : "";
        }

        public string[] ToArray()
        {
            return new string[] {
                $@"""<a href='https://jobs.netflix.com/jobs/{external_id}'>{external_id}</a>""",
                $@"""{(int)(DateTime.Now - created_at).TotalDays}""",
                $@"""{Status}""",
                $@"""{text}""",
                $@"""{location}{JoinIf(alternate_locations, "|")}""",
                $@"""{JoinIf(organization)}""",
                $@"""{JoinIf(team)}""",
                $@"""{JoinIf(subteam)}""",
                $@"""{description.Replace("\t", " ").Replace(@"""", @"""""")}"""
            };
        }

        public string Status { get; set; }
        public string text { get; set; }
        public string lever_id { get; set; }
        public string[] team { get; set; }
        public string slug { get; set; }
        public string external_id { get; set; }
        public string description { get; set; }
        public string search_text { get; set; }
        public string state { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime created_at { get; set; }
        public string location { get; set; }
        public string[] organization { get; set; }
        public string[] subteam { get; set; }
        public string lever_team { get; set; }
        public string[] alternate_locations { get; set; }
        public string _index { get; set; }
        public string _type { get; set; }
        public float _score { get; set; }
        public object _version { get; set; }
        public object _explanation { get; set; }
        public object sort { get; set; }
        public Highlight highlight { get; set; }
        public string id { get; set; }
    }

    public class Highlight
    {
        public string text { get; set; }
        public string slug { get; set; }
        public string lever_team { get; set; }
        public string subteam { get; set; }
        public string team { get; set; }
        public string description { get; set; }
        public string search_text { get; set; }
        public string organization { get; set; }
    }

    public class Info
    {
        public Postings postings { get; set; }
    }

    public class Postings
    {
        public string query { get; set; }
        public int current_page { get; set; }
        public int num_pages { get; set; }
        public int per_page { get; set; }
        public int total_result_count { get; set; }
        public Facets facets { get; set; }
    }

    public class Facets
    {
        public Dictionary<string, int> location { get; set; }
        public Dictionary<string, int> team { get; set; }
    }

    public class Errors
    {
    }
}