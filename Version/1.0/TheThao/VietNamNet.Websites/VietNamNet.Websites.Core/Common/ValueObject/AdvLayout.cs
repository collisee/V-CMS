using System.Collections.Generic;

namespace VietNamNet.Websites.Core.Common.ValueObject
{
    public class AdvLayout
    {
        private int _id;
        private string _name;
        private List<AdvZone> _zones;

        public AdvLayout()
        {
            id = 0;
            name = string.Empty;
            zones = new List<AdvZone>();
        }

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<AdvZone> zones
        {
            get { return _zones; }
            set { _zones = value; }
        }
    }
}