using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Etechnosoft.Common.Infrastructure.HttpHelper
{
    public class PatchContent : StringContent
    {
        public PatchContent(object value)
            : base(JsonConvert.SerializeObject(value), Encoding.UTF8,
                "application/json-patch+json")
        {
        }
    }
}