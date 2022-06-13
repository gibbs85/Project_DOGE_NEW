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

        stockSamsung = new Stock("사성전자", 68000, (int)SettingsStock.RECORD_LENGTH_MAX);
        stockKakao = new Stock("까까오", 83000, (int)SettingsStock.RECORD_LENGTH_MAX);
        stockHyundai = new Stock("현재자동차", 186500, (int)SettingsStock.RECORD_LENGTH_MAX);
        stockSk = new Stock("애스끼텔레콤", 58200, (int)SettingsStock.RECORD_LENGTH_MAX);
        stockLg = new Stock("헬지화학", 545000, (int)SettingsStock.RECORD_LENGTH_MAX);
        stockApple = new Stock("아플", 175254, (int)SettingsStock.RECORD_LENGTH_MAX);
        stockNaver = new Stock("네버", 275000, (int)SettingsStock.RECORD_LENGTH_MAX);
        stockGoogle = new Stock("구귤", 2774420, (int)SettingsStock.RECORD_LENGTH_MAX);
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

        stockSamsung.setDesc("전국민이 하나씩은 들고있는 든든한 국밥같은 주식. 우리나라 대표기업 주식총액 1위. 최근 나스닥의 부진으로 나름 호황인것같다");
        stockKakao.setDesc("은행이면 은행 게임이면 게임. 플랫폼 사업으로 떠오르는 기업. 까까오가 뭘할지 알면 테마주 흐름을 알 수 있다는 말이 있다");
        stockHyundai.setDesc("부동의 자동차 기업 1위. 새로 나온 전기차 모델이 예쁘게 잘 뽑혔다. 해외에서도 안정성면에서 반응이 좋은편");
        stockSk.setDesc("통신사 시장점유율 1위. 최근에는 KT에 비해 비교적 부진한 모습을 보이고 있다. 무난하게 좋은 종목");
        stockLg.setDesc("최근 같은 계열사인 에너지솔루션이 떨어져나가면서 조금 손실을 봤다. 하지만 우리나라 내에선 사성 다음가는 기업인 만큼 기대치는 높다. 공장 사고로 인해 최근 주가가 조금 떨어졌다");
        stockApple.setDesc("세계 1위 스마트폰 기업. 해외주식 1위 종목이었지만 여러 주식들이 무너지면서 현재 가격이 많이 떨어져있다. 종목은 나쁘지 않지만 해외 주식시장이 전체적으로 침체기인듯하다");
        stockNaver.setDesc("얼마전까진 부동의 플랫폼 1위 기업이었으나 빠른 속도로 사업영역을 넓히는 까까오에게 밀렸다. 제페토와 같은 메타버스 아이템으로 최근 이목을 끌었다");
        stockGoogle.setDesc("세계 최대 검색 플랫폼. 모험보다는 이미지를 생각하는 기업. 종목은 나쁘지 않지만 해외 주식시장이 전체적으로 침체기인듯하다");
        stockMeka.setDesc("메타버스 사업에 뛰어든다하여 주가가 잠깐 올랐다. 하지만 최근 실적이 많이 부진하다. 악재에 겹쳐서 해외 주식시장이 전체적으로 침체기인듯하다");


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
        //모든 주식에 대해
        {
            for (int j = 0; j < (int)SettingsStock.COUNT_UPDATE_PER_HOUR * (int)SettingsStock.COUNT_HOUR_PER_DAY * (int)SettingsStock.COUNT_UPDATE_DAYS_PREPLAY; j++)
            //1시간당 업데이트 횟수 * 하루는 몇 시간 * preplay 는 며칠인지
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
     * 총 매입금액
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
     * 특정 주식 총 매입 금액
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
     * 총 평가금액
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
     * 특정 주식 평단가
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
        //모든 주식에 대해
        {
            for (int j = 0; j < (int)SettingsStock.COUNT_UPDATE_PER_HOUR * timeInterval; j++)
            //1시간당 업데이트 횟수 * timeInterval
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
