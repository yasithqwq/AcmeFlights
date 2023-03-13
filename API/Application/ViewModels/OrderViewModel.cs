using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace API.Application.ViewModels
{
    public class OrderViewModel
    {
        public string Name { get; private set; }
        public Price Price { get; private set; }
        public int NumberOfSeats { get; private set; }
        public bool IsConfirmed { get; private set; }
        public Guid FlightRateId { get; private set; }
        public string OutputMessage { get; set; }
    }
}
