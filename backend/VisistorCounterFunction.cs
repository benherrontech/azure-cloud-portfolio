using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace VisitorCounterFunction
{
    public class VisistorCounterFunction
    {

        [Function("VisistorCounterFunction")]
        [CosmosDBOutput("CloudPortfolioDB", "Counter", Connection = "CosmosDBConnection")]
        public async Task<VisitorCounterItem> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req,
        [CosmosDBInput(databaseName: "CloudPortfolioDB", containerName: "Counter", Connection  = "CosmosDBConnection", Id = "1", PartitionKey = "1")] VisitorCounterItem visitorCounterItem)
        {

            // increment count
            visitorCounterItem.Count++;

            // write an http response
            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(visitorCounterItem);

            // update the item in CosmosDB
            return visitorCounterItem;
        }
    }
}
