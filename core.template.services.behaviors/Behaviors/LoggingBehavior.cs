namespace core.template.services.behaviors.Behaviors
{
    using System.Threading.Tasks;
    using infrastructure;
    using MediatR;

    public class LoggingBehavior<TRequest, TResponse>: IPipelineBehavior<TRequest, TResponse>
    { 
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next)
        {
            LogTo.Info("Start pipeline");
            var response = await next();
            LogTo.Info("End Pipeline");

            return response;
        }
    }
}
