using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace netflix_jobs_api_scraper
{

    public class JobsTableWriter
    {
        public async Task WriteAsync(TextWriter tw, string[] header, List<string[]> postings)
        {
            string joiner = "</td><td>";
            await tw.WriteLineAsync(@"<style>td{vertical-align: top;}tr:nth-child(even) {background-color: #f2f2f2;}</style>");
            await tw.WriteLineAsync("<table>");
            await tw.WriteLineAsync("<thead><tr>");
            await tw.WriteAsync("<td>");
            await tw.WriteAsync(string.Join(joiner, header));
            await tw.WriteLineAsync("<td>");
            await tw.WriteLineAsync("</tr></thead>");
            await tw.WriteLineAsync("<tbody>");
            foreach (var posting in postings)
            {
                await tw.WriteAsync("<tr><td>");
                await tw.WriteAsync(string.Join(joiner, posting));
                await tw.WriteLineAsync("</td></tr>");
            }
            await tw.WriteLineAsync("</tbody>");
            await tw.WriteLineAsync("</table>");
        }
    }
}
