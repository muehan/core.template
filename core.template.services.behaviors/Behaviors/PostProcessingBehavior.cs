namespace core.template.services.behaviors.Behaviors
{
    using System.Threading.Tasks;
    using infrastructure;
    using MediatR.Pipeline;

    public class PostProcessingBehavior<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        public Task Process(TRequest request, TResponse response)
        {
            LogTo.Info("Post processing: All Done");
            return Task.FromResult(0);
        }
    }
}
