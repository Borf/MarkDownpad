namespace MarkDownPad;

public class Settings
{
    public string AdminUser { get; set; } = string.Empty;
    public string AdminPassword { get; set; } = string.Empty;

    public string UrlSalt { get; set; } = string.Empty;
    public string PasswordSalt { get; set; } = string.Empty;
}
