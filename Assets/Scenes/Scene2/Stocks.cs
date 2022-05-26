using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StockDOGE;

enum SettingsStock
{
    COUNT_STOCKS = 9,

    RECORD_LENGTH_MAX = 100000,
    COUNT_UPDATE_PER_HOUR = 60,
    COUNT_HOUR_PER_DAY = 24,
    COUNT_UPDATE_DAYS_PREPLAY = 30
    //COUNT_TIME_PER_DAY = 3
}

public class Stocks : MonoBehaviour
{
    public Stock stockSamsung,
        stockKakao,
        stockHyundai,
        stockSk,
        stockLg,
        stockApple,
        stockNaver,
        stockGoogle,
        stockMega;

    private Stock[] stocks;

    void Start()
    {
        this.init();
    }

    void init()
    {
        stockSamsung = new Stock("사성전자", 68000, (int)SettingsStock.RECORD_LENGTH_MAX);
        stockKakao = new Stock("까까오", 83000, (int)SettingsStock.RECORD_LENGTH_MAX);
        stockHyundai = new Stock("현재자동차", 186500, (int)SettingsStock.RECORD_LENGTH_MAX);
        stockSk = new Stock("애스끼텔레콤", 58200, (int)SettingsStock.RECORD_LENGTH_MAX);
        stockLg = new Stock("헬지화학", 545000, (int)SettingsStock.RECORD_LENGTH_MAX);
        stockApple = new Stock("아플", 175254, (int)SettingsStock.RECORD_LENGTH_MAX);
        stockNaver = new Stock("네버", 275000, (int)SettingsStock.RECORD_LENGTH_MAX);
        stockGoogle = new Stock("구귤", 2774420, (int)SettingsStock.RECORD_LENGTH_MAX);
        stockMega = new Stock("MEGA", 50000, (int)SettingsStock.RECORD_LENGTH_MAX);

        stocks = new Stock[(int)SettingsStock.COUNT_STOCKS];
        stocks[0] = stockSamsung;
        stocks[1] = stockKakao;
        stocks[2] = stockHyundai;
        stocks[3] = stockSk;
        stocks[4] = stockLg;
        stocks[5] = stockApple;
        stocks[6] = stockNaver;
        stocks[7] = stockGoogle;
        stocks[8] = stockMega;

        /*//////////////////////////////////////////////////////////////////////////////////////////////////////
         * 
         * generate stock price history. before start playing.
         *
         * 
         *//////////////////////////////////////////////////////////////////////////////////////////////////////
        for (int i = 0; i < (int)SettingsStock.COUNT_STOCKS; i++)
            //모든 주식에 대해
        {
            for (int j = 0; j < (int)SettingsStock.COUNT_UPDATE_PER_HOUR * (int)SettingsStock.COUNT_HOUR_PER_DAY * (int)SettingsStock.COUNT_UPDATE_DAYS_PREPLAY; j++)
                //1시간당 업데이트 횟수 * 하루는 몇 시간 * preplay 는 며칠인지
            {
                stocks[i].updateGaussian();
            }
        }
    }

    public int getStocksCount()
    {
        return this.stocks.Length;
    }

    public int getPriceByName(string stockName)
    {
        for (int i=0; i<(int)SettingsStock.COUNT_STOCKS; i++)
        {
            if (stocks[i].getName().Equals(stockName))
                return (int)stocks[i].getPrice();
        }

        return 0;
    }


    public Stock getStockByIndex(int index)
    {
        return this.stocks[index];
    }

    //public  double[] getRecordPriceNdays(Stock stock, int days)
    //{
    //    fixed double result[] = new double[days];

    //    for (int i = 0; i < days; i++)
    //    {
    //        result[i] = stock.getPriceRecord()[stock.getPriceRecord().length - days*(int)SettingsStock.COUNT_UPDATE_PER_TIME*SettingsStock.COUNT_TIME_PER_DAY + i];
    //    }
    //}
}
