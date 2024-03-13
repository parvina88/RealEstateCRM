
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);

        var apiservice = builder.AddProject<Projects.RealEstate_Api>("apiservice");
        
        builder.AddProject<Projects.RealEstate_Client>("frontend")
            .WithReference(apiservice);

        builder.Build().Run();
    }
}