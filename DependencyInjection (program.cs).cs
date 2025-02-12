services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>();
services.AddSingleton<IJwtProvider, JwtProvider>();
services.AddScoped<IAuthService, AuthService>();
services.AddAuthentication(option =>
{
	option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}
)
.AddJwtBearer(o =>
{
	o.SaveToken = true;
	o.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("OvQWhp2kSk9D1RG8rrHI1qLeiKmBxRaz")),
		ValidIssuer = "SurveyBasketApp",
		ValidAudience = "SurveyBasketUsers",
	};
});
