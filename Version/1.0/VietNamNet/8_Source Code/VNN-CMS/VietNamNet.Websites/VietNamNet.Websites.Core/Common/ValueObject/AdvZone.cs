using System.Collections.Generic;

namespace VietNamNet.Websites.Core.Common.ValueObject
{
    public class AdvZone
    {
        private List<AdvBlock> _blocks;
        private int _direction;
        private int _height;
        private string _holderId;
        private int _id;
        private int _mode;
        private string _name;
        private int _width;

        public AdvZone()
        {
            id = 0;
            name = string.Empty;
            holderId = string.Empty;
            height = 0;
            width = 0;
            mode = 0;
            direction = 0;
            blocks = new List<AdvBlock>();
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

        public string holderId
        {
            get { return _holderId; }
            set { _holderId = value; }
        }

        public int mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public int direction
        {
            get { return _direction; }
            set { _direction = value; }
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

        public List<AdvBlock> blocks
        {
            get { return _blocks; }
            set { _blocks = value; }
        }
    }
}