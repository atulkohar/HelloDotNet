using System;
using LaunchDarkly.Sdk;
using LaunchDarkly.Sdk.Server;

namespace HelloDotNet
{
    class Hello
    {
        // Set SdkKey to your LaunchDarkly SDK key.
        public const string SdkKey = "sdk-cd55c3c7-907e-463b-bcb9-06c2b48c7e55";

        // Set FeatureFlagKey to the feature flag key you want to evaluate.
        public const string FeatureFlagKey = "assess_viewschedulingdetails_orderlisting";

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
                .Name("atul")
                .Build();

            var flagValue = client.BoolVariation(FeatureFlagKey, context, false);

            ShowMessage(string.Format("Feature flag '{0}' is {1} for this context",
                FeatureFlagKey, flagValue));

            client.Dispose();
        }
    }
}
