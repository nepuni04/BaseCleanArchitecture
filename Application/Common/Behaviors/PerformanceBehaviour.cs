using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Behaviors
{
    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;

        public PerformanceBehaviour(ILogger<TRequest> logger)
        {
            _timer = new Stopwatch();
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            var elapsedMilliseconds = _timer.ElapsedMilliseconds;

            if (elapsedMilliseconds > 500)
            {
                var requestName = typeof(TRequest).Name;
                //var userId = _currentUserService.UserId ?? string.Empty;
                //var userName = string.Empty;

                //if (!string.IsNullOrEmpty(userId))
                //{
                //    userName = await _identityService.GetUserNameAsync(userId);
                //}

                //_logger.LogWarning($"CleanArchitecture Long Running Request: {requestName} ({elapsedMilliseconds} milliseconds) {@userId} {@userName} {@request}");

                _logger.LogWarning($"CleanArchitecture Long Running Request: {requestName}");
            }

            return response;
        }
    }
}
