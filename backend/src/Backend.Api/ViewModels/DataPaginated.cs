namespace Backend.Api.ViewModels
{
    public class DataPaginated
    {
        public DataPaginated(int count, object data)
        {
            Count = count;
            Data = data;
        }

        public int Count { get; private set; }
        public object Data { get; private set; }
    }
}