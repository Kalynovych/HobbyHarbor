using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Commands
{
    public class CreatePublicMessage : IRequest<PublicMessage>
    {
        public PublicMessage Message { get; set; }
    }
}
