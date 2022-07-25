using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NyvaProdBC.Entity
{
    public class Good
    {
        private const int NUMBER_DEFAULT = 0;
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "NAME_DEFAULT";
        public double OrderPrice { get; set; } = 0;
        public double SellPrice { get; set; } = 0;
        public double WeightKg { get; set; } = 0;
        public string ImageUrl { get; set; } = "IMAGE_DEFAULT";
        public DateTime ProductionDate { get; set; } = DateTime.MinValue;
        public DateTime ConsumedUntil { get; set; } = DateTime.MaxValue;
        public Barcode Barcode { get; set; } = new Barcode();
        public Good() { }
        public Good(string name, double orderPrice, double sellPrice, double weightKg, string imageUrl, Barcode barcode = null)
        {
            Name = name;
            OrderPrice = orderPrice;
            SellPrice = sellPrice;
            WeightKg = weightKg;
            ImageUrl = imageUrl;
            if (barcode != null)
            {
                Barcode.ControlDigit = barcode.ControlDigit;
                Barcode.GoodCode = barcode.GoodCode;
                Barcode.ProducerCode = barcode.ProducerCode;
                Barcode.RegionCode = barcode.RegionCode;
            }
        }
        public Good(int id, string name, double orderPrice, double sellPrice, double weightKg, string imageUrl, Barcode barcode = null)
        {
            Id = id;
            Name = name;
            OrderPrice = orderPrice;
            SellPrice = sellPrice;
            WeightKg = weightKg;
            ImageUrl = imageUrl;
            if (barcode != null)
            {
                Barcode.ControlDigit = barcode.ControlDigit;
                Barcode.GoodCode = barcode.GoodCode;
                Barcode.ProducerCode = barcode.ProducerCode;
                Barcode.RegionCode = barcode.RegionCode;
            }
        }
        public Good(string name, double orderPrice, double sellPrice, double weightKg, string imageUrl, int regionCode, int producerCode, int goodCode, int controlDigit)
        {
            Name = name;
            OrderPrice = orderPrice;
            SellPrice = sellPrice;
            WeightKg = weightKg;
            ImageUrl = imageUrl;
            if (regionCode != NUMBER_DEFAULT) Barcode.RegionCode = regionCode;
            if (producerCode != NUMBER_DEFAULT) Barcode.ProducerCode = producerCode;
            if (goodCode != NUMBER_DEFAULT) Barcode.GoodCode = goodCode;
            if (controlDigit != NUMBER_DEFAULT) Barcode.ControlDigit = controlDigit;
        }
        public Good(int id, string name, double orderPrice, double sellPrice, double weightKg, string imageUrl, int regionCode, int producerCode, int goodCode, int controlDigit)
        {
            Id = id;
            Name = name;
            OrderPrice = orderPrice;
            SellPrice = sellPrice;
            WeightKg = weightKg;
            ImageUrl = imageUrl;
            if (regionCode != NUMBER_DEFAULT) Barcode.RegionCode = regionCode;
            if (producerCode != NUMBER_DEFAULT) Barcode.ProducerCode = producerCode;
            if (goodCode != NUMBER_DEFAULT) Barcode.GoodCode = goodCode;
            if (controlDigit != NUMBER_DEFAULT) Barcode.ControlDigit = controlDigit;
        }
    }
}