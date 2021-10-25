using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace netflix_jobs_api_scraper
{
    public class RequirementsGetter
    {
        public List<string> GetRequirements(string html)
        {
            var requirements = new List<string>();
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(html);
                foreach (XmlNode node in xml.SelectNodes("//li"))
                {
                    requirements.Add(node.InnerText);
                }
            }
            catch
            {
                Regex regex = new Regex("<li>(.+?)</li>", RegexOptions.Compiled | RegexOptions.Multiline);
                var matches = regex.Match(html);
                while (matches.Success) {
                    requirements.Add(matches.Groups[1].ToString());
                    matches = matches.NextMatch();
                }
            }
            return requirements;
        }
    }
}