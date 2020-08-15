using System.Text;

namespace FutureBinanceAPI.Tools.Stream
{
    internal static class StreamBytes
    {
        #region Var
        public static int DefaultSizeArray => 300;

        public static byte[] DefaultBytesArray;

        public static byte[] ReceivedNewMessage = new byte[DefaultSizeArray];
        #endregion

        #region Methods
        public static void RewriteByteArray()
        {
            DefaultBytesArray = new byte[DefaultSizeArray];
            ReceivedNewMessage = new byte[DefaultSizeArray];
        }

        public static void SwopArrayBytes()
        {
            byte[] buffer = new byte[DefaultBytesArray.Length];
            DefaultBytesArray.CopyTo(buffer, 0);

            DefaultBytesArray = new byte[DefaultBytesArray.Length + DefaultSizeArray];
            buffer.CopyTo(DefaultBytesArray, 0);
            ReceivedNewMessage.CopyTo(DefaultBytesArray, DefaultBytesArray.Length - ReceivedNewMessage.Length);
        }

        public static string BytesToString() => Encoding.UTF8.GetString(DefaultBytesArray);
        #endregion
    }
}
