namespace my_dotnet_store.Models;

public class AdminDashboardModel
{
    public double ToplamSatis { get; set; }
    public int SiparisSayisi { get; set; }
    public int UrunSayisi { get; set; }
    public int UyeSayisi { get; set; }
    public List<Order> SonSiparisler { get; set; } = new();
}