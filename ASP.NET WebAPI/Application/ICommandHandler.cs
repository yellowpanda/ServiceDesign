namespace ApplicationLayer;

public interface ICommandHandler<in TCommand, out TCommandResponse> where TCommand : ICommand<TCommandResponse>
{
    public TCommandResponse Execute(TCommand request);
}