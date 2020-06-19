## Future Binance API

This library allows to you use an API of crypto exchange **Future Binance**

In this moment the library supports 40% of API(basic methods) and has a custom request

## 0. Clients

There are 2 clients: **AuthClient** and **DefaultClient**. AuthClient has API-key and Secret-Key for HTTP-request. DefaultClient will use for non-auth request(**Endpoint's Market** and etc...)

In depending of type a constructor has another arguments:
```
AuthClient(string APIKey, string SecretKey, bool debug = false)
...
DefaultClient(bool debug = false)
```

Create a client:
```
AuthClient authClient = new AuthClient("my_api_key", "my_secret_key", true); // Create the client for an auth request
DefaultClient = new DefaultClient(); // Create the client for a non-auth request
```

You can change **recvWindow** for a client
```
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
```
DefaultClient client = new DefaultClient(true); // Create a default client
MarketEndPoint market = new MarketEndPoint(client); // Create a market endpoint
```

The endpoint has methods:

**GetPriceTicker**

Fetch latest price for a symbol or symbols.

```
public async Task<IEnumerable<PriceTicker>> GetPriceTicker()
public async Task<PriceTicker> GetPriceTicker(SymbolsEnum.Symbols symbol)
```
Example:
```
...
IEnumerable<PriceTicker> priceSymbols = await market.GetPriceTicker();
PriceTicker priceSymbol = await market.GetPriceTicker(SymbolsEnum.Symbols.BTCUSDT);
```

**GetBookTicker**

Fetch best price/qty on the order book for a symbol or symbols.
```
public async Task<IEnumerable<BookTicker>> GetBookTicker()
public async Task<BookTicker> GetBookTicker(SymbolsEnum.Symbols symbol)
```

Example:
```
...
IEnumerable<BookTicker> bestPriceForSymbols = await market.GetBookTicker();
BookTicker bestPrice = await market.GetBookTicker(SymbolsEnum.Symbols.BTCUSDT);
```

### 1.2. TradeEndPoint

**AuthClient is mandatory for this endpoint**
```
AuthClient client = new AuthClient("API_key", "Secret_key", true); // Create an auth client
TradeEndPoint trade = new TradeEndPoint(client); // Create a trade endpoint
```

The endpoint has methods:

**SetLeverage**

Will set a leverage for a given symbol
```
public async Task<Leverage> SetLeverage(SymbolsEnum.Symbols symbol, int value)
```

Example:
```
...
Leverage setLeverage = await trade.SetLeverage(SymbolsEnum.BTCUSDT, 25); // Set 25 leverage for BTCUSDT
```

**SetMarginType**

Will set a margin type(**CROSSED** or **ISOLATED**) for a given symbol
```
public async Task<bool> SetMarginType(SymbolsEnum.Symbols symbol, MarginEnum.MarginTypes marginType)
```

Example:
```
...
bool changedMarginType = trade.SetMarginType(SymbolsEnum.BTCUSDT, MarginEnum.MarginTypes.CROSSED); // Set a margin type CROSSED
```

### 1.3. OrderEndPoint
**AuthClient is mandatory for this endpoint**

```
AuthClient client = new AuthClient("API_key", "Secret_key", true); // Create an auth client
OrderEndPoint order = new OrderEndPoint(client); // Create an order endpoint
```

**Set**

Will send a new order to exchange. To create an order in code, you need create an object from **FutureBinanceAPI.Models.Orders** namespace. **_Each an order has own class_** (See **1.3.1**)

```
public async Task<Order> Set(Orders.IOrder order)
```

Example:

```
...
MarketOrder marketOrder = new MarketOrder(SymbolsEnum.BTCUSDT, 0.100m); // Create a market order
Order newOrder = await order.Set(marketOrder); // Send our market order to an exchange

Console.WriteLine(newOrder.OrderId); // We received response from exchange and will write in a console
```

#### 1.3.1. Types of orders:
**-MarketOrder**
```
public MarketOrder(SymbolsEnum.Symbols symbol, SideEnum.SideTypes side, decimal quantity)
```

**-LimitOrder**
```
public LimitOrder(SymbolsEnum.Symbols symbol, SideEnum.SideTypes side, decimal quantity, decimal price, TimeInForceEnum.TineInForceTypes timeInForce)
```

**-StopOrder**
```
public StopOrder(SymbolsEnum.Symbols symbol, SideEnum.SideTypes side, decimal quantity, decimal price, decimal stopPrice)
```

**-TakeProfit**
```
public TakeProfit(SymbolsEnum.Symbols symbol, SideEnum.SideTypes side, decimal quantity, decimal price, decimal stopPrice)
```

**-StopMarket**
```
public StopMarket(SymbolsEnum.Symbols symbol, SideEnum.SideTypes side, decimal quantity, decimal stopPrice)
```

**-TakeProfitMarket**
```
public TakeProfitMarket(SymbolsEnum.Symbols symbol, SideEnum.SideTypes side, decimal quantity, decimal stopPrice)
```

**-TrailingStopMarket**
```
public TrailingStopMarket(SymbolsEnum.Symbols symbol, SideEnum.SideTypes side, decimal quantity, decimal callbackRate)
```

**Get**

Fetch info of order from an exchange
```
public async Task<Order> Get(SymbolsEnum.Symbols symbol, long orderId)
```

Example:
```
...
Order order = await order.Get(SymbolsEnum.Symbols.BTCUSDT, 10000045);
```

**Cancel**

Will cancel a given order or all
```
public async Task<Order> Cancel(SymbolsEnum.Symbols symbol, long orderId)
public async Task<bool> Cancel(SymbolsEnum.Symbols symbol)
```

Example:
```
...
Order canceledOrder = await order.Cancel(SymbolsEnum.Symbols.BTCUSDT, 10000045);
bool AreCanceledAllOrders = await order.Cancel(SymbolsEnum.Symbols.BTCUSDT);
``` 

### 1.4. AccountEndPoint

**AuthClient is mandatory for this endpoint**
```
AuthClient client = new AuthClient("API_key", "Secret_key", true); // Create an auth client
AccountEndPoint account = new AccountEndPoint(client); // Create an account endpoint
```

**Get**
```
public async Task<Account> Get()
```

```
...
Account account = await account.Get();
```

## 2. Exception

In case of an error when requesting the exchange, an exception will be thrown **FutureBinanceAPI.Exceptions.APIException**

```
try {
    ...
    Order newOrder = await order.Set(marketOrder);
} catch (FutureBinanceAPI.Exceptions.APIException e)
{
    Console.WriteLine(e.Details.Msg);
    Console.WriteLine(e.Details.Code);
}
```

## 3. Custom requests

If a library doesn't have any methods, you can simple build your custom requests

**timestamp and recvWindow** will be set automatically

```
public Request(Client client)
public Task<string> Send(IEnumerable<KeyValuePair<string, string>> args, HttpMethod method, string endpoint)
```

```
AuthClient authClient = new AuthClient("API_key", "Secret_key", true); // Create an auth client
AuthClient defaultClient = new AuthClient(true); // Create a default client

UserRequest.Request customRequest = new UserRequest.Request(authClient);
string response = await customRequest.Send(null, HttpMethod.Get, "/fapi/v1/positionSide/dual");

Console.WriteLine(response); // Output in JSON
```
