namespace QuickShop.Client.Authentication;

public class AuthenticationModel
{
    public string? Token { get; set; }
    public string? RefreshToken { get; set; }
    public string? Username { get; set; }
    public List<string>? Roles { get; set; }
}
