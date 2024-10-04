using System.Collections.Generic;

namespace VietNamNet.Websites.Core.Common.ValueObject
{
    public class AdvBlock
    {
        private int _height;
        private int _id;
        private List<AdvItem> _items;
        private int _mode;
        private string _name;
        private int _timeDelay;
        private int _width;

        public AdvBlock()
        {
            id = 0;
            name = string.Empty;
            height = 0;
            width = 0;
            mode = 0;
            timeDelay = 0;
            items = new List<AdvItem>();
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

        public int mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public int timeDelay
        {
            get { return _timeDelay; }
            set { _timeDelay = value; }
        }

        public int width
        {
            get { return _width; }
            set { _width = value; }
        }
        public int height
        {
            get { return _height; }
            set { _height = value; }
        }


        public List<AdvItem> items
        {
            get { return _items; }
            set { _items = value; }
        }
    }
}