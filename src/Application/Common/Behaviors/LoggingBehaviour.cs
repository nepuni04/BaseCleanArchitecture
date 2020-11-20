using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Behaviors
{
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger<TRequest> _logger;

        public LoggingBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            //var userId = _currentUserService.UserId ?? string.Empty;
            //string userName = string.Empty;

            //if (!string.IsNullOrEmpty(userId))
            //{
            //    userName = await _identityService.GetUserNameAsync(userId);
            //}

            //_logger.LogInformation($"CleanArchitecture Request: {requestName} {@userId} {@userName} {@request}");

            _logger.LogInformation($"CleanArchitecture Request: {requestName} {@request}");

            return Task.CompletedTask;
        }
    }
}
