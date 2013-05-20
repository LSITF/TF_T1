
namespace ConApp_VS2k8
{
    public class MsiDbChanger
    {
        public static void Test(string msiPath)
        {
            using (var database = new Database(msiPath, DatabaseOpenMode.Direct))
            {
            }
        }
    }
}
