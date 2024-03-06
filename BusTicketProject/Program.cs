using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicketProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
//:to = "{
//                      name: 'detaybilet',
//                      params: {
//voyageID: voyage.voyageID,
//                        seatCapacity: voyage.seatCapacity,
//                        ticketPrice: voyage.ticketPrice,
//                        startingPlace: userStartingPlace,
//                        destination: userDestination,
//                        expeditionStop1: voyage.expeditionStop1,
//                        expeditionStop2: voyage.expeditionStop2,
//                        expeditionStop3: voyage.expeditionStop3,
//                      },
//                    }"