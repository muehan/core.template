namespace core.template.logic.Behaviors
{
    using System.Threading.Tasks;
    using infrastructure;
    using MediatR.Pipeline;

    public class PreProcessingBehavior<TRequest, TResponse>: IRequestPreProcessor<TRequest>
    {
        public Task Process(TRequest request)
        {
            // add validators here
            LogTo.Info("Pipline preprocessing happens");

            return Task.FromResult(0);
        }
    }
}
