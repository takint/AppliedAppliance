using MediatR;

namespace Application.Common.Commands
{
    public class BaseCommand<T> : IRequest<int> where T : class
    {
        public T DataDto { get; set; }
    }
}
