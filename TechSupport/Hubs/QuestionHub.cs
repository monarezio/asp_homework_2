using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace TechSupport.Hubs
{
    public class QuestionHub: Hub
    {
        public async Task Increment()
        {
            await Clients.All.SendAsync("Increment");
        }

        public async Task Decrement()
        {
            await Clients.All.SendAsync("Decrement");
        }
    }
}