using System;

namespace VietNamNet.Websites.Core.Common.ValueObject
{
    public class AdvItem
    {
        private string _codeJS;
        private DateTime _endTime;
        private int _exHeight;
        private int _exMode;
        private int _exWidth;
        private string _fileJS;
        private string _fileLink1;
        private string _fileLink2;
        private int _id;
        private string _link;
        private string _name;
        private DateTime _startTime;
        private string _typeAlias;
        private int _typeId;

        public AdvItem()
        {
            id = 0;
            name = string.Empty;
            link = string.Empty;
            codeJS = string.Empty;
            fileJS = string.Empty;
            fileLink1 = string.Empty;
            fileLink2 = string.Empty;
            endTime = DateTime.Now;
            startTime = DateTime.Now;
            exMode = 0;
            exHeight = 0;
            exWidth = 0;
            typeId = 0;
            typeAlias = string.Empty;
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

        public string link
        {
            get { return _link; }
            set { _link = value; }
        }

        public DateTime startTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        public DateTime endTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        public int typeId
        {
            get { return _typeId; }
            set { _typeId = value; }
        }

        public string typeAlias
        {
            get { return _typeAlias; }
            set { _typeAlias = value; }
        }

        public string fileLink1
        {
            get { return _fileLink1; }
            set { _fileLink1 = value; }
        }

        public string fileLink2
        {
            get { return _fileLink2; }
            set { _fileLink2 = value; }
        }

        public string fileJS
        {
            get { return _fileJS; }
            set { _fileJS = value; }
        }

        public string codeJS
        {
            get { return _codeJS; }
            set { _codeJS = value; }
        }

        public int exMode
        {
            get { return _exMode; }
            set { _exMode = value; }
        }

        public int exWidth
        {
            get { return _exWidth; }
            set { _exWidth = value; }
        }

        public int exHeight
        {
            get { return _exHeight; }
            set { _exHeight = value; }
        }
    }
}