using HobbyHarbor.Application.Commands;
using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Handlers.CommandHandlers
{
	public class CreateUserChoiceCommandHandler : IRequestHandler<CreateUserChoice, UserChoice>
	{
		private readonly IHobbyHarborDbContext _context;

		public CreateUserChoiceCommandHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}

		public async Task<UserChoice> Handle(CreateUserChoice request, CancellationToken cancellationToken)
		{
			var result = await _context.UserChoices.AddAsync(request.UserChoice);
			await _context.SaveChangesAsync(cancellationToken);

			return result.Entity;
		}
	}
}
