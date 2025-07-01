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

//Redirige automáticamente todas las solicitudes HTTP a HTTPS.
app.UseHttpsRedirection();
// Permite el uso de archivos estáticos, como CSS, JavaScript e imágenes en la carpeta "wwwroot" del proyecto.
app.UseStaticFiles();
app.UseAntiforgery();
// Permite el uso de componentes de Razor en la aplicación.
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
// Finalmente, arranca la aplicación web. Desde aquí, la app comienza a escuchar peticiones HTTP y
// a responderlas según la configuración y los componentes definidos anteriormente.
app.Run();
