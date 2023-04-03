using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace DM365News.Database
{
    public static class JsonProvider
    {
        public async static Task SerializeAsync<T>(string fileName, IEnumerable<T> data)
        {
            using var createStream = File.Create(DbConstants.PathToDatabase + fileName);

            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };

            await JsonSerializer.SerializeAsync(createStream, data, options);
            await createStream.DisposeAsync();
        }

        public async static Task<T> DeserializeAsync<T>(string fileName)
        {
            using var openStream = File.OpenRead(DbConstants.PathToDatabase + fileName);
            return await JsonSerializer.DeserializeAsync<T>(openStream);
        }
    }
}