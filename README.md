## Future Binance API

This library allows to you use an API of crypto exchange **Future Binance**

In this moment the library supports 40% of API(basic methods) and has a custom request

## 0. Clients

There are 2 clients: **AuthClient** and **DefaultClient**. AuthClient has API-key and Secret-Key for HTTP-request. DefaultClient will use for non-auth request(**Endpoint's Market** and etc...)

In depending of type a constructor has another arguments:
```csharp
AuthClient(string APIKey, string SecretKey, bool debug = false)
...
DefaultClient(bool debug = false)
```

Create a client:
```csharp
AuthClient authClient = new AuthClient("my_api_key", "my_secret_key", true); // Create the client for an auth request
DefaultClient = new DefaultClient(); // Create the client for a non-auth request
```

You can change **RecvWindow** for a client
```csharp
...
authClient.RecvWindow = 5000;
```

## 1. EndPoints

Using a client object you can use anymore endpoint. A list of endpoints:

1) TickerEndPoint
2) TradeEndPoint
3) OrderEndPoint
4) AccountEndPoint

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
public async Task<PriceTicker> GetPriceTickerAsync(Symbols symbol)
```
Example:
```csharp
...
IEnumerable<PriceTicker> priceSymbols = await market.GetPriceTickerAsync();
PriceTicker priceSymbol = await market.GetPriceTickerAsync(Symbols.BTCUSDT);
```

**GetBookTicker**

Fetch best price/qty on the order book for a symbol or symbols.
```csharp
public async Task<IEnumerable<BookTicker>> GetBookTickerAsync()
public async Task<BookTicker> GetBookTickerAsync(Symbols symbol)
```

Example:
```csharp
...
IEnumerable<BookTicker> bestPriceForSymbols = await market.GetBookTickerAsync();
BookTicker bestPrice = await market.GetBookTickerAsync(Symbols.BTCUSDT);
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
public async Task<Leverage> SetLeverageAsync(Symbols symbol, int value)
```

Example:
```csharp
...
Leverage setLeverage = await trade.SetLeverageAsync(Symbols.BTCUSDT, 25); // Set 25 leverage for BTCUSDT
```

**SetMarginType**

Will set a margin type(**CROSSED** or **ISOLATED**) for a given symbol
```csharp
public async Task<bool> SetMarginTypeAsync(Symbols symbol, MarginTypes marginType)
```

Example:
```csharp
...
bool changedMarginType = trade.SetMarginTypeAsync(Symbols.BTCUSDT, MarginTypes.CROSSED); // Set a margin type CROSSED
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
MarketOrder marketOrder = new MarketOrder(Symbols.BTCUSDT, 0.100m); // Create a market order
Order newOrder = await order.SetAsync(marketOrder); // Send our market order to an exchange

Console.WriteLine(newOrder.OrderId); // We received response from exchange and will write in a console
```

#### 1.3.1. Types of orders:
**-MarketOrder**
```csharp
public MarketOrder(Symbols symbol, SideTypes side, decimal quantity)
```

**-LimitOrder**
```csharp
public LimitOrder(Symbols symbol, SideTypes side, decimal quantity, decimal price, TimeInForceEnum.TineInForceTypes timeInForce)
```

**-StopOrder**
```csharp
public StopOrder(Symbols symbol, SideTypes side, decimal quantity, decimal price, decimal stopPrice)
```

**-TakeProfit**
```csharp
public TakeProfit(Symbols symbol, SideTypes side, decimal quantity, decimal price, decimal stopPrice)
```

**-StopMarket**
```csharp
public StopMarket(Symbols symbol, SideTypes side, decimal quantity, decimal stopPrice)
```

**-TakeProfitMarket**
```csharp
public TakeProfitMarket(Symbols symbol, SideTypes side, decimal quantity, decimal stopPrice)
```

**-TrailingStopMarket**
```csharp
public TrailingStopMarket(SymbolsEnum.Symbols symbol, SideTypes side, decimal quantity, decimal callbackRate)
```

**Get**

Fetch info of order from an exchange
```csharp
public async Task<Order> GetAsync(Symbols symbol, long orderId)
```

Example:
```csharp
...
Order order = await order.GetAsync(Symbols.BTCUSDT, 10000045);
```

**Cancel**

Will cancel a given order or all
```csharp
public async Task<Order> CancelAsync(Symbols symbol, long orderId)
public async Task<bool> CancelAsync(Symbols symbol)
```

Example:
```csharp
...
Order canceledOrder = await order.CancelAsync(Symbols.BTCUSDT, 10000045);
bool AreCanceledAllOrders = await order.CancelAsync(Symbols.BTCUSDT);
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
AuthClient defaultClient = new AuthClient(true); // Create a default client

UserRequest.Request customRequest = new UserRequest.Request(authClient);
string response = await customRequest.SendAsync(null, HttpMethod.Get, "/fapi/v1/positionSide/dual");

Console.WriteLine(response); // Output in JSON
```
