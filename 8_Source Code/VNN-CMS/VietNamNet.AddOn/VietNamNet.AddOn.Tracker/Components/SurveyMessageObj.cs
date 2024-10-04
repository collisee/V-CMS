using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace VietNamNet.AddOn.Tracker.Components
{
    public class SurveyMessageObj
    {
        #region Private Members

        private string _randId;
        private string _surveyId;
        private string _itemId;

        private string _name; // Ho ten
        private string _identityCard; // CMND
        private string  _phone; // So dien thoai
        private string _address; // Dia chi lien lac
        private string  _email ;// Dia chi Email

        #endregion

        #region Public Properties

        public string RandId
        {
            get { return _randId; }
            set { _randId = value; }
        }

        public string SurveyId
        {
            get { return _surveyId; }
            set { _surveyId = value; }
        }

        public string ItemId
        {
            get { return _itemId; }
            set { _itemId = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string IdentityCard
        {
            get { return _identityCard; }
            set { _identityCard = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        #endregion

        #region Contructor

        public SurveyMessageObj(string randId, string surveyId, string itemId, string name, string identityCard, string phone, string address, string email)
        {
            _randId = randId;
            _surveyId = surveyId;
            _itemId = itemId;
            _name = name;
            _identityCard = identityCard;
            _phone = phone;
            _address = address;
            _email = email;
        }

        public SurveyMessageObj()
        {
        }

        #endregion

    }
}
