namespace CryptSwitch.ApiServices
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;
        /// <summary>
        /// This will be replace when i decide on which identity server to user
        /// </summary>
        public static class Identity
        {
            public const string Register =  Base + "/identity/register";
        }
    }
}
