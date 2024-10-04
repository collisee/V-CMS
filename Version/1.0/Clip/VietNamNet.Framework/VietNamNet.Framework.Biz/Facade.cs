namespace VietNamNet.Framework.Biz
{
    public abstract class Facade
    {
        protected Facade()
        {
        }

        public abstract Packet Execute(Packet packet);
    }
}