using HobbyHarbor.Application.Handlers.QueryHandlers;
using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Application.Queries;

namespace HobbyHarbor.Tests.Handlers.QueryHandlers
{
	[Collection("Database collection")]
	public sealed class GetPostsByCreatorIdQueryHandlerTests
	{
		private IHobbyHarborDbContext _context;

		public GetPostsByCreatorIdQueryHandlerTests(DatabaseFixture databaseFixture)
		{
			_context = databaseFixture.GetDbContext();
		}

		[Theory]
		[InlineData(1, 2)]
		[InlineData(2, 1)]
		public async Task GetPostsByCreatorIdHandle_ReturnPosts_IfCreatorIdIsValid(int creatorId, int take)
		{
			//Arrange
			var handler = new GetPostsByCreatorIdQueryHandler(_context);

			//Act
			var postsFromDb = await handler.Handle(new GetPostsByCreatorId() { Id = creatorId, Take = take }, default);

			//Assert
			Assert.NotEmpty(postsFromDb);
			Assert.Equal(take, postsFromDb.Count);
		}

		[Theory]
		[InlineData(1, 1, 1)]
		public async Task GetPostsByCreatorIdHandle_TakeOnePost_AfterSkip(int creatorId, int skip, int postId)
		{
			//Arrange
			var handler = new GetPostsByCreatorIdQueryHandler(_context);

			//Act
			var postsFromDb = await handler.Handle(new GetPostsByCreatorId() { Id = creatorId, Skip = skip }, default);

			//Assert
			Assert.NotEmpty(postsFromDb);
			Assert.Equal(1, postsFromDb.Count);
			Assert.Equal(postId, postsFromDb.FirstOrDefault().Id);
		}

		[Theory]
		[InlineData(10)]
		[InlineData(-10)]
		public async Task GetPostsByCreatorIdHandle_ReturnEmptyCollection_IfCreatorIdIsInvalid(int creatorId)
		{
			//Arrange
			var handler = new GetPostsByCreatorIdQueryHandler(_context);

			//Act
			var postsFromDb = await handler.Handle(new GetPostsByCreatorId() { Id = creatorId }, default);

			//Assert
			Assert.Empty(postsFromDb);
		}

		[Theory]
		[InlineData(1, -1, 1)]
		public async Task GetPostsByCreatorIdHandle_ReturnPost_IfSkipIsInvalid(int creatorId, int skip, int take)
		{
			//Arrange
			var handler = new GetPostsByCreatorIdQueryHandler(_context);

			//Act
			var postsFromDb = await handler.Handle(new GetPostsByCreatorId() { Id = creatorId, Skip = skip, Take = take }, default);

			//Assert
			Assert.NotEmpty(postsFromDb);
			Assert.Equal(take, postsFromDb.Count);
		}

		[Theory]
		[InlineData(1, 3, 1)]
		public async Task GetPostsByCreatorIdHandle_ReturnEmptyCollection_IfSkipIsMoreThanRecords(int creatorId, int skip, int take)
		{
			//Arrange
			var handler = new GetPostsByCreatorIdQueryHandler(_context);

			//Act
			var postsFromDb = await handler.Handle(new GetPostsByCreatorId() { Id = creatorId, Skip = skip, Take = take }, default);

			//Assert
			Assert.Empty(postsFromDb);
		}

		[Theory]
		[InlineData(1, 0)]
		[InlineData(1, -1)]
		public async Task GetPostsByCreatorIdHandle_ReturnEmptyCollection_IfTakeIsInvalid(int creatorId, int take)
		{
			//Arrange
			var handler = new GetPostsByCreatorIdQueryHandler(_context);

			//Act
			var postsFromDb = await handler.Handle(new GetPostsByCreatorId() { Id = creatorId, Take = take }, default);

			//Assert
			Assert.Empty(postsFromDb);
		}
	}
}
