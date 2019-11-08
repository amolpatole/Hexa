using CatelogMicroAPI.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CatelogMicroAPI.CustomFormatters
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            this.SupportedEncodings.Add(Encoding.UTF8);
            this.SupportedEncodings.Add(Encoding.Unicode);
            this.SupportedMediaTypes.Add("text/csv");
            this.SupportedMediaTypes.Add("application/csv");
        }
        protected override bool CanWriteType(Type type)
        {
            if(typeof(CatelogItem).IsAssignableFrom(type) || typeof(IEnumerable<CatelogItem>).IsAssignableFrom(type))
            {
                return true;
            }
            return false;
        }
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var buffer = new StringBuilder();
            var response = context.HttpContext.Response;
            buffer.Append("Id, Name, Price, Quanity, ReorderLevel, ManufacturingDate, ImageUrl" + Environment.NewLine);
            if (context.Object is CatelogItem)
            {
                var item = context.Object as CatelogItem;
                buffer.Append($"{item.Id}, {item.Name}, {item.Price}, {item.Quantity}, {item.ReorderLevel}, {item.ManufactruingDate}, {item.ImageUrl} {Environment.NewLine}");
            }
            else
            {
                var items = context.Object as IEnumerable<CatelogItem>;
                foreach (var item in items)
                {
                    buffer.Append($"{item.Id}, {item.Name}, {item.Price}, {item.Quantity}, {item.ReorderLevel}, {item.ManufactruingDate}, {item.ImageUrl} {Environment.NewLine}");
                } 
            }
            await response.WriteAsync(buffer.ToString(), selectedEncoding);
        }
    }
}
