using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagement.Web.Helpers
{
    public static class SelectListItemsConverterExtensions
    {
        public static SelectList GetSelecteItems<TModel>(this IEnumerable<TModel> items,string selectedValue,string dataTextField)
        {
            return new SelectList(items, selectedValue, dataTextField);
        }
    }
}
