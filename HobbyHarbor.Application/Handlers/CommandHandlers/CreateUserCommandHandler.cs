using HobbyHarbor.Application.Commands;
using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Handlers.CommandHandlers
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUser, User>
	{
		private readonly IHobbyHarborDbContext _context;

		public CreateUserCommandHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}

		public async Task<User> Handle(CreateUser request, CancellationToken cancellationToken)
		{
			User user = new User
			{
				Username = request.UserName,
				Email = request.Email,
				Profile = new Profile { Name = request.UserName, Images = new List<ProfileImage>() },
			};

			await _context.Users.AddAsync(user, cancellationToken);
			await _context.SaveChangesAsync(cancellationToken);

			return user;
		}
	}
}
