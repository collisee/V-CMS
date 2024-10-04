namespace VietNamNet.Websites.Core.Common.ValueObject
{
    public class NewsR : NewsL
    {
        #region Member

        private string _content;

        #endregion

        #region Public Properties

        public string content
        {
            get { return _content; }
            set { _content = value; }
        }

        #endregion
    }
}