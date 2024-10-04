using VietNamNet.Framework.Module;

namespace VietNamNet.Framework.System.ValueObject
{
    public class Module : BaseObject
    {
        #region Members

        protected string alias;
        protected string detail;
        protected string name;

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
        /// Property relating to database column Alias(nvarchar(255),not null)
        /// </summary>
        public string Alias
        {
            get { return alias; }
            set { alias = value; }
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