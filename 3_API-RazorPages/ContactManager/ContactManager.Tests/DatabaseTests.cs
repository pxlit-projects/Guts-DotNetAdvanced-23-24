﻿using System.Text;
using ContactManager.Domain;
using ContactManager.Infrastructure;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Tests
{
    internal class DatabaseTests:IDisposable
    {
        private SqliteConnection _connection = null!;
        private string? _migrationError;

        [OneTimeSetUp]
        public void CreateDatabase()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            using (ContactManagerDbContext context = CreateDbContext(false))
            {
                //Check if migration succeeds
                try
                {
                    context.Database.Migrate();
                    Contact firstContact = context.Set<Contact>().First();
                }
                catch (Exception e)
                {
                    var messageBuilder = new StringBuilder();
                    messageBuilder.AppendLine("The migration (creation) of the database is not configured properly.");
                    messageBuilder.AppendLine("Set the maximum length of the strings in Company and Contact to 100");
                    messageBuilder.AppendLine(e.Message);
                    _migrationError = messageBuilder.ToString();
                }
            }
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }

        [OneTimeTearDown]
        public void DropDatabase()
        {
            using (var context = CreateDbContext(false))
            {
                context.Database.EnsureDeleted();
            }
            _connection?.Close();
        }

        internal ContactManagerDbContext CreateDbContext(bool assertMigration = true)
        {
            if (assertMigration)
            {
                AssertMigratedSuccessfully();
            }

            var options = new DbContextOptionsBuilder<ContactManagerDbContext>()
                .UseSqlite(_connection)
                .Options;

            return new ContactManagerDbContext(options);
        }

        private void AssertMigratedSuccessfully()
        {
            if (!string.IsNullOrEmpty(_migrationError))
            {
                Assert.Fail(_migrationError);
            }
        }
    }
}

