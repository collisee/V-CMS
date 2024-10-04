using VietNamNet.Framework.Module;

namespace VietNamNet.Framework.System.ValueObject
{
    public class Configuration : BaseObject
    {
        #region Members

        protected string detail;
        protected string name;
        protected string val;

        #endregion

        #region Public Properties

        /// <summary>
        /// Property relating to database column Name(nvarchar(255),not null)
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Property relating to database column Val(nvarchar(255),not null)
        /// </summary>
        public string Val
        {
            get { return val; }
            set { val = value; }
        }

        /// <summary>
        /// Property relating to database column Detail(nvarchar(4000),null)
        /// </summary>
        public string Detail
        {
            get { return detail; }
            set { detail = value; }
        }

        #endregion
    }
}