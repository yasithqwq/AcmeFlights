using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SearchResults
{
    public class FlightSearchResult
    {
        public string DepartureAirportCode { get; set; }
        public string ArrivalAirportCode { get; set; }
        public DateTimeOffset DepartureDatetime { get; set; }
        public DateTimeOffset ArrivalDatetime { get; set;}
        public string Destination { get; set; }
        public decimal LowestPrice { get; set; }
    }
}
