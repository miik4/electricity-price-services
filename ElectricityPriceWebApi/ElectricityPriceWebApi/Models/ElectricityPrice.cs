// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ElectricityPriceWebApi.Models
{
    public partial class ElectricityPrice
    {
        public int Id { get; set; }
        public DateTime InEffectFrom { get; set; }
        public DateTime InEffectTo { get; set; }
        public decimal Price { get; set; }
        public string CountryCode { get; set; }
        public int PriceType { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}