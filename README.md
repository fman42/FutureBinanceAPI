## Future Binance API

![GitHub](https://img.shields.io/github/license/fman42/FutureBinanceAPI?logo=1)
![Nuget](https://img.shields.io/nuget/v/FutureBinanceAPI?logo=1)

<img src="./icon.png" width="200px">

This library allows to you use simply an API of crypto exchange **Future Binance**

In this moment the library supports main methods of API and has a custom request

## 0. Clients

There are 3 clients: **AuthClient**, **DefaultClient** and **StreamClient**. 

AuthClient has API-key and Secret-Key for HTTP-request.   
DefaultClient will use for non-auth request(**Endpoint's Market** and etc...)  
StreamClient will use for stream events(see **4. Stream**)

**Note**:
To set parametr **"useTestnet"** in **true** for use API of Binance Futures Testnet(https://testnet.binancefuture.com). Else if you use the main exchange (https://www.binance.com/ru/futures/BTCUSDT) then set **"useTestnet"** in **false** or just ignore it

In depending of type a constructor has another arguments:
```csharp
AuthClient(string _APIKey, string _SecretKey, bool useTestnet = false)
...
DefaultClient(bool useTestnet = false)
...
StreamClient(string userListenKey, bool useTestnet = false)
...
StreamClient(string userListenKey, string webSocketUrl)
```

Create a client:
```csharp
AuthClient authClient = new AuthClient("my_api_key", "my_secret_key"); // Create the client for an auth request
DefaultClient defaultClient = new DefaultClient(); // Create the client for no auth request
StreamClient streamClient = new StreamClient("listener_key"); // Create the client for stream events
```

You can change **RecvWindow** for a client
```csharp
...
authClient.RecvWindow = 5000;
```

## 1. EndPoints

Using a client object(**IClient**) you can use anymore endpoint. A list of endpoints:

1) TickerEndPoint
2) TradeEndPoint
3) OrderEndPoint
4) AccountEndPoint
5) StreamEndPoint

### 1.1. TickerEndPoint
```csharp
DefaultClient client = new DefaultClient(true); // Create a default client
TickerEndPoint market = new TickerEndPoint(client); // Create a market endpoint
```

The endpoint has methods:

**GetPriceTicker**

Fetch latest price for a symbol or symbols.

```csharp
public async Task<IEnumerable<PriceTicker>> GetPriceTickerAsync()
public async Task<PriceTicker> GetPriceTickerAsync(TraidingPair symbol)
```
Example:
```csharp
...
IEnumerable<PriceTicker> priceSymbols = await market.GetPriceTickerAsync();
PriceTicker priceSymbol = await market.GetPriceTickerAsync(TraidingPair.BTCUSDT);
```

**GetBookTicker**

Fetch best price/qty on the order book for a symbol or symbols.
```csharp
public async Task<IEnumerable<BookTicker>> GetBookTickerAsync()
public async Task<BookTicker> GetBookTickerAsync(TraidingPair symbol)
```

Example:
```csharp
...
IEnumerable<BookTicker> bestPriceForSymbols = await market.GetBookTickerAsync();
BookTicker bestPrice = await market.GetBookTickerAsync(TraidingPair.BTCUSDT);
```

### 1.2. TradeEndPoint

**AuthClient is mandatory for this endpoint**
```csharp
AuthClient client = new AuthClient("API_key", "Secret_key", true); // Create an auth client
TradeEndPoint trade = new TradeEndPoint(client); // Create a trade endpoint
```

The endpoint has methods:

**SetLeverage**

Will set a leverage for a given symbol
```csharp
public async Task<Leverage> SetLeverageAsync(TraidingPair symbol, int value)
```

Example:
```csharp
...
Leverage setLeverage = await trade.SetLeverageAsync(TraidingPair.BTCUSDT, 25); // Set 25 leverage for BTCUSDT
```

**SetMarginType**

Will set a margin type(**CROSSED** or **ISOLATED**) for a given symbol
```csharp
public async Task<bool> SetMarginTypeAsync(TraidingPair symbol, MarginType marginType)
```

