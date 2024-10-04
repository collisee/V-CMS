using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace VietNamNet.Websites.Core.Common.ValueObject
{
    [Serializable()]
    [XmlRoot("photos")]
    public class Photos
    {
        #region Private Properties

        protected List<Photo> photoColection;

        #endregion

        #region Public Properties

        [XmlElement("photo")]
        public List<Photo> PhotoColection
        {
            get { return photoColection; }
            set { photoColection = value; }
        }

        #endregion

        #region Constructor

        public Photos()
        {
            this.PhotoColection = new List<Photo>();
        }

        public Photos(List<Photo> collection)
        {
            this.PhotoColection = collection;
        }

        #endregion
    }
}