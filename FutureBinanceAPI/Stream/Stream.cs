using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using FutureBinanceAPI.Tools.Stream;
using FutureBinanceAPI.API;

namespace FutureBinanceAPI.Stream
{
    public class Stream : IDisposable
    {
        #region Vars
        public ExchangeEvent Events { get; } = new ExchangeEvent();

        private ClientWebSocket ClientWS { get; }

        private StreamClient Client { get; }
        #endregion

        #region Init
        public Stream(StreamClient client) => (ClientWS, Client) = (new ClientWebSocket(), client);
        #endregion

        #region Methods
        public void Dispose() => ClientWS.Dispose();

        public async void ConnectAsync(Action<ClientWebSocket> onCloseConnection)
        {
            await ClientWS.ConnectAsync(new Uri($"{Client.WSUrl}/{Client.UserListenKey}"), CancellationToken.None);

            while (ClientWS.State == WebSocketState.Open)
            {
                Events.Alert(await ReadMessageOfStreamAsync());
            }

            if (ClientWS.State != WebSocketState.Open)
                onCloseConnection(ClientWS);
        }

        private async Task<string> ReadMessageOfStreamAsync()
        {
            StreamBytes.RewriteByteArray();
            WebSocketReceiveResult webSocketResponse = await ClientWS.ReceiveAsync(StreamBytes.DefaultBytesArray, CancellationToken.None);

            if (webSocketResponse.EndOfMessage)
                return StreamBytes.BytesToString();

            while (StreamBytes.DefaultBytesArray.Length - webSocketResponse.Count == 0)
            {
                webSocketResponse = await ClientWS.ReceiveAsync(StreamBytes.ReceivedNewMessage, CancellationToken.None);
                StreamBytes.SwopArrayBytes();
            }

            return StreamBytes.BytesToString();
        }
        #endregion
    }
}
