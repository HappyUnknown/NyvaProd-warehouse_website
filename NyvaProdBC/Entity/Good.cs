using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NyvaProdBC.Entity
{
    [System.ComponentModel.DataAnnotations.Schema.Table("NyvaProdGoods")]
    public class Good
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "NAME_DEFAULT";
        public string Description { get; set; } = "NO_DESCRIPTION";
        public double OrderPrice { get; set; } = 0;
        public double APF { get; set; } = 0;
        public double Profit { get; set; } = 0;
        public int TotalAmount { get; set; } = 0;
        public int AmountSold { get; set; } = 0;
        public double WeightKg { get; set; } = 0;
        public string ImageUrl { get; set; } = "IMAGE_DEFAULT";
        public Barcode Barcode { get; set; } = new Barcode();
        public Good() { }
        public Good(string name, string description, double orderPrice, double apf, double profit, int totalAmount, int amountSold, double weightKg, string imageUrl, Barcode barcode = null)
        {
            Name = name;
            Description = description;
            OrderPrice = orderPrice;
            APF = apf;
            Profit = profit;
            TotalAmount = totalAmount;
            AmountSold = amountSold;
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
        public Good(int id, string name, string description, double orderPrice, double apf, double profit, int totalAmount, int amountSold, double weightKg, string imageUrl, Barcode barcode = null)
        {
            Id = id;
            Name = name;
            Description = description;
            OrderPrice = orderPrice;
            APF = apf;
            Profit = profit;
            TotalAmount = totalAmount;
            AmountSold = amountSold;
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
        public Good(string name, string description, double orderPrice, double apf, double profit, int totalAmount, int amountSold, double weightKg, string imageUrl, int regionCode, int producerCode, int goodCode, int controlDigit)
        {
            Name = name;
            Description = description;
            OrderPrice = orderPrice;
            APF = apf;
            Profit = profit;
            TotalAmount = totalAmount;
            AmountSold = amountSold;
            WeightKg = weightKg;
            ImageUrl = imageUrl;
            if (regionCode != 0) Barcode.RegionCode = regionCode;
            if (producerCode != 0) Barcode.ProducerCode = producerCode;
            if (goodCode != 0) Barcode.GoodCode = goodCode;
            if (controlDigit != 0) Barcode.ControlDigit = controlDigit;
        }
        public Good(int id, string name, string description, double orderPrice, double apf, double profit, int totalAmount, int amountSold, double weightKg, string imageUrl, int regionCode, int producerCode, int goodCode, int controlDigit)
        {
            Id = id;
            Name = name;
            Description = description;
            OrderPrice = orderPrice;
            APF = apf;
            Profit = profit;
            TotalAmount = totalAmount;
            AmountSold = amountSold;
            WeightKg = weightKg;
            ImageUrl = imageUrl;
            if (regionCode != 0) Barcode.RegionCode = regionCode;
            if (producerCode != 0) Barcode.ProducerCode = producerCode;
            if (goodCode != 0) Barcode.GoodCode = goodCode;
            if (controlDigit != 0) Barcode.ControlDigit = controlDigit;
        }
    }
}