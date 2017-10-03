namespace core.template.services.behaviors.Behaviors
{
    using System.Threading.Tasks;
    using infrastructure;
    using MediatR.Pipeline;

    public class PreProcessingBehavior<TRequest>: IRequestPreProcessor<TRequest>
    {
        public Task Process(TRequest request)
        {
            // add validators here
            LogTo.Info("Pipline preprocessing happens");

            return Task.FromResult(0);
        }
    }
}
