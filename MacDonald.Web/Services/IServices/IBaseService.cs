using MacDonald.Web.Models.ApiModels;
using MacDonald.Web.Models.ResponseDTO;

namespace MacDonald.Web.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
