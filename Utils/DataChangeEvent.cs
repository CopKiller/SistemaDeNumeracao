
namespace SistemaDeNumeracao.Utils
{
    public class DataChangeEvent<T> : EventArgs
    {
        public T NovoDado { get; }

        public DataChangeEvent(T newData)
        {
            NovoDado = newData;
        }
    }
}
