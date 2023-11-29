using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Commands
{
    public class CreateUserChoice : IRequest<UserChoice>
    {
        public UserChoice UserChoice { get; set; }
    }
}
