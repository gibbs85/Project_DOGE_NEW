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
    COUNT_UPDATE_DAYS_PREPLAY = 30,
    TIME_START_OF_DAY = 9
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

    public struct StockBought
    {
        public Stock stock;
        public int count;
        public int moneySpent;
    }
    public StockBought[] stocksOwn;

    void Start()
    {
        this.init();
    }

    void init()
    {
        /*//////////////////////////////////////////////////////////////////////////////////////////////////////
         * 
         * create new Stocks
         *
         * 
         *//////////////////////////////////////////////////////////////////////////////////////////////////////

        stockSamsung = new Stock("�缺����", 68000, (int)SettingsStock.RECORD_LENGTH_MAX);
        stockKakao = new Stock("����", 83000, (int)SettingsStock.RECORD_LENGTH_MAX);
        stockHyundai = new Stock("�����ڵ���", 186500, (int)SettingsStock.RECORD_LENGTH_MAX);
        stockSk = new Stock("�ֽ����ڷ���", 58200, (int)SettingsStock.RECORD_LENGTH_MAX);
        stockLg = new Stock("����ȭ��", 545000, (int)SettingsStock.RECORD_LENGTH_MAX);
        stockApple = new Stock("����", 175254, (int)SettingsStock.RECORD_LENGTH_MAX);
        stockNaver = new Stock("�׹�", 275000, (int)SettingsStock.RECORD_LENGTH_MAX);
        stockGoogle = new Stock("����", 2774420, (int)SettingsStock.RECORD_LENGTH_MAX);
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
         *//////////////////////////////////////////////////////////////////////////////////////////////////////

        for (int i = 0; i < (int)SettingsStock.COUNT_STOCKS; i++)
            //��� �ֽĿ� ����
        {
            for (int j = 0; j < (int)SettingsStock.COUNT_UPDATE_PER_HOUR * (int)SettingsStock.COUNT_HOUR_PER_DAY * (int)SettingsStock.COUNT_UPDATE_DAYS_PREPLAY; j++)
                //1�ð��� ������Ʈ Ƚ�� * �Ϸ�� �� �ð� * preplay �� ��ĥ����
            {
                stocks[i].updateGaussian();
            }
        }



        /*//////////////////////////////////////////////////////////////////////////////////////////////////////
         * 
         * stocksOwn initialization.
         * 
         *//////////////////////////////////////////////////////////////////////////////////////////////////////

        stocksOwn = new StockBought[stocks.Length];
        for (int i = 0; i < stocksOwn.Length; i++)
        {
            stocksOwn[i].stock = stocks[i];
            stocksOwn[i].count = 0;
            stocksOwn[i].moneySpent = 0;
        }



        /*//////////////////////////////////////////////////////////////////////////////////////////////////////
         * 
         * set Stocks Descriptions.
         *
         *//////////////////////////////////////////////////////////////////////////////////////////////////////

        stockSamsung.setDesc("�Ｚ���� ������ ��¼�� ��¼��");
        stockKakao.setDesc("īī�� ������ ��¼�� ��¼��");
        stockHyundai.setDesc("���� ������ ��¼�� ��¼��");
        stockSk.setDesc("�ֽ��� ������ ��¼�� ��¼��");
        stockLg.setDesc("���� ������ ��¼�� ��¼��");
        stockApple.setDesc("���� ������ ��¼�� ��¼��");
        stockNaver.setDesc("���̹� ������ ��¼�� ��¼��");
        stockGoogle.setDesc("���� ������ ��¼�� ��¼��");
        stockMega.setDesc("�ް� ������ ��¼�� ��¼��");


        /*//////////////////////////////////////////////////////////////////////////////////////////////////////
         * 
         * set Stocks attributes.
         *
         *//////////////////////////////////////////////////////////////////////////////////////////////////////

        //stockSamsung
        //stockKakao
        //stockHyundai
        //stockSk
        //stockLg
        //stockApple
        //stockNaver
        //stockGoogle
        //stockMega


    }

    public void BuyStock(Stock stock, int count)
    {
        for (int i = 0; i < stocksOwn.Length; i++)
        {
            if (stocksOwn[i].stock.getName().Equals(stock.getName()))
            {
                stocksOwn[i].count += count;
                stocksOwn[i].moneySpent += (int)(stock.getPrice() * count);
            }
        }
    }

    public void SellStock(Stock stock, int count)
    {
        for (int i = 0; i < stocksOwn.Length; i++)
        {
            if (stocksOwn[i].stock.getName().Equals(stock.getName()))
            {
                stocksOwn[i].moneySpent -= (int)(this.MoneyAvg(stock.getName()) * count);
                stocksOwn[i].count -= count;
            }
        }
    }

    /*
     * �� ���Աݾ�
     */
    public int MoneyBought()
    {
        int result = 0;

        for (int i = 0; i < this.stocksOwn.Length; i++)
        {
            result += this.stocksOwn[i].moneySpent;
        }
        return result;
    }
    /*
     * Ư�� �ֽ� �� ���� �ݾ�
     */
    public int MoneyBought(string stockName)
    {
        int result = 0;

        for (int i = 0; i < this.stocksOwn.Length; i++)
        {
            if (stocksOwn[i].stock.getName().Equals(stockName))
                result = stocksOwn[i].moneySpent;
        }

        return result;
    }



    /* 
     * �� �򰡱ݾ�
     */
    public int MoneySellAll()
    {
        int result = 0;

        for(int i = 0; i < stocksOwn.Length; i++)
        {
            int price = (int)(stocksOwn[i].stock.getPrice()) * stocksOwn[i].count;
            result += price;
        }

        return result;
    }

    /*
     * Ư�� �ֽ� ��ܰ�
     */
    public int MoneyAvg(string stockName)
    {
        int result = 0;
        for (int i = 0; i < this.stocksOwn.Length; i++)
        {
            if (stocksOwn[i].stock.getName().Equals(stockName))
            {
                result = stocksOwn[i].moneySpent / stocksOwn[i].count;
            }
        }
        return result;
    }

    public int CountOwn(string stockName)
    {
        int result = 0;
        for (int i = 0; i < this.stocksOwn.Length; i++)
        {
            if (stocksOwn[i].stock.getName().Equals(stockName))
                result = stocksOwn[i].count;
        }
        return result;
    }


    public void UpdateAllStocks(int timeInterval)
    {
        for (int i = 0; i < (int)SettingsStock.COUNT_STOCKS; i++)
        //��� �ֽĿ� ����
        {
            for (int j = 0; j < (int)SettingsStock.COUNT_UPDATE_PER_HOUR * timeInterval; j++)
            //1�ð��� ������Ʈ Ƚ�� * timeInterval
            {
                stocks[i].updateGaussian();
            }
        }
        //print("UPDATED");
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

    public Stock getStockByName(string name)
    {
        for (int i = 0; i < (int)SettingsStock.COUNT_STOCKS; i++)
            if (name.Equals(this.stocks[i].getName()))
                return stocks[i];

        Stock noResult = new Stock("NOSTOCK", 0);
        return noResult;
    }

    public double[] getRecordDay(Stock stock, int time)
    {
        double[] result;
        int countUpdates = (time - (int)SettingsStock.TIME_START_OF_DAY) * (int)SettingsStock.COUNT_UPDATE_PER_HOUR;
        if (stock.getUpdateCount() < countUpdates)
            countUpdates = stock.getUpdateCount();
        result = new double[countUpdates];
        for (int i = 0; i< countUpdates; i++)
        {
            result[^(i + 1)] = stock.getPriceRecord()[^(i + 1)];
        }
        return result;
    }

    public double getRateDay(Stock stock, int time)
    {
        double priceStart;
        double priceNow;
        double rate;

        double[] record = this.getRecordDay(stock, time);
        priceStart = record[0];
        priceNow = record[^1];
        rate = ((priceNow - priceStart)/priceStart)*100;

        return rate;

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
