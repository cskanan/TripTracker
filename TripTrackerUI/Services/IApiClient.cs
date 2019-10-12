using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TripTracker.BackService.Models;

namespace TripTrackerUI.Services
{
    public interface IApiClient
    {
        Task<List<TripTracker.BackService.Models.Trip>> GetTripsAsync();
        Task<TripTracker.BackService.Models.Trip> GetTripAsync();
    }

    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<List<Trip>> GetTripsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Trip> GetTripAsync()
        {
            throw new NotImplementedException();
        }
    }
}
