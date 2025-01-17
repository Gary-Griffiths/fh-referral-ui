﻿using FamilyHubs.ReferralUi.Ui.Models;
using System.Text.Json;

namespace FamilyHubs.ReferralUi.Ui.Services.Api
{
    public interface IPostcodeLocationClientService
    {
        Task<PostcodeApiModel> LookupPostcode(string postcode);
    }
    public class PostcodeLocationClientService : ApiService, IPostcodeLocationClientService
    {
        public PostcodeLocationClientService(HttpClient client)
            : base(client)
        {
            client.BaseAddress = new Uri("http://api.postcodes.io");
        }

        public async Task<PostcodeApiModel> LookupPostcode(string postcode)
        {
            using var response = await _client.GetAsync($"/postcodes/{postcode}", HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();

#pragma warning disable CS8603 // Possible null reference return.
            return await JsonSerializer.DeserializeAsync<PostcodeApiModel>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
#pragma warning restore CS8603 // Possible null reference return.

        }
    }
}
