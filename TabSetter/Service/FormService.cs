using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TabSetter.Service.IService;

namespace TabSetter.Service
{
    public class FormService : IFormService
    {
        private readonly HttpClient _client;

        public FormService(HttpClient client)
        {
            _client = client;
        }

        public async Task<FormDto> GetForm(int formId)
        {
            var response = await _client.GetAsync($"api/form/get/{formId}");
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var form = JsonConvert.DeserializeObject<FormDto>(content);
                return form;
            }
            throw new Exception("An error occurred getting the form.");
        }

        public async Task ResetForm(int formId)
        {
            var response = await _client.PostAsync($"api/form/reset/{formId}", null);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("An error occurred resetting the form.");
            }
        }

        public async Task SaveForm(FormDto form)
        {
            var content = JsonConvert.SerializeObject(form);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/form/save", bodyContent);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("An error occurred saving the form.");
            }
        }
    }
}
