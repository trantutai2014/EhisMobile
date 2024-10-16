namespace Common.Constants
{
    public class SystemConsts
    {
        public const string CorsPolicy = "MDPCorsPolicy";
        public const string JwtTokens = "JwtTokens";
        public const string SigningKey = "12112019syt@ehis.vn";
        public const string Swagger = "Swagger";
        public const string OpenApiSecurity = "OpenApiSecurity";
        public const string MigrationsAssembly = "Data";
        public const string UploadConfiguration = "UploadConfiguration";
        public const string CacheDurationInHours = "CacheDurationInHours";

        public const string TenSoYTe = "Sở Y Tế Tỉnh Điện Biên";
       
        public const string Role_Administrator = "Administrator";
        public const string Role_Admin = "Admin";
        public const string Role_SYT = "SYT";
        public static readonly string[] Role_ViewAll = new string[] { Role_Administrator, Role_Admin, Role_SYT };

        public static readonly int[] loai_kcb_ngoai_tru = new int[] { 1, 2 };
        public const int loai_kcb_noi_tru = 3;
    }
}