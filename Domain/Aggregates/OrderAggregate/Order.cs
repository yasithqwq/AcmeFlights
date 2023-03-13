using Domain.Aggregates.FlightAggregate;
using Domain.Common;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public Price Price { get; private set; }
        public int NumberOfSeats { get; private set; }
        public bool IsConfirmed { get;private set; }
        public Guid FlightRateId { get; private set; }

        [NotMapped]
        public string OutputMessage { get; set; }

        public Order()
        {
        }

        public void ConfirmChange()
        {
            IsConfirmed = true;
        }

        public Order(string name,Price price,int numberOfSeats, Guid flightRateId, bool isConfirmed)
        {
            Name = name;
            Price = price;
            NumberOfSeats = numberOfSeats;
            FlightRateId = flightRateId;
            IsConfirmed = isConfirmed;
        }
    }
}
