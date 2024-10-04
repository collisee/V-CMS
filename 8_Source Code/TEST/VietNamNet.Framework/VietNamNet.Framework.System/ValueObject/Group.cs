using System.Data;
using VietNamNet.Framework.Module;

namespace VietNamNet.Framework.System.ValueObject
{
    public class Group : BaseObject
    {
        #region Members

        protected string detail;
        protected DataTable members;
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
        /// Property relating to database column Detail(nvarchar(4000),null)
        /// </summary>
        public string Detail
        {
            get { return detail; }
            set { detail = value; }
        }

        public DataTable Members
        {
            get { return members; }
            set { members = value; }
        }

        #endregion
    }
}