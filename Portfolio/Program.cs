using Portfolio.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// ÉTÅ[ÉrÉXìoò^
builder.Services.AddScoped<CertificationService>(); 
builder.Services.AddScoped<InformationService>();
builder.Services.AddScoped<CreditCardService>();
builder.Services.AddScoped<MemberInfoService>();
builder.Services.AddScoped<SearchCouponMasterService>();
builder.Services.AddScoped<SessionStorageAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(p => p.GetRequiredService<SessionStorageAuthenticationStateProvider>());
builder.Services.AddScoped<BrowserHistoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
