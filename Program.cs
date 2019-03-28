using System;

namespace TelemetrySample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Remember to configure your own InstrumentationKey before starting in Telemetry.cs");

            Telemetry.TrackPageView("ProgramStarted");

            Console.WriteLine("Testing a div by zero exception");
            try
            {
                int div = 0;
                int i = 1 / div;
            }
            catch (Exception ex)
            {
                Telemetry.TrackException(ex);
            }

            // Flush telemetry before program exit. It takes a couple of minutes for temetry to show in Azure
            // Don't do it after every call to Telemetry, your metrics will be sent in batches for performance.
            Telemetry.Flush();
            Console.WriteLine("Telemetry sent");

            // Close program
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}