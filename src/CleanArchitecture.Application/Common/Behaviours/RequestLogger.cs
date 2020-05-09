using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Behaviours
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;

        public RequestLogger(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        // TODO: Find another way to extract userId and userName - it should be in the token - figure out how to get it...
        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;

            //_logger.LogInformation("CleanArchitecture Request: {Name} {@UserId} {@UserName} {@Request}",
            //    requestName, userId, userName, request);

            _logger.LogInformation("CleanArchitecture Request: {@Request}", requestName);
        }
    }
}
