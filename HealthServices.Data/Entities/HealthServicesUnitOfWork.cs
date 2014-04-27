﻿using System;
using System.Data.Entity;
using HealthServices.Domain.Interfaces;
using HealthServices.Domain.Models;

namespace HealthServices.Data.Entities
{
    public class HealthServicesUnitOfWork : DbContext, IUnitOfWork
    {
        private HealthServicesRepository<Person> personRepository;

        public DbSet<Person> Person { get; set; }


        public HealthServicesUnitOfWork()
        {
            personRepository = null;
        }

        #region IUnitOfWork Implementation
        public IRepository<Person> OutcomeRepository
        {
            get
            {
                if (personRepository == null)
                {
                    personRepository = new HealthServicesRepository<Person>(this, Person);
                }
                return personRepository;
            }
        }


        public void Commit()
        {
            this.SaveChanges();
        }

        public override int SaveChanges()
        {
            UpdateDates();
            return base.SaveChanges();
        }

        private void UpdateDates()
        {
            throw new NotImplementedException();
        }

 


        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<HealthServicesUnitOfWork>(null);

            base.OnModelCreating(modelBuilder);
        }


        public IRepository<Person> PersonRepository
        {
            get { throw new NotImplementedException(); }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}