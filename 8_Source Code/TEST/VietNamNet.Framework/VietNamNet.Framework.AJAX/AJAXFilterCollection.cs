using System;
using System.Collections;

namespace VietNamNet.Framework.AJAX
{
    [Serializable()]
    public class AJAXFilterCollection : CollectionBase
    {
        private SortedList _this = new SortedList();

        public AJAXFilterObject this[int index]
        {
            get { return (AJAXFilterObject)_this[index]; }
            set { _this[index] = value; }
        }

        public int IndexOfKey(object key)
        {
            return _this.IndexOfKey(key);
        }

        public object GetByIndex(int index)
        {
            return _this.GetByIndex(index);
        }

        public virtual void Add(AJAXFilterObject asObj)
        {
            if (_this.Count == 0)
            {
                _this.Add(asObj.Name, asObj);
            }
            else
            {
                if (!_this.Contains(asObj.Name))
                {
                    _this.Add(asObj.Name, asObj);
                }
                else
                    throw new Exception("AJAX Configuration - Filter: The name attribute is duplicated.");
            }
        }
    }
}