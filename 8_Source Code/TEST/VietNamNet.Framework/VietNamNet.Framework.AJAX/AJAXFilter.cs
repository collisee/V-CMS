namespace VietNamNet.Framework.AJAX
{
    public abstract class AJAXFilter
    {
        public abstract AJAXPacket Process(AJAXPacket packet, ref bool flag);
    }
}