using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace FunctionApp1
{
    public static class MyBlobTriggerFunc
    {
        [FunctionName("MyBlobTriggerFunc")]
        public static void Run(
            [BlobTrigger("myfiles/{name}", Connection = "mystorageaccount")]Stream myBlob, 
            string name, 
            TraceWriter log)
        {
            log.Info($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}
