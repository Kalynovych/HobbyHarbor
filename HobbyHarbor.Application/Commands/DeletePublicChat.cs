using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Commands
{
    public class DeletePublicChat : IRequest<int>
    {
        public PublicChat PublicChat { get; set; }
    }
}
