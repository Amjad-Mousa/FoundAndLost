using MongoDB.Driver;

namespace LostAndFound.API.Services
{
    public class MongoDBService
    {
        private readonly IMongoDatabase _database;

        public MongoDBService(IConfiguration configuration)
        {
            try
            {
                var connectionString = configuration.GetSection("MongoDBSettings:ConnectionString").Value;
                var client = new MongoClient(connectionString);
                _database = client.GetDatabase("LostAndFoundDB");

                Console.WriteLine("✅ MongoDB Connected Successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ MongoDB Connection Failed: {ex.Message}");
                throw;
            }
        }

        public async Task TestConnection()
        {
            try
            {
                // محاولة جلب قائمة databases للتأكد من الاتصال
                var client = _database.Client;
                var databases = await client.ListDatabaseNamesAsync();
                var dbList = await databases.ToListAsync();

                Console.WriteLine($"✅ Connection Test Passed! Available databases: {dbList.Count}");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Connection Test Failed: {ex.Message}");
                throw;
            }
        }
    }
}