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
    TIME_START_OF_DAY = 9,
    TIME_END_OF_DAY = 15
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
        stockMeka;

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
        stockMeka = new Stock("MEKA", 50000, (int)SettingsStock.RECORD_LENGTH_MAX);

        stocks = new Stock[(int)SettingsStock.COUNT_STOCKS];
        stocks[0] = stockSamsung;
        stocks[1] = stockKakao;
        stocks[2] = stockHyundai;
        stocks[3] = stockSk;
        stocks[4] = stockLg;
        stocks[5] = stockApple;
        stocks[6] = stockNaver;
        stocks[7] = stockGoogle;
        stocks[8] = stockMeka;

        


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

        stockSamsung.setDesc("�������� �ϳ����� ����ִ� ����� ���䰰�� �ֽ�. �츮���� ��ǥ��� �ֽ��Ѿ� 1��. �ֱ� �������� �������� ���� ȣȲ�ΰͰ���");
        stockKakao.setDesc("�����̸� ���� �����̸� ����. �÷��� ������� �������� ���. ������ ������ �˸� �׸��� �帧�� �� �� �ִٴ� ���� �ִ�");
        stockHyundai.setDesc("�ε��� �ڵ��� ��� 1��. ���� ���� ������ ���� ���ڰ� �� ������. �ؿܿ����� �������鿡�� ������ ������");
        stockSk.setDesc("��Ż� ���������� 1��. �ֱٿ��� KT�� ���� ���� ������ ����� ���̰� �ִ�. �����ϰ� ���� ����");
        stockLg.setDesc("�ֱ� ���� �迭���� �������ַ���� �����������鼭 ���� �ս��� �ô�. ������ �츮���� ������ �缺 �������� ����� ��ŭ ���ġ�� ����. ���� ���� ���� �ֱ� �ְ��� ���� ��������");
        stockApple.setDesc("���� 1�� ����Ʈ�� ���. �ؿ��ֽ� 1�� �����̾����� ���� �ֽĵ��� �������鼭 ���� ������ ���� �������ִ�. ������ ������ ������ �ؿ� �ֽĽ����� ��ü������ ħü���ε��ϴ�");
        stockNaver.setDesc("�������� �ε��� �÷��� 1�� ����̾����� ���� �ӵ��� ��������� ������ �������� �зȴ�. ������� ���� ��Ÿ���� ���������� �ֱ� �̸��� ������");
        stockGoogle.setDesc("���� �ִ� �˻� �÷���. ���躸�ٴ� �̹����� �����ϴ� ���. ������ ������ ������ �ؿ� �ֽĽ����� ��ü������ ħü���ε��ϴ�");
        stockMeka.setDesc("��Ÿ���� ����� �پ����Ͽ� �ְ��� ��� �ö���. ������ �ֱ� ������ ���� �����ϴ�. ���翡 ���ļ� �ؿ� �ֽĽ����� ��ü������ ħü���ε��ϴ�");


        /*//////////////////////////////////////////////////////////////////////////////////////////////////////
         * 
         * set Stocks attributes.
         *
         *//////////////////////////////////////////////////////////////////////////////////////////////////////

        stockSamsung.setMean(1.00001); stockSamsung.setStd(0.0015);
        stockKakao.setMean(1.000005); stockKakao.setStd(0.003);
        stockHyundai.setMean(1.00001); stockHyundai.setStd(0.0012);
        stockSk.setMean(1.00001); stockSk.setStd(0.001);
        stockLg.setMean(1.000003); stockLg.setStd(0.0025);
        stockApple.setMean(1.00002); stockApple.setStd(0.0017);
        stockNaver.setMean(1.00001); stockNaver.setStd(0.0029);
        stockGoogle.setMean(1.00001); stockGoogle.setStd(0.0010);
        stockMeka.setMean(1.00001); stockMeka.setStd(0.0022);
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
