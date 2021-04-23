namespace WindowsForms_Lab2
{
    class Singleton
    {

        private static Form1 settings;

        public static Form1 GetInstance()
        {
            lock (settings)  // вот это вот надо будет допоказать 
            {
                if (settings == null)
                {
                    settings = new Form1();
                }
                return settings;
            }
        }

        public static Form1 GetCurrentSettings()
        {
            return settings;
        }


        private Singleton()
        {

        }

    }
}
