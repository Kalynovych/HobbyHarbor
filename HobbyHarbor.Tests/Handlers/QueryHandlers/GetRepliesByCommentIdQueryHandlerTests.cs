using HobbyHarbor.Application.Handlers.QueryHandlers;
using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Application.Queries;

namespace HobbyHarbor.Tests.Handlers.QueryHandlers
{
	[Collection("Database collection")]
	public sealed class GetRepliesByCommentIdQueryHandlerTests
	{
		private IHobbyHarborDbContext _context;

		public GetRepliesByCommentIdQueryHandlerTests(DatabaseFixture databaseFixture)
		{
			_context = databaseFixture.GetDbContext();
		}

		[Theory]
		[InlineData(1, 5)]
		[InlineData(8, 1)]
		public async Task GetRepliesByCommentIdHandle_ReturnRepliesHierarchy_IfReplyIdIsValid(int replyId, int commentsAmount)
		{
			//Arrange
			var handler = new GetRepliesByCommentIdQueryHandler(_context);

			//Act
			var repliesFromDb = await handler.Handle(new GetRepliesByCommentId() { Id = replyId }, default);

			//Assert
			Assert.NotEmpty(repliesFromDb);
			Assert.Equal(commentsAmount, repliesFromDb.Count);
			foreach (var reply in repliesFromDb)
				Assert.NotNull(reply.ReplyCommentId);
		}

		[Theory]
		[InlineData(-1)]
		[InlineData(10)]
		[InlineData(2)]
		public async Task GetRepliesByCommentIdHandle_ReturnEmptyCollection_IfReplyIdIsInvalid(int replyId)
		{
			//Arrange
			var handler = new GetRepliesByCommentIdQueryHandler(_context);

			//Act
			var repliesFromDb = await handler.Handle(new GetRepliesByCommentId() { Id = replyId }, default);

			//Assert
			Assert.Empty(repliesFromDb);
		}
	}
}
