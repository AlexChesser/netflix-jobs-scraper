using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace netflix_jobs_api_scraper
{
    public class Program
    {
        public static string FILENAME_JSON = "./data/download-jobs.json";
        public static string FILENAME_CSV = "./data/jobs.txt";
        public static string FILENAME_HTML = "./data/jobs.html";
        public static string FILENAME_CSV_TO_HTML = "./data/filtered-jobs.html";

        static async Task Main(string[] args)
        {
            if(args.Contains("d")){
                Console.WriteLine("Starting the query runner");
                var qr = new NetflixJobsDownloader();
                await qr.Run();
            }

            if(args.Contains("csv")){
                await new JobsTextWriter().WriteAsync();
            } 
            if (args.Contains("html")) {
                await new JobsHtmlWriter().WriteAsync();
            }
            if (args.Contains("csv2html")) {
                await new JobsTextToHtmlWriter().WriteAsync();
            }
        }
    }
}
