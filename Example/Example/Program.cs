
using System.Data.SqlClient;

namespace Example
{
    internal class Program
    {
        private readonly string currentDirectory = Environment.CurrentDirectory;

        private readonly string connectionStr = string.Format("Data Source={0}, {1}; Initial Catalog={2};User ID={3};Password={4}", "127.0.0.1", 1433, "testdb", "sa", "1234");
        
        public void Run()
        {

        }

        private void CheckedDirectory()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory + @"\data");

            if (!directoryInfo.Exists) { directoryInfo.Create(); }
        }

        private void TryConnectToDatabase()
        {
            SqlConnection connection = new SqlConnection(connectionStr);

            string filename = string.Format(@"\data\db{0}.log", DateTime.Now.ToString(connectionStr));
            using (StreamWriter sw = new StreamWriter(currentDirectory + filename, true))
            {
                sw.Write("[{0}] 데이터 베이스 연결 시도...", DateTime.Now);
                connection.Open();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
