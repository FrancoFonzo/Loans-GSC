using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using LoansAPI.Configuration;
using LoansAPI.DataAccess;
using LoansAPI.Protos;
using LoansAPI.Services;
using System.Text;
using System.Text.Json.Serialization;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var keyVaultUrl = builder.Configuration.GetSection("KeyVaultConfig:Url").Value!;
var clientId = builder.Configuration.GetSection("KeyVaultConfig:ClientId").Value;
var tenantId = builder.Configuration.GetSection("KeyVaultConfig:TenantId").Value;
var clientSecretId = builder.Configuration.GetSection("KeyVaultConfig:ClientSecretId").Value;

var credential = new ClientSecretCredential(tenantId, clientId, clientSecretId);
var client = new SecretClient(new Uri(keyVaultUrl), credential);

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")!;
if (environment.Equals("Release"))
{
    builder.Services.AddDbContext<LoansContext>(options =>
    {
        var connSecret= client.GetSecret("ConnectionStrings--LoansProdConnection").Value.Value;
        options.UseSqlServer(connSecret);
    });
}
else
{
    builder.Services.AddDbContext<LoansContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LoansLocalConn")));
}

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularOrigins",
        blder =>
        {
            blder.WithOrigins("http://localhost:4200", builder.Configuration.GetSection("SPA-BaseURL").Value!)
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtSettings"));

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(o =>
    {
        o.SaveToken = true;
        o.RequireHttpsMetadata = false;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = false,
            ValidIssuer = builder.Configuration.GetSection("JwtSettings:Issuer").Value,
            ValidAudience = builder.Configuration.GetSection("JwtSettings:Audience").Value,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(client.GetSecret("JWT-Secret").Value.Value))
        };
    });

builder.Services.AddScoped<IJwtHandler, JwtHandler>();

builder.Services.AddAuthorization();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors("AllowAngularOrigins");

app.UseAuthentication();
app.UseAuthorization();

app.MapGrpcService<LoansService>();
app.MapGrpcReflectionService();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
