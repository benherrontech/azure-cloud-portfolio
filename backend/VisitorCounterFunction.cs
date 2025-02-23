using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace VisitorCounterFunction
{
    public class VisitorCounterFunction
    {
        [Function("VisitorCounterFunction")]
        [CosmosDBOutput("CloudPortfolioDB", "Counter", Connection = "CosmosDBConnection")]
        public async Task<VisitorCounterItem> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req, 
        [CosmosDBInput(databaseName: "CloudPortfolioDB", containerName: "Counter", Connection  = "CosmosDBConnection", Id = "1", PartitionKey = "1")] VisitorCounterItem visitorCounterItem)
        {

            // Increment the visitor count
            visitorCounterItem.Count++;

            // Write new count to HTTP response
            var response = req.CreateResponse();
            await response.WriteAsJsonAsync(visitorCounterItem);

            // Return the visitor count to the client / browser
            return visitorCounterItem;

        }
    }
}
