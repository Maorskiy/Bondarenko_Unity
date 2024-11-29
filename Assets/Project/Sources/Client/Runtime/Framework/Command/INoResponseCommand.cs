namespace Client.Runtime.Framework
{
    public interface INoResponseCommand<in TInput>
    {
        void Execute(TInput data);
    }
}