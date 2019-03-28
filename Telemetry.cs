using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.Text;

namespace TelemetrySample
{
    public static class Telemetry
    {
        // Consider using DI. This is just a quick sample
        private static TelemetryClient tc;

        static Telemetry()
        {
            tc = new TelemetryClient
            {
                // TODO: replace with your own InstrumentationKey
                InstrumentationKey = "f304267a-0d47-4378-8333-secretkey"
            };

            // Set global properties if needed like unique installation number or customer id
            //tc.Context.GlobalProperties.Add("InstallationId", "unique_id_for_your_installation");

            // Set new SessionId
            tc.Context.Session.Id = Guid.NewGuid().ToString();

            // Set version if needed
            //tc.Context.Component.Version = Application.ProductVersion;

            // Set other data if needed. Double check that you have permission to collect PII data like UserName
            //tc.Context.User.Id = Environment.UserName;
            //tc.Context.Device.OperatingSystem = Environment.OSVersion.ToString();
        }

        public static void Flush() => tc.Flush();
        public static void TrackException(Exception ex) => tc.TrackException(ex);
        public static void TrackPageView(string name) => tc.TrackPageView(name);
        public static void TrackEvent(string eventName, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null) => tc.TrackEvent(eventName, properties, metrics);
    }
}
