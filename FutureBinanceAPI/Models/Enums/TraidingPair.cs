﻿using Newtonsoft.Json;
using FutureBinanceAPI.Tools.Converters;

namespace FutureBinanceAPI.Models.Enums
{
    [JsonConverter(typeof(TradingPairConverter))]
    public enum TradingPair
    {
        Unknown,
        BANDUSDT,
        KAVAUSDT,
        BTCUSDT,
        ETHUSDT,
        BCHUSDT,
        XRPUSDT,
        EOSUSDT,
        LTCUSDT,
        TRXUSDT,
        ETCUSDT,
        LINKUSDT,
        XLMUSDT,
        ADAUSDT,
        XMRUSDT,
        DASHUSDT,
        ZECUSDT,
        XTZUSDT,
        BNBUSDT,
        ATOMUSDT,
        ONTUSDT,
        IOTAUSDT,
        BATUSDT,
        VETUSDT,
        NEOUSDT,
        QTUMUSDT,
        IOSTUSDT,
        THETAUSDT,
        ALGOUSDT,
        ZILUSDT,
        KNCUSDT,
        ZRXUSDT,
        COMPUSDT,
        OMGUSDT,
        DOGEUSDT,
        SXPUSDT,
        LENDUSDT,
        SNTUSDT,
        BNTUSDT,
        BCCUSDT,
        GASUSDT,
        HSRUSDT,
        OAXUSDT,
        DNTUSDT,
        MCOUSDT,
        ICNUSDT,
        WTCUSDT,
        LRCUSDT,
        BQXUSDT,
        FUNUSDT,
        SNMUSDT,
        XVGUSDT,
        MDAUSDT,
        MTLUSDT,
        SUBUSDT,
        MTHUSDT,
        ENGUSDT,
        ASTUSDT,
        BTGUSDT,
        EVXUSDT,
        REQUSDT,
        VIBUSDT,
        ARKUSDT,
        MODUSDT,
        ENJUSDT,
        VENUSDT,
        KMDUSDT,
        RCNUSDT,
        RDNUSDT,
        DLTUSDT,
        AMBUSDT,
        ARNUSDT,
        GVTUSDT,
        CDTUSDT,
        GXSUSDT,
        POEUSDT,
        QSPUSDT,
        BTSUSDT,
        XZCUSDT,
        LSKUSDT,
        TNTUSDT,
        BCDUSDT,
        DGDUSDT,
        ADXUSDT,
        PPTUSDT,
        CMTUSDT,
        CNDUSDT,
        TNBUSDT,
        GTOUSDT,
        ICXUSDT,
        OSTUSDT,
        ELFUSDT,
        BRDUSDT,
        EDOUSDT,
        NAVUSDT,
        LUNUSDT,
        RLCUSDT,
        INSUSDT,
        VIAUSDT,
        BLZUSDT,
        RPXUSDT,
        POAUSDT,
        XEMUSDT,
        WANUSDT,
        WPRUSDT,
        QLCUSDT,
        SYSUSDT,
        GRSUSDT,
        GNTUSDT,
        BCNUSDT,
        REPUSDT,
        ZENUSDT,
        SKYUSDT,
        CVCUSDT,
        QKCUSDT,
        AGIUSDT,
        NXSUSDT,
        KEYUSDT,
        NASUSDT,
        MFTUSDT,
        HOTUSDT,
        PHXUSDT,
        PAXUSDT,
        RVNUSDT,
        DCRUSDT,
        RENUSDT,
        BTTUSDT,
        ONGUSDT,
        FETUSDT,
        PHBUSDT,
        ONEUSDT,
        FTMUSDT,
        ERDUSDT,
        WINUSDT,
        COSUSDT,
        CHZUSDT,
        HCUUSDT,
        NKNUSDT,
        STXUSDT,
        FTTUSDT,
        OGNUSDT,
        TCTUSDT,
        WRXUSDT,
        LTOUSDT,
        MBLUSDT,
        SOLUSDT,
        CHRUSDT,
        MDTUSDT,
        IQBUSDT,
        PNTUSDT,
        DGBUSDT,
        SCUUSDT,
        SNXUSDT,
        MKRUSDT,
        DAIUSDT
    }
}
