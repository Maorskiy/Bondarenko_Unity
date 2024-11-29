using System.Threading.Tasks;

namespace Client.Runtime.Framework
{
    public interface INoResponseAsyncCommand<in TInput>
    {
        Task Execute(TInput data);
    }
}