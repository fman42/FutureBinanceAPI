using System;
using System.Net.WebSockets;
using System.Threading;
using System.Text;
using System.Threading.Tasks;

namespace FutureBinanceAPI.Streams
{
    public class Stream : IDisposable
    {
        #region Vars
        public ExchangeEvent Event { get; } = new ExchangeEvent();

        private ClientWebSocket ClientWS { get; }
        private readonly string UserListenKey;
        private string WSUrl { get; } = "wss://stream.binancefuture.com/ws";
        #endregion

        #region Init
        public Stream(string userListenKey, string webSocketUrl)
        {
            UserListenKey = userListenKey;
            WSUrl = webSocketUrl;
        }

        public Stream(string userListenKey)
        {
            UserListenKey = userListenKey;
        }
        #endregion

        #region Methods
        public void Dispose() => ClientWS.Dispose();

        public async void ConnectToExchange(Action<ClientWebSocket> onCloseConnection)
        {
            await ClientWS.ConnectAsync(new Uri(WSUrl + $"/{UserListenKey}"), CancellationToken.None);
            while (ClientWS.State == WebSocketState.Open)
            {
                Event.Alert(await ReadMessageOfStream());
            }

            if (ClientWS.State != WebSocketState.Open) onCloseConnection(ClientWS);
        }

        private async Task<string> ReadMessageOfStream()
        {
            int defaultSizeByteArray = 300;
            byte[] defaultBytesArray = new byte[defaultSizeByteArray];
            WebSocketReceiveResult webSocketResponse = await ClientWS.ReceiveAsync(defaultBytesArray, CancellationToken.None);

            if (webSocketResponse.EndOfMessage) 
                return ToString(defaultBytesArray);

            while (defaultBytesArray.Length - webSocketResponse.Count == 0)
            {
                byte[] bytesBuffer = new byte[defaultBytesArray.Length];
                defaultBytesArray.CopyTo(bytesBuffer, 0);
                defaultBytesArray = new byte[defaultBytesArray.Length + defaultSizeByteArray];
                //bytesBuffer.CopyTo(defaultBytesArray, 0);
                webSocketResponse = await ClientWS.ReceiveAsync(defaultBytesArray, CancellationToken.None);
            }

            return ToString(defaultBytesArray);
        }

        private string ToString(byte[] bytes) => Encoding.UTF8.GetString(bytes);
        #endregion
    }
}
