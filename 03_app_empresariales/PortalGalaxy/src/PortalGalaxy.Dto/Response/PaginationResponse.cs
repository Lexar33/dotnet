namespace PortalGalaxy.Dto.Response;

public class PaginationResponse<T> : BaseResponse
{
    public ICollection<T>? Data {get; set;}
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
}