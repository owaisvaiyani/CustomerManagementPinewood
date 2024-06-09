using NUnit.Framework;
using Moq;
using Pinewood.CustomerManagement.Core.Context;
using Microsoft.EntityFrameworkCore;
using Pinewood.CustomerManagement.Core.Entities;
using Pinewood.CustomerManagement.Core.Repository;

namespace Pinewood.CustomerManagement.Tests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        private CustomerManagementRepository _repository;       

        [Test]
        public void AddCustomer_Should_Add_Customer_To_Context()
        {
            var newCustomer = new Customer { Id = 1, Name = "John Doe", Email = "john@example.com" };            
            _repository = new CustomerManagementRepository(new TestDbContextFactory());

            var result = _repository.AddCustomer(newCustomer);

            Assert.IsTrue(result);           
        }

        [Test]
        public void AddCustomer_Should_Add_Customer_And_Save()
        {  
            var newCustomer = new Customer { Id = 1, Name = "John Doe", Email = "john@example.com" };
            _repository = new CustomerManagementRepository(new TestDbContextFactory());

            _repository.AddCustomer(newCustomer);

            var result = _repository.GetCustomer(newCustomer.Id);

            Assert.AreEqual(result.Id, newCustomer.Id);
            Assert.AreEqual(result.Name, newCustomer.Name);
            Assert.AreEqual(result.Email, newCustomer.Email);
        }
    }

    public class TestDbContextFactory : IDbContextFactory<CustomerContext>
    {
        private DbContextOptions<CustomerContext> _options;

        public TestDbContextFactory(string databaseName = "InMemoryTest")
        {
            _options = new DbContextOptionsBuilder<CustomerContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
        }

        public CustomerContext CreateDbContext()
        {
            return new CustomerContext(_options);
        }
    }
}