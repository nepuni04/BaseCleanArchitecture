﻿using Application.Common.Interfaces;
using Core.Common;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Entities.PurchaseAggregate;
using Core.Entities.SaleAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext, IStoreContext
    {
        private readonly IDateTime _dateTime;
        private readonly IDomainEventService _domainEventService;

        public StoreContext(IDateTime dateTime, 
            DbContextOptions<StoreContext> options,
            IDomainEventService domainEventService) : base(options)
        {
            _dateTime = dateTime;
            _domainEventService = domainEventService;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        //entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;

                    case EntityState.Modified:
                        //entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }

            int result = await base.SaveChangesAsync(cancellationToken);

            await DispatchEvents(cancellationToken);

            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);

            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var decimalProperties = entityType.ClrType.GetProperties()
                        .Where(p => p.PropertyType == typeof(decimal));

                    var dateTimeProperties = entityType.ClrType.GetProperties()
                        .Where(p => p.PropertyType == typeof(DateTimeOffset));

                    foreach (var property in decimalProperties)
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();
                    }

                    foreach (var property in dateTimeProperties)
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name)
                            .HasConversion(new DateTimeOffsetToBinaryConverter());
                    }
                }
            }
        }

        private async Task DispatchEvents(CancellationToken cancellationToken)
        {
            var domainEventEntities = ChangeTracker.Entries<IHasDomainEvent>()
                .Select(x => x.Entity.DomainEvents)
                .SelectMany(x => x)
                .ToArray();

            foreach (var domainEvent in domainEventEntities)
            {
                await _domainEventService.Publish(domainEvent);
            }
        }
    }
}
