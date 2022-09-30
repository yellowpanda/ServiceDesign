namespace ApplicationLayer.Shared;

public interface ICommandHandler<in TCommand, TCommandResponse> where TCommand : ICommand<TCommandResponse>
{
    public HandlerResult<TCommandResponse> Execute(TCommand request);
}