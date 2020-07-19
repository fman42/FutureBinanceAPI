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

        private const string DefaultWSBasePoint = "wss://stream.binancefuture.com/ws";

        private string WSUrl { get; }

        private static int DefaultSizeByteArray { get; } = 600;
        #endregion

        #region Init
        public Stream(string userListenKey) : this(userListenKey, DefaultWSBasePoint) { }

        public Stream(string userListenKey, string webSocketUrl)
        {
            ClientWS = new ClientWebSocket();

            UserListenKey = userListenKey;
            WSUrl = webSocketUrl;
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
            byte[] defaultBytesArray = new byte[DefaultSizeByteArray];
            WebSocketReceiveResult webSocketResponse = await ClientWS.ReceiveAsync(defaultBytesArray, CancellationToken.None);

            if (webSocketResponse.EndOfMessage) 
                return ToString(defaultBytesArray);

            while (defaultBytesArray.Length - webSocketResponse.Count == 0)
            {
                swapBytesArray(ref defaultBytesArray);
                webSocketResponse = await ClientWS.ReceiveAsync(defaultBytesArray, CancellationToken.None);
            }

            return ToString(defaultBytesArray);
        }

        private void swapBytesArray(ref byte[] defaultByteArray)
        {
            byte[] buffer = new byte[defaultByteArray.Length];
            defaultByteArray.CopyTo(buffer, 0);

            defaultByteArray = new byte[defaultByteArray.Length + DefaultSizeByteArray];
            buffer.CopyTo(defaultByteArray, 0);
        }

        private string ToString(byte[] bytes) => Encoding.UTF8.GetString(bytes);
        #endregion
    }
}
