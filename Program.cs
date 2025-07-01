using EmprendeLocal.Components;
// se utiliza la biblioteca de componentes de Razor para crear aplicaciones web interactivas y reactivas.
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//Redirige autom�ticamente todas las solicitudes HTTP a HTTPS.
app.UseHttpsRedirection();
// Permite el uso de archivos est�ticos, como CSS, JavaScript e im�genes en la carpeta "wwwroot" del proyecto.
app.UseStaticFiles();
app.UseAntiforgery();
// Permite el uso de componentes de Razor en la aplicaci�n.
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
// Finalmente, arranca la aplicaci�n web. Desde aqu�, la app comienza a escuchar peticiones HTTP y
// a responderlas seg�n la configuraci�n y los componentes definidos anteriormente.
app.Run();
