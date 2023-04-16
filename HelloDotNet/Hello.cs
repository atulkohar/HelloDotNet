using System;
using LaunchDarkly.Sdk;
using LaunchDarkly.Sdk.Server;

namespace HelloDotNet
{
    class Hello
    {
        // Set SdkKey to your LaunchDarkly SDK key.
        public const string SdkKey = "Write you key value";

        // Set FeatureFlagKey to the feature flag key you want to evaluate.
        public const string FeatureFlagKey = "write you flag value";

        private static void ShowMessage(string s) {
            Console.WriteLine("*** " + s);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {

            var ldConfig = Configuration.Default(SdkKey);

            var client = new LdClient(ldConfig);
            
            if (client.Initialized)
            {
                ShowMessage("SDK successfully initialized!");
            }
            else
            {
                ShowMessage("SDK failed to initialize");
                Environment.Exit(1);
            }

            var context = User.Builder("user-key")
                .Name("Name")
                .Build();

            var flagValue = client.BoolVariation(FeatureFlagKey, context, false);

            ShowMessage(string.Format("Feature flag '{0}' is {1}",
                FeatureFlagKey, flagValue));

            client.Dispose();
        }
    }
}
