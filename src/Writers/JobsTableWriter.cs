using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace netflix_jobs_api_scraper
{

    public class JobsTableWriter
    {
        public async Task WriteAsync(TextWriter tw, string[] header, List<string[]> postings)
        {
            string joiner = "</td><td>";
            await tw.WriteLineAsync(await File.ReadAllTextAsync("./Resources/tablehead.html"));
            await tw.WriteLineAsync("<table id='demo'>");
            await tw.WriteLineAsync("<thead><tr>");
            await tw.WriteAsync("<td>");
            await tw.WriteAsync(string.Join(joiner, header));
            await tw.WriteLineAsync("<td>");
            await tw.WriteLineAsync("</tr></thead>");
            await tw.WriteLineAsync("<tbody>");
            Regex rxp = new Regex(@">(\d+)<\/a>", RegexOptions.Compiled);
            RequirementsGetter req = new RequirementsGetter();
            foreach (var posting in postings)
            {
                await tw.WriteAsync($"<tr><td>");
                posting[posting.Length - 1] += $"<input type='checkbox' class='yes' value='{rxp.Match(posting[0]).Groups[1].Value}'>";
                await tw.WriteAsync(string.Join(joiner, posting));
                await tw.WriteLineAsync($"</td></tr>");
            }
            await tw.WriteLineAsync("</tbody>");
            await tw.WriteLineAsync("</table>");
            await tw.WriteLineAsync(await File.ReadAllTextAsync("./Resources/tablefoot.html"));
        }
    }
}
