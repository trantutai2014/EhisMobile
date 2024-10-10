using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Service
{
  public class TokenService
  {
    private readonly string _secretKey;
    private readonly int _accessTokenExpiration;
    private readonly Dictionary<string, string> _refreshTokens = new(); // Đơn giản lưu trữ refresh token trong bộ nhớ

    public TokenService(IConfiguration configuration)
    {
      _secretKey = configuration["Jwt:SecretKey"];
      _accessTokenExpiration = Convert.ToInt32(configuration["Jwt:AccessTokenExpire"]);
    }

    public async Task<TokenResponse> GenerateTokens(string userId)
    {
      // Tạo Access Token
      var accessToken = GenerateAccessToken(userId);

      // Tạo Refresh Token và lưu vào bộ nhớ
      var refreshToken = GenerateRefreshToken();
      _refreshTokens[refreshToken] = userId; // Lưu refresh token với userId

      return new TokenResponse
      {
        AccessToken = accessToken,
        RefreshToken = refreshToken
      };
    }

    public async Task<string> RefreshToken(string refreshToken)
    {
      // Kiểm tra refresh token có tồn tại không
      if (!_refreshTokens.ContainsKey(refreshToken))
      {
        return null; // Refresh token không hợp lệ
      }

      // Lấy lại userId từ refresh token và tạo access token mới
      var userId = _refreshTokens[refreshToken];
      var newAccessToken = GenerateAccessToken(userId);

      return newAccessToken;
    }

    private string GenerateAccessToken(string userId)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_secretKey);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, userId) }),
        Expires = DateTime.UtcNow.AddMinutes(_accessTokenExpiration),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }

    private string GenerateRefreshToken()
    {
      return Guid.NewGuid().ToString(); // Tạo một refresh token đơn giản
    }
  }

  public class TokenResponse
  {
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
  }
}
