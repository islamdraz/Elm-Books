using System.Data;
using System.Text.Json;
using Dapper;

namespace ElmTest.Infrastructure.Settings.DapperCustomHandlers
{
    public class JsonObjectTypeHandler<T> : SqlMapper.TypeHandler<T>
    {
        public override T Parse(object value)
        {
            var json = value.ToString();
            return JsonSerializer.Deserialize<T>(json);
        }

        public override void SetValue(IDbDataParameter parameter, T value)
        {
            parameter.Value = JsonSerializer.Serialize(value);
        }
    }
}