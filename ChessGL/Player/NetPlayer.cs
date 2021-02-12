using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace ChessGL.Player
{
    class NetPlayer
    {
        private static HttpClient client;
        public NetPlayer()
        {
            client = new HttpClient();
        }
        async public Task<string> Get()
        {
            var responseString = await client.GetStringAsync("http://localhost:5000/api/Orders");
            return responseString;
        }
        async public Task<string> Post(string input)
        {
            //var json_serializer = new JsonSerializer();
            var x = JsonSerializer.Serialize<EmailClass>(value: new EmailClass {Email = input });
            //var d = new OrderEmail("borowik@mail.ru");
            
            var response = await client.PostAsync("http://localhost:5000/api/Orders", new StringContent(x, Encoding.UTF8, "application/json"));
            return response.StatusCode.ToString();
        }
        
    }
    class OrderEmail
    {
        public string email;
        public OrderEmail(string email)
        {
            this.email = email;
        }
    }
    class EmailClass
    {
        public string Email { get; set; }
    }
}
