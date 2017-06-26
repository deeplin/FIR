using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceInfoRetriever.Models
{
    public class Article
    {
        public string Id { get; set; }
        public string SiteName { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Link { get; set; }

        public DateTime PublishDate { get; set; }

        public override int GetHashCode()
        {
            return Content.GetHashCode();
        }
    }
}
