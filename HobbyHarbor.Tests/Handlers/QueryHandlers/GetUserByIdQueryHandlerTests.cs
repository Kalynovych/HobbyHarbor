using HobbyHarbor.Application.Handlers.QueryHandlers;
using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Application.Queries;

namespace HobbyHarbor.Tests.Handlers.QueryHandlers
{
	[Collection("Database collection")]
	public sealed class GetUserByIdQueryHandlerTests
	{
		private IHobbyHarborDbContext _context;

		public GetUserByIdQueryHandlerTests(DatabaseFixture databaseFixture)
		{
			_context = databaseFixture.GetDbContext();
		}

		[Theory]
		[InlineData(1)]
		[InlineData(5)]
		public async Task GetUserByIdHandle_ReturnUser_IfIdIsValid(int userId)
		{
			//Arrange
			var handler = new GetUserByIdQueryHandler(_context);

			//Act
			var userFromDb = await handler.Handle(new GetUserById() { Id = userId }, default);

			//Assert
			Assert.NotNull(userFromDb);
			Assert.Equal(userId, userFromDb.Id);
			Assert.NotNull(userFromDb.Profile);
		}

		[Theory]
		[InlineData(-1)]
		[InlineData(10)]
		public async Task GetUserByIdHandle_ReturnNull_IfIdIsInvalid(int userId)
		{
			//Arrange
			var handler = new GetUserByIdQueryHandler(_context);

			//Act
			var userFromDb = await handler.Handle(new GetUserById() { Id = userId }, default);

			//Assert
			Assert.Null(userFromDb);
		}
	}
}