Example:
```csharp
...
public bool changedMarginType = trade.SetMarginTypeAsync(TraidingPair.BTCUSDT, MarginType.CROSSED); // Set a margin type CROSSED
```

**ModifiyIsolatedPositionMarge**
```csharp
public async Task<bool> ModifiyIsolatedPositionMarge(TraidingPair traidingPair, decimal amount, int type, PositionSide positionSide = PositionSide.BOTH)
```

**GetMarginChangesAsync**

Get history of changes margin positions.
**startTime** and **endTime** have unix format

**limit** can contain a number at most 500
```csharp
public async Task<IEnumerable<MarginChange>> GetMarginChangesAsync(TraidingPair traidingPair, int limit = 100)

public async Task<IEnumerable<MarginChange>> GetMarginChangesAsync(TraidingPair traidingPair, int type, int limit = 100)

public async Task<IEnumerable<MarginChange>> GetMarginChangesAsync(TraidingPair traidingPair, int type, long startTime, long endTime, int limit = 100)
```

### 1.3. OrderEndPoint
**AuthClient is mandatory for this endpoint**

```csharp
AuthClient client = new AuthClient("API_key", "Secret_key", true); // Create an auth client
OrderEndPoint order = new OrderEndPoint(client); // Create an order endpoint
```

**Set**

Will send a new order to exchange. To create an order in code, you need create an object from **FutureBinanceAPI.Models.Orders** namespace. **_Each an order has own class_** (See **1.3.1**)

```csharp
public async Task<Order> SetAsync(Orders.IOrder order)
```

Example:
```csharp
...
MarketOrder marketOrder = new MarketOrder(TraidingPair.BTCUSDT, 0.100m); // Create a market order
Order newOrder = await order.SetAsync(marketOrder); // Send our market order to an exchange

Console.WriteLine(newOrder.OrderId); // We received response from exchange and will write in a console
```

#### 1.3.1. Types of orders:
**-MarketOrder**
```csharp
public MarketOrder(TraidingPair symbol, Side side, decimal quantity)
```

**-LimitOrder**
```csharp
public LimitOrder(TraidingPair symbol, Side side, decimal quantity, decimal price, TimeInForceType timeInForce)
```

**-StopOrder**
```csharp
public StopOrder(TraidingPair symbol, Side side, decimal quantity, decimal price, decimal stopPrice)
```

**-TakeProfit**
```csharp
public TakeProfit(TraidingPair symbol, Side side, decimal quantity, decimal price, decimal stopPrice)
```

**-StopMarket**
```csharp
public StopMarket(TraidingPair symbol, Side side, decimal quantity, decimal stopPrice)
```

**-TakeProfitMarket**
```csharp
public TakeProfitMarket(TraidingPair symbol, Side side, decimal quantity, decimal stopPrice)
```

**-TrailingStopMarket**
```csharp
public TrailingStopMarket(TraidingPair symbol, Side side, decimal quantity, decimal callbackRate)
```

**Get**

Fetch info of order from an exchange
```csharp
public async Task<Order> GetAsync(TraidingPair symbol, long orderId)
```

Example:
```csharp
...
Order order = await order.GetAsync(TraidingPair.BTCUSDT, 10000045);
```

**Cancel**

Will cancel a given order or all
```csharp
public async Task<Order> CancelAsync(TraidingPair symbol, long orderId)
public async Task<bool> CancelAsync(TraidingPair symbol)
```

Example:
```csharp
...
Order canceledOrder = await order.CancelAsync(TraidingPair.BTCUSDT, 10000045);
bool AreCanceledAllOrders = await order.CancelAsync(TraidingPair.BTCUSDT);
``` 

### 1.4. AccountEndPoint

**AuthClient is mandatory for this endpoint**
```
AuthClient client = new AuthClient("API_key", "Secret_key", true); // Create an auth client
AccountEndPoint account = new AccountEndPoint(client); // Create an account endpoint
```

**Get**
```csharp
public async Task<Account> GetAsync()
```

```csharp
...
Account account = await account.GetAsync();
```
### 1.5. StreamEndPoint

This endpoint has methods for working with stream FutureBinance. You can start stream, delete strean and update stream's key

