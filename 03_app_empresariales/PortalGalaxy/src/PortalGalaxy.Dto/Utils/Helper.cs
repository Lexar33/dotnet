namespace PortalGalaxy.Dto.Utils;

public static class Helper
{
    public static int GetTotalPages( int totalRows, int pageSize)
    => (int) Math.Ceiling(totalRows / (double) pageSize);
}