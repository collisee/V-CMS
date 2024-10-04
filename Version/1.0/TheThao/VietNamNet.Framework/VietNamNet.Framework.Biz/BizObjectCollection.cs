using System;
using System.Collections;
using VietNamNet.Framework.Common;

namespace VietNamNet.Framework.Biz
{
    public class BizObjectCollection : CollectionBase
    {
        private SortedList _this = new SortedList();

        public BizObject this[int index]
        {
            get { return (BizObject)_this[index]; }
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

        public virtual void Add(BizObject obj)
        {
            if (Nulls.IsNullOrEmpty(obj.Name))
                throw new Exception(string.Format("The name attribute is null or empty."));
            if (Nulls.IsNullOrEmpty(obj.Actions))
                obj.Actions = "Default";
            foreach (string action in obj.Actions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                string key = string.Format("{0}:{1}", obj.Name, action);
                if (_this.Count == 0)
                {
                    _this.Add(key, obj);
                }
                else
                {
                    if (!_this.Contains(key))
                    {
                        _this.Add(key, obj);
                    }
                    else
                        throw new Exception(string.Format("The name {0} is duplicated.", key));
                }
            }
        }
    }
}