
namespace Flash.Api1.DtoModels.Response
{
    public class Response<T>
    {
        public Response() { }
        public Response(T response)
        {
            Data = response;
        }

        public T Data { get; set; }
    }
}