```csharp
AuthClient client = new AuthClient("apikey", "secretkey");
StreamEndPoint streamPoint = new StreamEndPoint(client); // only AuthClient
```

To get **your_listened_key** you need use method:

**StartAsync**

Close old connection tokens and create a new connection with token(listenKey)
```csharp
public Task<string> StartAsync()
```

Example
```csharp
AuthClient client = new AuthClient("apikey", "secretkey");
StreamEndPoint streamPoint = new StreamEndPoint(client); // only AuthClient
string listenKey = await streamPoint.StartAsync();
```

**DeleteAsync**

Close the connection
```csharp
public void DeleteAsync()
```

**KeepAliveAsync**

Update the connnection's token 
```csharp
public void KeepAliveAsync()
```

Section with full description of stream located in page's bottom

## 2. Exception

In case of an error when requesting the exchange, an exception will be thrown **FutureBinanceAPI.Exceptions.APIException**

```csharp
try {
    ...
    Order newOrder = await order.SetAsync(marketOrder);
} catch (FutureBinanceAPI.Exceptions.APIException e)
{
    Console.WriteLine(e.Details.Msg);
    Console.WriteLine(e.Details.Code);
}
```

## 3. Custom requests

If a library doesn't have any methods, you can simple build your custom requests

**timestamp and recvWindow** will be set automatically

```csharp
public Request(Client client)
public Task<string> SendAsync(IEnumerable<KeyValuePair<string, string>> args, HttpMethod method, string endpoint)
```

```csharp
AuthClient authClient = new AuthClient("API_key", "Secret_key", true); // Create an auth client
DefaultClient defaultClient = new DefaultClient(true); // Create a default client

CustomRequest.Request customRequest = new CustomRequest.Request(authClient);
string response = await customRequest.SendAsync(null, HttpMethod.Get, "/fapi/v1/positionSide/dual");

Console.WriteLine(response); // Output in JSON
```

## 4. Stream

FutureBinance give an ability to listen events from their servers. And with a help this library, you can do it easily

First, create new API Client type - **StreamClient**. It use in conustrctor 2 parameters: **listenKey** and **webSocketUrl**

```csharp
StreamClient(string userListenKey)

StreamClient(string userListenKey, string webSocketUrl)
```

Examples:

```csharp
StreamClient client = StreamClinet("listenKey");
StreamClient specificClient = new StreamClient("listenKey", "newWebSocketUrl");
```

Second, create Stream object. It **allows** you register new event-callbacks
```csharp
StreamClient client = new StreamClient("listenKey");
Stream stream = new Stream(client);

stream.ConnectAsync((error) => {
    // You get created ClientWebSocket object
    Console.WriteLine('whoops..something error');
});

stream.Events.Add(new MarginListener((model) => {
    Console.WriteLine("event from marginListener");
    Console.WriteLine(model.EventType);
}));
```

A collection of Listeners:
```csharp
AccountUpdateListener
MarginListener
OrderTradeUpdateListener
StreamExpired
```

There are a basic listeners. You can create your custom listeners. Your listener need implemented interface **IEvent**

Important note: you have an ability to create custom listener, but they can implemented only basic event models: **StreamExpired, StreamMarginCall, OrderTradeUpdateCall, AccountUpdateCall**

In this example it shows custom listener
```csharp
public class MyListener : IListener
{
    #region Var
    public EventType Type => EventType.MARGIN_CALL;
    
    private Action<EventModel.StreamMarginCall> Callback { get; }
    #endregion

    #region Init
    public MyListener(Action<EventModel.StreamMarginCall> callback)
    {
        Callback = callback;
    }
    #endregion
    
    #region Methods
    public void Update(string message)
    {
        EventModel.StreamMarginCall parsedModel = JsonConvert.DeserializeObject<EventModel.StreamMarginCall>(message);
        
        // Here there is an ability to implemented somethings(check database, send request to api, change parsedModel and etc)
        
        UserCallback(parsedModel);
    }
    #endregion
}
```

```csharp
...
stream.Events.Add(new MyListener((model) => {
    Console.WriteLine(model);
});
```
