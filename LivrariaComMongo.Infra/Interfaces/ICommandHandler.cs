namespace LivrariaComMongo.Infra.Interfaces
{
    public interface ICommandHandler<T> where T : ICommandPadrao
    {
        ICommandResult Handle(T command);
    }
}
