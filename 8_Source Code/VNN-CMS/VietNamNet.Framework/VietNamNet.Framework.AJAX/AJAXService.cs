namespace VietNamNet.Framework.AJAX
{
    public abstract class AJAXService
    {
        private bool noCache = false;
        private string afterFilters;
        private string beforeFilters;
        private int cacheTime = 10;

        public bool NoCache
        {
            get { return noCache; }
            set { noCache = value; }
        }

        public string AfterFilters
        {
            get { return afterFilters; }
            set { afterFilters = value; }
        }

        public string BeforeFilters
        {
            get { return beforeFilters; }
            set { beforeFilters = value; }
        }

        public int CacheTime
        {
            get { return cacheTime; }
            set { cacheTime = value; }
        }

        public abstract void Execute(AJAXPacket packet);
    }
}