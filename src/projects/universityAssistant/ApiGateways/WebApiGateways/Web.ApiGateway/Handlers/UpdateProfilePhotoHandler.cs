using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Web.ApiGateway.Extensions;
using Web.ApiGateway.Requests;
using Web.ApiGateway.Responses;

namespace Web.ApiGateway.Handlers
{
    public class UpdateProfilePhotoHandler : DelegatingHandler
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public UpdateProfilePhotoHandler(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Uri identityRequestUri = request.RequestUri;

            request.RequestUri = new Uri($"{_configuration.GetValue<string>("Urls:Files")}Upload");
            HttpResponseMessage send = await base.SendAsync(request, cancellationToken);

            if (!send.IsSuccessStatusCode)
                return send;

            string storageStringResult = await send.Content.ReadAsStringAsync(cancellationToken);
            List<StorageResult>? storageResults = JsonConvert.DeserializeObject<List<StorageResult>>(storageStringResult);

            UpdateProfilePhotoCommandRequest updateRequest = new(storageResults.First().URL);

            HttpClient client = _httpClientFactory.CreateClient("");
            HttpResponseMessage? httpRes = await client.PostAsJsonAsync(identityRequestUri.ToString(), updateRequest, cancellationToken);

            if (!httpRes.IsSuccessStatusCode)
            {
                var result = await _httpClientFactory.CreateClient("Files").GetResponseAsync<bool>($"Delete?fileNameForStorage={storageResults.First().FileNameForStorage}");
                return httpRes;
            }

            return send;
        }
    }
}


