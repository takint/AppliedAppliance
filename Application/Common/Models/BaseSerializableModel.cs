using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Application.Common.Models
{
    public abstract class BaseSerializableModel<TModel>
    {
        public virtual string Serialize() => JsonSerializer.Serialize(this);

        public virtual StringContent ToJsonStringContent() => new StringContent(Serialize(), Encoding.UTF8, "application/json");
    }
}