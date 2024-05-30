using Tashgheel_Api.Interface;
/*
namespace Tashgheel_Api.DataUpdateHub;

using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;


    public class DataHub<T,TId> : Hub
    {
        private readonly IGenericRepository<T,TId> _genericRepository;

        public DataHub(IGenericRepository<T,TId> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        // Simulated method to periodically update data
        public async Task UpdateDataAutomatically()
        {
            while (true)
            {
                // Simulate fetching new data
                var newData = _genericRepository.GetAll();

                // Broadcast the updated data to all connected clients
                await Clients.All.SendAsync("ReceiveDataUpdate", newData);

                // Delay for a certain period before fetching new data again
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }
    }
*/
