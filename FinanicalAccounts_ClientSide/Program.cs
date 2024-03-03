using FinanicalAccounts_ClientSide;
using FinanicalAccountsClient.IRepository;
using FinanicalAccountsClient.Service;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7202/") });
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserLogInRepository, UserLoginRespository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddScoped<IBankRepository, BankRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
await builder.Build().RunAsync();
