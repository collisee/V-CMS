namespace VietNamNet.AddOn.Union.AJAX
{
    public class MediaFile
    {
        private string _author;
        private string _description;
        private string _file;
        private string _image;
        private string _link;
        private string _title;

        public string link
        {
            get { return _link; }
            set { _link = value; }
        }

        public string image
        {
            get { return _image; }
            set { _image = value; }
        }

        public string author
        {
            get { return _author; }
            set { _author = value; }
        }

        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string file
        {
            get { return _file; }
            set { _file = value; }
        }
    }
}