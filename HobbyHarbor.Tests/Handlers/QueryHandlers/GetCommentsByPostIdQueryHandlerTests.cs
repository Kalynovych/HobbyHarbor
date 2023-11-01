using HobbyHarbor.Application.Handlers.QueryHandlers;
using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Application.Queries;

namespace HobbyHarbor.Tests.Handlers.QueryHandlers
{
	[Collection("Database collection")]
	public sealed class GetCommentsByPostIdQueryHandlerTests
	{
		private IHobbyHarborDbContext _context;

		public GetCommentsByPostIdQueryHandlerTests(DatabaseFixture databaseFixture)
		{
			_context = databaseFixture.GetDbContext();
		}

		[Theory]
		[InlineData(1, 2)]
		[InlineData(2, 1)]
		public async Task GetCommentsByPostIdHandle_ReturnPostsComments_IfPostIdIsValid(int postId, int take)
		{
			//Arrange
			var handler = new GetCommentsByPostIdQueryHandler(_context);

			//Act
			var commentsFromDb = await handler.Handle(new GetCommentsByPostId() { Id = postId, Take = take }, default);

			//Assert
			Assert.NotEmpty(commentsFromDb);
			Assert.Equal(take, commentsFromDb.Count);
		}

		[Theory]
		[InlineData(1, 1, 2)]
		public async Task GetCommentsByPostIdHandle_TakeOneComment_AfterSkip(int postId, int skip, int commentId)
		{
			//Arrange
			var handler = new GetCommentsByPostIdQueryHandler(_context);

			//Act
			var commentsFromDb = await handler.Handle(new GetCommentsByPostId() { Id = postId, Skip = skip }, default);

			//Assert
			Assert.NotEmpty(commentsFromDb);
			Assert.Equal(1, commentsFromDb.Count);
			Assert.Equal(commentId, commentsFromDb.FirstOrDefault().Id);
		}

		[Theory]
		[InlineData(10)]
		[InlineData(-10)]
		public async Task GetCommentsByPostIdHandle_ReturnEmptyCollection_IfPostIdIsInvalid(int postId)
		{
			//Arrange
			var handler = new GetCommentsByPostIdQueryHandler(_context);

			//Act
			var commentsFromDb = await handler.Handle(new GetCommentsByPostId() { Id = postId }, default);

			//Assert
			Assert.Empty(commentsFromDb);
		}

		[Theory]
		[InlineData(1, -1, 1)]
		public async Task GetCommentsByPostIdHandle_ReturnComments_IfSkipIsInvalid(int postId, int skip, int take)
		{
			//Arrange
			var handler = new GetCommentsByPostIdQueryHandler(_context);

			//Act
			var commentsFromDb = await handler.Handle(new GetCommentsByPostId() { Id = postId, Skip = skip, Take = take }, default);

			//Assert
			Assert.NotEmpty(commentsFromDb);
			Assert.Equal(take, commentsFromDb.Count);
		}

		[Theory]
		[InlineData(1, 3, 1)]
		public async Task GetCommentsByPostIdHandle_ReturnEmptyCollection_IfSkipIsMoreThanRecords(int postId, int skip, int take)
		{
			//Arrange
			var handler = new GetCommentsByPostIdQueryHandler(_context);

			//Act
			var commentsFromDb = await handler.Handle(new GetCommentsByPostId() { Id = postId, Skip = skip, Take = take }, default);

			//Assert
			Assert.Empty(commentsFromDb);
		}

		[Theory]
		[InlineData(1, 0)]
		[InlineData(1, -1)]
		public async Task GetCommentsByPostIdHandle_ReturnEmptyCollection_IfTakeIsInvalid(int postId, int take)
		{
			//Arrange
			var handler = new GetCommentsByPostIdQueryHandler(_context);

			//Act
			var commentsFromDb = await handler.Handle(new GetCommentsByPostId() { Id = postId, Take = take }, default);

			//Assert
			Assert.Empty(commentsFromDb);
		}
	}
}
