using AutoFixture;
using HobbyHarbor.Core.Entities;
using HobbyHarbor.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HobbyHarbor.Tests
{
	public class DatabaseFixture : IDisposable
	{
		private readonly HobbyHarborDbContext _context;

		public DatabaseFixture()
		{
			var option = new DbContextOptionsBuilder<HobbyHarborDbContext>().UseInMemoryDatabase("InMemoryDB").Options;
			_context = new HobbyHarborDbContext(option);

			_context.Database.EnsureCreated();
		}

		public HobbyHarborDbContext GetDbContext()
		{
			return _context;
		}
		
		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
