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
            return RegionCode + "'" + ProducerCode + "'" + GoodCode + "'" + ControlDigit;
        }
    }
}