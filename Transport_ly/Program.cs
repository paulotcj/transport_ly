using Microsoft.Extensions.DependencyInjection;
using Transport_ly.Data.Interfaces;
using Transport_ly.Data.Repository;
using Transport_ly.DomainLogic.Interfaces;
using Transport_ly.DomainLogic.Services;


//------------------------------------------------------------------------------------------------


ServiceProvider builder = DependencyInjection();


Console.WriteLine("--------------------------------------------------------");
Console.WriteLine("USER STORY #1");
IFlightScheduleService flightScheduleSrv = builder.GetRequiredService<IFlightScheduleService>();
flightScheduleSrv.PrintToConsole();


Console.WriteLine("\n\n--------------------------------------------------------");
Console.WriteLine("USER STORY #2");
IFlightFreightService flightFreightSrv = builder.GetRequiredService<IFlightFreightService>();
await flightFreightSrv.PrintToConsoleAsync();
Console.WriteLine("\n\n--------------------------------------------------------");



//------------------------------------------------------------------------------------------------





ServiceProvider DependencyInjection()
{
    ServiceProvider builder = new ServiceCollection()
    .AddScoped<IFlightScheduleRepository, FlightScheduleRepository>()
    .AddScoped<IOrderRepository, OrderRepository>()
    .AddScoped<IFlightScheduleService, FlightScheduleService>()
    .AddScoped<IOrderService, OrderService>()
    .AddScoped<IFlightFreightService, FlightFreightService>()
    .BuildServiceProvider();

    return builder;
}




