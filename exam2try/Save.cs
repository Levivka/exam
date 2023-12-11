using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace exam2try
{
    internal class Currency
    {
        [JsonPropertyName("currencyname")]
        public string CurrencyName { get; set; }

        [JsonPropertyName("currencyreduction")]
        public string CurrencyReduction { get; set; }

        [JsonPropertyName("currencyval")]
        public double СurrencyVal { get; set; }
    }
    internal class Save
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("currencydata")]
        public Currency[] Data { get; set; }
    }
}
