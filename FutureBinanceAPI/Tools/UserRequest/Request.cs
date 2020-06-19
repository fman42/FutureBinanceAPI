﻿using FutureBinanceAPI.API;
using FutureBinanceAPI.Tools.HttpBuilder;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

namespace FutureBinanceAPI.Tools.UserRequest
{
    public class Request
    {
        private Client Client { get; }
        private IHttpBuilder Builder { get; }
        public Request(Client client)
        {
            Client = client;
            Builder = client is AuthClient ? (IHttpBuilder) new AuthBuilder((AuthClient)Client, Client.DebugMode) 
                : (IHttpBuilder) new DefaultClient(Client.DebugMode);
        }

        public Task<string> Send(IEnumerable<KeyValuePair<string, string>> args, HttpMethod method, string endpoint)
        {
            HttpRequestMessage message = Builder.MakeRequest(method, endpoint, args);
            return Client.SendRequest(message);
        }
    }
}