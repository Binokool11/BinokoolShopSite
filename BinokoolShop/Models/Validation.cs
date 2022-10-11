using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.RegularExpressions;

namespace BinokoolShop.Models.Entity
{
    public class Validation
    {
        public bool ShowError { get; set; }
        public string patternEmail = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        public string patternPhone = @"^(\+)?((\d{2,3}) ?\d|\d)(([ -]?\d)|( ?(\d{2,3}) ?)){5,12}\d$";
        public ModelStateDictionary modelError { get; set; } = null;
        public Validation() { }

    }
}
