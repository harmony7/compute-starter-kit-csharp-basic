using System.Net;
using HarmonicBytes.FastlyCompute;

Console.WriteLine(
    $"FASTLY_SERVICE_VERSION: {Environment.GetEnvironmentVariable("FASTLY_SERVICE_VERSION")}");

var httpRequestMessage = Invocation.GetRequest();
var reqClientInfo = Invocation.GetClientInfo();

var httpResponseMessage = new HttpResponseMessage
{
    StatusCode = HttpStatusCode.OK,
    Content = new StringContent(
        $"Received a {httpRequestMessage.Method} request from {reqClientInfo.Address}!")
};

Invocation.SendResponse(httpResponseMessage);
