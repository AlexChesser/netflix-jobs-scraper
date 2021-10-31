using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.VisualBasic.FileIO;

namespace netflix_jobs_api_scraper
{

    public class JobsTextToHtmlWriter
    {
        public async Task WriteAsync()
        {
            using (TextFieldParser tfp = new TextFieldParser(Program.FILENAME_CSV))
            using (TextWriter tw = new StreamWriter(Program.FILENAME_CSV_TO_HTML))
            {
                tfp.HasFieldsEnclosedInQuotes = true;
                tfp.SetDelimiters("\t");
                string[] header = tfp.ReadFields();
                List<string[]> postings = new List<string[]>();
                while (!tfp.EndOfData)
                {
                    postings.Add(tfp.ReadFields());
                }
                await new JobsTableWriter().WriteAsync(tw, header, postings);
            }
        }
    }
}
