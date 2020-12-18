using System;
using System.Diagnostics;
using Sentry;
using Sentry.Infrastructure;

namespace UWP.Sentry.Initializer
{
    public static class Initializer
    {
        public static void Init()
        {
            Debug.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            _ = SentrySdk.Init(o =>
            {
                o.DiagnosticLogger = new DebugDiagnosticLogger(SentryLevel.Debug);
                o.CacheDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                o.InitCacheFlushTimeout = TimeSpan.FromSeconds(1);
                o.DiagnosticsLevel = SentryLevel.Debug;
                o.Debug = true;
                o.Dsn = "https://5a193123a9b841bc8d8e42531e7242a1@o447951.ingest.sentry.io/5560112";
            });
        }

        public static void CaptureMessage(string message)
        {
            SentrySdk.CaptureMessage(message);
        }
    }
}
