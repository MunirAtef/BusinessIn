using System.Security.Claims;
using BusinessIn.Application;
using BusinessIn.Application.Secrets;
using BusinessIn.Domain.Constants;
using BusinessIn.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

Secrets.SetSecrets(builder.Configuration);
// var connectionString = builder.Configuration.GetConnectionString("DefaultSQLConnection")!;
Console.WriteLine(Secrets.ConnectionString);


// http://localhost:5171/swagger/index.html
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    // .AddCors()
    .AddDbContext<ApplicationDbContext>()  // options => { options.UseSqlServer(Secrets.ConnectionString); }
    .AddRouting(options => options.LowercaseUrls = true)
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddControllers();

builder.Services.AddAuthorizationBuilder()
    .AddPolicy(Policies.RegularEmployee, policyBuilder => {
        policyBuilder.RequireClaim(Claims.Role, Policies.RegularEmployee);
    })
    .AddPolicy(Policies.Ceo, policyBuilder => {
        policyBuilder.RequireAssertion(context => {
            return context.User.HasClaim(c => 
                c is { Type: Claims.Role, Value: Policies.Ceo or Policies.HrManager });
        });
    })
    .AddPolicy(Policies.HrManager, policyBuilder => {
        policyBuilder.RequireClaim(Claims.Role, Policies.HrManager);
    })
    .AddPolicy(Policies.DepartmentManager, policyBuilder => {
        policyBuilder.RequireClaim(ClaimTypes.Role, Policies.DepartmentManager);
    });


var app = builder.Build();


if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseHttpsRedirection();
app.Run();


// async Task Middleware(HttpContext context, RequestDelegate next) {
//     await context.Response.WriteAsync("Hello from the middleware component.");
//     context.Items["userId"] = "SomeId";
//     Console.WriteLine("Before invoking");
//     await next.Invoke(context: context);
//     Console.WriteLine("After invoking");
// }
// app.Use(Middleware);
//
// app.Use(async (context, next) => await next.Invoke());
//===========================================================================
// class MyMiddleware(RequestDelegate next) {
//     public async Task Invoke(HttpContext context) {
//         await next.Invoke(context);
//     }
// }
// app.UseMiddleware<MyMiddleware>();
//===========================================================================
// app.Map("/employees/", builder => {
//     builder.Use(async (context, next) => {
//         Console.WriteLine("Map branch logic in the Use method before the next delegate");
//         await next.Invoke();
//         Console.WriteLine("Map branch logic in the Use method after the next delegate");
//     });
//     builder.Run(async context => {
//         Console.WriteLine($"Map branch response to the client in the Run method");
//         await context.Response.WriteAsync("Hello from the map branch.");
//     });
// });
//===========================================================================