﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceInfoRetriever.Models
{
    public class WebSite
    {
        public int Id { get; set; }

        public string SiteName { get; set; }

        public string SiteAddress { get; set; }

        public string Keyword { get; set; }
    }
}
