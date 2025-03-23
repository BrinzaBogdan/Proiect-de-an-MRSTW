using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProiectDeAnTW.Components;
using ProiectDeAnTW.Components.Account;
using ProiectDeAnTW.Data;
using ProiectDeAnTW.Data.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();



builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? 
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();



builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
builder.Services.AddScoped<LoadDataToPage>();   //am adaugat eu
builder.Services.AddScoped<ProductService>();    //am adaugat eu

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();


app.Run();
/*
 d15bb9a8-a89b-4e7a-bd91-08cd9c9f1065	SedaniRigati	Paste	images/Paste/SedaniRigati.jpg	Aliment	/Paste/SedaniRigati
d7ef07ae-3877-4a30-8415-09248b3617d4	Leustean	Legume	images/Legume/Leustean.jpg	Aliment	/Legume/Leustean
3cc0674c-5153-4f7f-b923-126dce1aee7d	Scialatielli	Paste	images/Paste/Scialatielli.jpg	Aliment	/Paste/Scialatielli
da65ce4e-5a96-4187-bd16-145027eb35e7	Dalmors	Peste	images/Peste/Dalmors.jpg	Aliment	/Peste/Dalmors
3b70df34-cd8f-4d55-ac42-145b530f713b	Rosii	Legume	images/Legume/Rosii.jpg	Aliment	/Legume/Rosii
94c67717-40b4-41f6-969b-1b38d4ca4867	Carp	Peste	images/Peste/Carp.jpg	Aliment	/Peste/Carp
4affa73e-91cd-49d6-bd8f-2bdd42b4f7e7	Fars	Carne	images/Carne/Fars.jpg	Aliment	/carne/CarneFars
a5174334-9cdb-4d3e-8575-318ac2a59e43	Conchiglie	Paste	images/Paste/Conchiglie.jpg	Aliment	/Paste/Conchiglie
fc4c39eb-94a2-4627-9b87-3f4b15bcdf30	BiscuitiOvaz	Dulciuri	images/Dulciuri/BiscuitiOvaz.jpg	Aliment	/Dulciuri/BiscuitiOvaz
1a3b4b72-c5ac-4ed4-b0ba-44bb203bff07	CarneDePorc	Carne	images/Carne/CarneDePorc.jpg	Aliment	/carne/CarneDePorc
8303be01-f587-410f-a671-49452750a599	Biban	Peste	images/Peste/Biban.jpg	Aliment	/Peste/Biban
45c6887e-77e5-4850-991a-574b885f5a23	Caras	Peste	images/Peste/Caras.jpg	Aliment	/Peste/Caras
5ad16710-acb6-434c-a969-7989fbb9e697	Fursecuri	Dulciuri	images/Dulciuri/Fursecuri.jpg	Aliment	/Dulciuri/Fursecuri
38adca03-5405-4773-a9bf-a228c616e0e0	Ridichie	Legume	images/Legume/Ridichie.jpg	Aliment	/Legume/Ridichie
b5602709-0862-47ab-ac45-a528a7dfbfdf	Somon	Peste	images/Peste/Somon.jpg	Aliment	/Peste/Somon
5b7747d2-6cbe-4956-a1a5-ae0f73efbbd4	Capsuni	Fructe	images/Fructe/Capsuni.jpg	Aliment	/Fructe/Capsuni
3e7da5f9-4669-4dba-8e5b-b3f990e133aa	Cirese	Fructe	images/Fructe/Cirese.jpg	Aliment	/Fructe/Cirese
7ad606c6-3b57-4e63-8664-b833098d941d	PepeneRosu	Fructe	images/Fructe/PepeneRosu.jpg	Aliment	/Fructe/PepeneRosu
52bdcf60-7f85-462c-af92-bc360289ff4d	SfeclaRosie	Legume	images/Legume/SfeclaRosie.jpg	Aliment	/Legume/SfeclaRosie
256dc17c-69d4-4f65-8a01-d3403001d3b9	Acadele	Dulciuri	images\Dulciuri\Acadele.jpg	Aliment	/Dulciuri/Acadele
f91d0e64-c5e8-4813-8c8e-d3fc207be452	Marar	Legume	images/Legume/Marar.jpg	Aliment	/Legume/Marar
5fc60c72-8aa7-4e29-82d0-d5ab1d5ac6a5	CarneDeVita	Carne	images/Carne/CarneDeVita.jpg	Aliment	/carne/CarneDeVita
4e1dc2a6-6bab-4fde-a3c2-d985b446e52a	Farfalle	Paste	images/Paste/Farfalle.jpg	Aliment	/paste/Farfalle
6db409f8-2719-4d3a-9252-e8f5daa4b263	PastaPenne	Paste	images/Paste/PastaPenne.jpg	Aliment	/Paste/PastaPenne
7565bba9-f281-405a-89d5-e9da8569488e	AntricotDePorc	Carne	images/Carne/AntricotDePorc.jpg	Aliment	/carne/antricotdeporc
8c89bc45-d11d-42c8-94b3-ee7c6b2c8e72	Pere	Fructe	images/Fructe/Pere.jpg	Aliment	/Fructe/Pere
ca80a46d-6090-4d1b-bdf6-f3fd79eba113	Mere	Fructe	images/Fructe/Mere.jpg	Aliment	/Fructe/Mere
fe91984e-6479-41c5-a608-f47385801e4b	FerreroRocher	Dulciuri	images/Dulciuri/FerreroRocher.jpg	Aliment	/Dulciuri/FerreroRocher
a9584099-75ec-4800-8a50-f4d13ca1d43e	TurteDulce	Dulciuri	images/Dulciuri/TurteDulce.jpg	Aliment	/Dulciuri/TurteDulce
5f2a68cd-a10c-43f6-9770-feab0a759c27	JambonVita	Carne	images/Carne/JambonVita.jpg	Aliment	/carne/CarneJambonDeVita
 
 
 */