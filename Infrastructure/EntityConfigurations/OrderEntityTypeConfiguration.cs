using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfigurations
{
    public class OrderEntityTypeConfiguration : BaseEntityTypeConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            builder.Property<Guid>("FlightRateId").IsRequired();

            builder.Property("NumberOfSeats").IsRequired();
            builder.Property("Name").IsRequired();

            builder.HasOne<FlightRate>()
                .WithMany()
                .IsRequired()
                .HasForeignKey("FlightRateId");

            builder.OwnsOne(o => o.Price, a =>
            {
                a.Property<Guid>("OrderId");
                a.WithOwner();
            });
        }
    }
}
