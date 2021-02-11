using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Common.Extensions
{
    public static class StringSerizationExtensions
    {
        private static readonly Lazy<JsonSerializerOptions> jsonSerializerOptions = new Lazy<JsonSerializerOptions>(() => new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        public static TModel ToType<TModel>(this string content, bool caseInsensitive = true) => JsonSerializer.Deserialize<TModel>(content, caseInsensitive ? jsonSerializerOptions.Value : null);
    }
}
