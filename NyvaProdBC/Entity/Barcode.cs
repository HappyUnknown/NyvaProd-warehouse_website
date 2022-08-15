using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NyvaProdBC.Entity
{
    public class Barcode
    {
        public int RegionCode { get; set; } = 0;
        public int ProducerCode { get; set; } = 0;
        public int GoodCode { get; set; } = 0;
        public int ControlDigit { get; set; } = 0;
        public Barcode() { }
        public Barcode(int regionCode, int producerCode, int goodCode, int controlDigit)
        {
            RegionCode = regionCode;
            ProducerCode = producerCode;
            GoodCode = goodCode;
            ControlDigit = controlDigit;
        }
        public override string ToString()
        {
            int regCodeDigits = 3;
            int regCodeDigitCount = regCodeDigits - 1;//hardcode, because I do not understand
            int regCode = RegionCode;
            string strRegCode = regCode.ToString();
            while (regCode > 1)
            {
                regCode /= 10;
                regCodeDigitCount--;
            }
            for (int i = 0; i < regCodeDigitCount; i++)
                strRegCode = "0" + strRegCode;

            int prodCodeDigits = 4;
            int prodCodeDigitCount = prodCodeDigits - 1;//hardcode, because I do not understand
            int prodCode = ProducerCode;
            string strProdCode = prodCode.ToString();
            while (prodCode > 1)
            {
                prodCode /= 10;
                prodCodeDigitCount--;
            }
            for (int i = 0; i < prodCodeDigitCount; i++)
                strProdCode = "0" + strProdCode;

            int goodCodeDigits = 5;
            int goodCodeDigitCount = goodCodeDigits - 1;//hardcode, because I do not understand
            int goodCode = GoodCode;
            string strGoodCode = goodCode.ToString();
            while (goodCode > 1)
            {
                goodCode /= 10;
                goodCodeDigitCount--;
            }
            for (int i = 0; i < goodCodeDigitCount; i++)
                strGoodCode = "0" + strGoodCode;

            return strRegCode + "'" + strProdCode + "'" + strGoodCode + "'" + ControlDigit;
        }
    }
}