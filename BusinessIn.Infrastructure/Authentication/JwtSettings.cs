namespace BusinessIn.Infrastructure.Authentication;

public class JwtSettings {
    public const string SectionName = "JwtSettings";
    
    public string Issuer { init; get; } = null!;
    public string Audience { init; get; } = null!;
    public string AccessTokenKey { init; get; } = null!;
    public string RefreshTokenKey { init; get; } = null!;
    public int AccessTokenExpireIn { init; get; }
    public int RefreshTokenExpireIn { init; get; }
}

/*
  "JwtSettings": {
    "Issuer": "MunirMAtef.Iss",
    "Audience": "MunirMAtef.Adu",
    "AccessTokenKey": "D845CB434BCB2A993C7CB76DF4CCB849E6CBC2AF44933BA7AEF9BC6495EA345F60AD50AE6CBC40",
    "RefreshTokenKey": "F4B734BC4355EA8CD845F677AD50A6D9E6CBC40CB493A9E6CBC2A0CCB3C43BEF9BC649F42A94BA",
    "AccessTokenExpiryMinutes": 60,
    "RefreshTokenExpiryMinutes": 3000
  }
 */