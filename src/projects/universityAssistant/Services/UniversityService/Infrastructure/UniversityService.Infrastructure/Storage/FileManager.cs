using Core.CrossCuttingConcerns.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Json;

namespace UniversityService.Infrastructure.Storage;

public class FileManager : IFileService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public FileManager(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<List<StorageResult>> UploadAsync(IFormFileCollection formFiles)
    {
        string boundary = Guid.NewGuid().ToString();
        MultipartFormDataContent requestContent = new(boundary);

        HttpClient fileClient = _httpClientFactory.CreateClient("Files");
        fileClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", $"multipart/form-data; boundary=--{boundary}");

        foreach (IFormFile file in formFiles)
        {
            StreamContent streamContent = new(file.OpenReadStream());
            requestContent.Add(streamContent, "formFiles", file.FileName);
        }

        HttpResponseMessage response = await fileClient.PostAsync("Upload", requestContent);

        if (!response.IsSuccessStatusCode)
        {
            BusinessProblemDetails problemDetails = await response.Content.ReadFromJsonAsync<BusinessProblemDetails>();
            throw new BusinessException(problemDetails.Detail);
        }

        return await response.Content.ReadFromJsonAsync<List<StorageResult>>();
    }
}


