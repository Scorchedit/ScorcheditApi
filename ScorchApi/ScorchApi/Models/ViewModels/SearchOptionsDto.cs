using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScorchApi.Models.ViewModels
{
    public class SearchOptionsDto
    {
        public IList<SearchOptionsModel> Categories { get; set; }
        public IList<SearchOptionsModel> Tags { get; set; }
        public double Distance { get; set; }
    }
    public class SearchOptionsModel
    {
        public string Key { get; set; }
        public bool Value { get; set; }
        public int Type { get; set; }
    }
}