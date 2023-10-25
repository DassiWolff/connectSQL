using connectSQL;
internal class Program
{
    private static void Main(string[] args)
    {
        string connectionString =
             "Data Source=SRV2\\PUPILS;Initial Catalog=Shops;Integrated Security=True";
        Shop us = new Shop();

        int r = us.InsertData(connectionString);
            Console.WriteLine(r);
        us.readData(connectionString);
    }
}
