using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog;
using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Core.Application.Pipelines.Logging
{
    //newtonsoft indirelecek unutma !!!!!..
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly LoggerServiceBase _loggerServiceBase;
        private readonly IHttpContextAccessor _contextAccessor;

        public LoggingBehavior(LoggerServiceBase loggerServiceBase,
            IHttpContextAccessor contextAccessor)
        {
            _loggerServiceBase = loggerServiceBase;
            _contextAccessor = contextAccessor;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            List<LogParameter> logParameters = new();
            logParameters.Add(new LogParameter
            {
                Type = request.GetType().Name,
                Value = request
            });
            LogDetail logDetail = new()
            {
                MethodName = next.Method.Name,
                Parameters = logParameters,
                User = _contextAccessor.HttpContext == null ||
                _contextAccessor.HttpContext.User.Identity.Name == null
                ? "?"
                : _contextAccessor.HttpContext.User.Identity.Name
            };
            _loggerServiceBase.Info(JsonConvert.SerializeObject(logDetail));
            return next();
        }
    }
}
