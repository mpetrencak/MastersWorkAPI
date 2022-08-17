using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.OpenApi.Models;
using MinimalApi;
using MinimalApi.Core;
using MinimalApi.Infrastructure.Db;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

DiConfigDbStorage.ConfigureServices(builder.Services, configuration);
DiConfigCore.ConfigureServices(builder.Services, configuration);

builder.Services.AddCors(opt => opt.AddDefaultPolicy(bldr => bldr.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
    .AddIdentityServerAuthentication(
        options =>
        {
            options.Authority = configuration["IdentityServerUrl"];
            options.ApiName = "dpapi";
        });

builder.Services.AddAuthorizationCore(authorizationOptions =>
{
    authorizationOptions.AddPolicy(Policies.CanHaveAdmin, Policies.CanHaveAdminPolicy());
    authorizationOptions.AddPolicy(Policies.CanHaveModerator, Policies.CanHaveModeratorPolicy());
});

var requireAuthenticatedUserPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
builder.Services.AddControllers(configure => configure.Filters.Add(new AuthorizeFilter(requireAuthenticatedUserPolicy)));

builder.Services.AddSwaggerGen(swaggerGenOptions =>
{
    swaggerGenOptions.CustomSchemaIds(x => x.FullName);
    swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DP backend",
        Version = "v1"
    });

    swaggerGenOptions.AddSecurityDefinition("JWT Token", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.ApiKey,
        Name = "Authorization",
        Description = "Copy 'Bearer '",
        In = ParameterLocation.Header
    });
    swaggerGenOptions.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "JWT Token"
                }
            },
            Array.Empty<string>()
        }
    });

});
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
