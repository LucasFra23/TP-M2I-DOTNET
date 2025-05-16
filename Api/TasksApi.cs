using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TP_M2I_DOTNET.Models;

namespace TP_M2I_DOTNET.Api
{
    public class TasksApi
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<TasksApi> _logger;

        public TasksApi(IHttpClientFactory httpClientFactory, ILogger<TasksApi> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<IEnumerable<TaskTP>> GetTasksAsync()
        {
            using HttpClient client = _httpClientFactory.CreateClient("tasks-api");
            using HttpResponseMessage response = await client.GetAsync("tasks");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                IEnumerable<TaskTP>? tasksCollection = JsonSerializer.Deserialize<IEnumerable<TaskTP>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (tasksCollection != null)
                {
                    return tasksCollection;
                }
                else
                {
                    throw new Exception("Error deserializing tasks");
                }
            }
            else
            {
                throw new Exception("Error fetching tasks");
            }
        }

        public async Task<bool> AddTask(TaskTP task)
        {
            using HttpClient client = _httpClientFactory.CreateClient("tasks-api");
            var json = JsonSerializer.Serialize(task);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            using HttpResponseMessage response = await client.PostAsync("tasks", content);
            return response.IsSuccessStatusCode;
        }
    }
}
