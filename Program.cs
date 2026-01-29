

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using ZiekefondsReizen.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ZiekenfondsApiContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDBConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



//Roles
builder.Services.AddIdentity<CustomUser,IdentityRole>(o => 
{ 
    o.SignIn.RequireConfirmedAccount = false; 
    o.SignIn.RequireConfirmedPhoneNumber = false; 
    o.SignIn.RequireConfirmedEmail = false; 
    o.User.RequireUniqueEmail = true;
    o.Password.RequiredLength = 6;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ZiekenfondsApiContext>()
    .AddDefaultTokenProviders();
//policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequiredHoofdMonitorRole", policy =>
        policy.RequireRole("HoofdMonitor"));
    options.AddPolicy("RequiredMonitorRole", policy =>
        policy.RequireRole("Monitor"));
    options.AddPolicy("RequiredVerantwoordelijkeRole", policy =>
        policy.RequireRole("Verantwoordelijke"));
    options.AddPolicy("RequiredBeheerderRole", policy =>
        policy.RequireRole("Beheerder"));
    options.AddPolicy("RequiredGebruikerRole", policy =>
        policy.RequireRole("Gebruiker"));
});


var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//SEEDING
//roles
using(var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Beheerder", "Verantwoordelijke", "HoofdMonitor", "Monitor", "Gebruiker" };
    foreach (var role in roles)
    {
        if(!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

}
//Users
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<CustomUser>>();
    //beheerder
    string email = "beheerder@beheerder.com";
    string password = "Test1234*";
    if(await userManager.FindByEmailAsync(email)== null)
    {
        var user = new CustomUser();
        user.UserName = email;
        user.Achternaam = "More";
        user.Voornaam = "Thomas";
        user.Straat = "Kleinhoefstaart";
        user.Huisnummer = "4";
        user.Gemeente = "Geel";
        user.Postcode = "2240";
        user.Geboortedatum = DateOnly.FromDateTime(DateTime.Now);
        user.Huisdoktor = "Jeff";
        user.ContractNummer = "4";
        user.Email = email;
        user.TelefoonNummer = "014 56 23 10";
        user.RekeningNummer = "4";
        user.IsActief = true;
        user.IsHoofdMonitor = false;
        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Beheerder");
        await userManager.AddToRoleAsync(user, "Verantwoordelijke");
        await userManager.AddToRoleAsync(user, "HoofdMonitor");
        await userManager.AddToRoleAsync(user, "Monitor");
        await userManager.AddToRoleAsync(user, "Gebruiker");
    }
    //vernatwoordelijke
    email = "verantwoordelijke@verantwoordelijke.com";
    password = "Verantwoordelijke1234*";
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new CustomUser();
        user.UserName = email;
        user.Achternaam = "More";
        user.Voornaam = "Thomas";
        user.Straat = "Kleinhoefstaart";
        user.Huisnummer = "4";
        user.Gemeente = "Geel";
        user.Postcode = "2240";
        user.Geboortedatum = DateOnly.FromDateTime(DateTime.Now);
		user.Huisdoktor = "Jeff";
        user.ContractNummer = "4";
        user.Email = email;
        user.TelefoonNummer = "014 56 23 10";
        user.RekeningNummer = "4";
        user.IsActief = true;
        user.IsHoofdMonitor = false;
       
        await userManager.CreateAsync(user, password);
   
        await userManager.AddToRoleAsync(user, "Verantwoordelijke");
        await userManager.AddToRoleAsync(user, "Gebruiker");
    }
    //HoofdMonitor
    email = "hoofdmonitor@hoofdmonitor.com";
    password = "Hoofdmonitor1234*";
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new CustomUser();
        user.UserName = email;
        user.Achternaam = "More";
        user.Voornaam = "Thomas";
        user.Straat = "Kleinhoefstaart";
        user.Huisnummer = "4";
        user.Gemeente = "Geel";
        user.Postcode = "2240";
        user.Geboortedatum = DateOnly.FromDateTime(DateTime.Now);
		user.Huisdoktor = "Jeff";
        user.ContractNummer = "4";
        user.Email = email;
        user.TelefoonNummer = "014 56 23 10";
        user.RekeningNummer = "4";
        user.IsActief = true;
        user.IsHoofdMonitor = false;
        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "HoofdMonitor");
        await userManager.AddToRoleAsync(user, "Monitor");
        await userManager.AddToRoleAsync(user, "Gebruiker");
    }
    //Monitor
    email = "monitor@monitor.com";
    password = "Monitor1234*";
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new CustomUser();
        user.UserName = email;
        user.Achternaam = "More";
        user.Voornaam = "Thomas";
        user.Straat = "Kleinhoefstaart";
        user.Huisnummer = "4";
        user.Gemeente = "Geel";
        user.Postcode = "2240";
        user.Geboortedatum = DateOnly.FromDateTime(DateTime.Now);
		user.Huisdoktor = "Jeff";
        user.ContractNummer = "4";
        user.Email = email;
        user.TelefoonNummer = "014 56 23 10";
        user.RekeningNummer = "4";
        user.IsActief = true;
        user.IsHoofdMonitor = false;
        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Monitor");
        await userManager.AddToRoleAsync(user, "Gebruiker");
    }
    //Gebruiker
    email = "gebruiker@gebruiker.com";
    password = "Gebruiker1234*";
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new CustomUser();
        user.UserName = email;
        user.Achternaam = "More";
        user.Voornaam = "Thomas";
        user.Straat = "Kleinhoefstaart";
        user.Huisnummer = "4";
        user.Gemeente = "Geel";
        user.Postcode = "2240";
        user.Geboortedatum = DateOnly.FromDateTime(DateTime.Now);
		user.Huisdoktor = "Jeff";
        user.ContractNummer = "4";
        user.Email = email;
        user.TelefoonNummer = "014 56 23 10";
        user.RekeningNummer = "4";
        user.IsActief = true;
        user.IsHoofdMonitor = false;
        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Gebruiker");
    }
    
}

app.Run();