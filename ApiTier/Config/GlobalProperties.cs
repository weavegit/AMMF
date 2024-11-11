namespace AmmfApi.Config
{
    public static class GlobalProperties
    {

        private static string dBConnection = "";


        public static void Initialise(IConfiguration Configuration)
        {
            try
            {
                dBConnection = Configuration["ConnectionStrings:DefaultConnection"];

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public static string DBConnection { get => dBConnection; }

    }
}
