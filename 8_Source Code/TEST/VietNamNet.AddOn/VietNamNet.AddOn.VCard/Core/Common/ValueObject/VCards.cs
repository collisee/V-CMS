
using System;
using System.IO;
using System.Text;
using VietNamNet.Framework.Common;

namespace VietNamNet.AddOn.VCard.Core.Common.ValueObject
{
	public class VCards  
	{
		#region Members
		protected int contactId;
		protected string fullname;
		protected string orgTitle;
		protected string orgName;
		protected string orgUnit;
		protected string orgPhone;
		protected string orgMobile;
		protected string orgFax;
		protected string orgAdr1;
		protected string orgAdr2;
		protected string orgEmail1;
		protected string orgEmail2;
		protected string orgWebsite;
		protected byte sex;
		protected DateTime bday;
		protected string homePhone;
		protected string homeMobile;
		protected string homeFax;
		protected string homeAdr1;
		protected string homeAdr2;
		protected string homeEmail1;
		protected string homeEmail2;
		protected string homepage;
		protected string notes;
		protected int owner;
		protected int groupID;
		protected byte scope;
		protected DateTime created_At;
		protected int created_By;
		protected DateTime last_Modified_At;
		protected int last_Modified_By;
		protected string flag;
        protected string groupName;

        // Add new properties in 03/08/2010 by SonDN
        protected string pager;   
        protected string nickname;
        protected string nationality;
        protected string homeCountry;
        protected string orgCountry;
        protected string orgDescription;
        protected string orgOffice;
		#endregion

		#region Public Properties
        public string OrgOffice
        {
            get { return orgOffice; }
            set { orgOffice = value; }
        }
        public string OrgDescription
        {
            get { return orgDescription; }
            set { orgDescription = value; }
        }
        public string OrgCountry
        {
            get { return orgCountry; }
            set { orgCountry = value; }
        }
        public string HomeCountry
        {
            get { return homeCountry; }
            set { homeCountry = value; }
        }
        public string Nationality
        {
            get { return nationality; }
            set { nationality = value; }
        }
        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }
        public string Pager
        {
            get { return pager; }
            set { pager = value; }
        }


               
		/// <summary>
		/// Property relating to database column ContactId(int,not null)
		/// </summary>
		public int ContactId
		{
			get { return contactId; }
			set { contactId = value; }
		}

		/// <summary>
		/// Property relating to database column Fullname(nvarchar(100),null)
		/// </summary>
		public string Fullname
		{
			get { return fullname; }
			set { fullname = value; }
		}


		/// <summary>
		/// Property relating to database column OrgTitle(nvarchar(25),null)
		/// </summary>
		public string OrgTitle
		{
			get { return orgTitle; }
			set { orgTitle = value; }
		}

		/// <summary>
		/// Property relating to database column OrgName(nvarchar(100),null)
		/// </summary>
		public string OrgName
		{
			get { return orgName; }
			set { orgName = value; }
		}

		/// <summary>
		/// Property relating to database column OrgUnit(nvarchar(100),null)
		/// </summary>
		public string OrgUnit
		{
			get { return orgUnit; }
			set { orgUnit = value; }
		}

		/// <summary>
		/// Property relating to database column OrgPhone(nvarchar(20),null)
		/// </summary>
		public string OrgPhone
		{
			get { return orgPhone; }
			set { orgPhone = value; }
		}

		/// <summary>
		/// Property relating to database column OrgMobile(nvarchar(20),null)
		/// </summary>
		public string OrgMobile
		{
			get { return orgMobile; }
			set { orgMobile = value; }
		}

		/// <summary>
		/// Property relating to database column OrgFax(nvarchar(20),null)
		/// </summary>
		public string OrgFax
		{
			get { return orgFax; }
			set { orgFax = value; }
		}

		/// <summary>
		/// Property relating to database column OrgAdr1(nvarchar(500),null)
		/// </summary>
		public string OrgAdr1
		{
			get { return orgAdr1; }
			set { orgAdr1 = value; }
		}

		/// <summary>
		/// Property relating to database column OrgAdr2(nvarchar(500),null)
		/// </summary>
		public string OrgAdr2
		{
			get { return orgAdr2; }
			set { orgAdr2 = value; }
		}

		/// <summary>
		/// Property relating to database column OrgEmail1(varchar(50),null)
		/// </summary>
		public string OrgEmail1
		{
			get { return orgEmail1; }
			set { orgEmail1 = value; }
		}

		/// <summary>
		/// Property relating to database column OrgEmail2(varchar(50),null)
		/// </summary>
		public string OrgEmail2
		{
			get { return orgEmail2; }
			set { orgEmail2 = value; }
		}

		/// <summary>
		/// Property relating to database column OrgWebsite(varchar(50),null)
		/// </summary>
		public string OrgWebsite
		{
			get { return orgWebsite; }
			set { orgWebsite = value; }
		}

		/// <summary>
		/// Property relating to database column Sex(tinyint,null)
		/// </summary>
		public byte Sex
		{
			get { return sex; }
			set { sex = value; }
		}

		/// <summary>
		/// Property relating to database column Bday(datetime,null)
		/// </summary>
		public DateTime Bday
		{
			get { return bday; }
			set { bday = value; }
		}

		/// <summary>
		/// Property relating to database column HomePhone(nvarchar(20),null)
		/// </summary>
		public string HomePhone
		{
			get { return homePhone; }
			set { homePhone = value; }
		}

		/// <summary>
		/// Property relating to database column HomeMobile(nvarchar(20),null)
		/// </summary>
		public string HomeMobile
		{
			get { return homeMobile; }
			set { homeMobile = value; }
		}

		/// <summary>
		/// Property relating to database column HomeFax(nvarchar(20),null)
		/// </summary>
		public string HomeFax
		{
			get { return homeFax; }
			set { homeFax = value; }
		}

		/// <summary>
		/// Property relating to database column HomeAdr1(nvarchar(500),null)
		/// </summary>
		public string HomeAdr1
		{
			get { return homeAdr1; }
			set { homeAdr1 = value; }
		}

		/// <summary>
		/// Property relating to database column HomeAdr2(nvarchar(500),null)
		/// </summary>
		public string HomeAdr2
		{
			get { return homeAdr2; }
			set { homeAdr2 = value; }
		}

		/// <summary>
		/// Property relating to database column HomeEmail1(varchar(50),null)
		/// </summary>
		public string HomeEmail1
		{
			get { return homeEmail1; }
			set { homeEmail1 = value; }
		}

		/// <summary>
		/// Property relating to database column HomeEmail2(varchar(50),null)
		/// </summary>
		public string HomeEmail2
		{
			get { return homeEmail2; }
			set { homeEmail2 = value; }
		}

		/// <summary>
		/// Property relating to database column Homepage(varchar(50),null)
		/// </summary>
		public string Homepage
		{
			get { return homepage; }
			set { homepage = value; }
		}

		/// <summary>
		/// Property relating to database column Notes(nvarchar(1000),null)
		/// </summary>
		public string Notes
		{
			get { return notes; }
			set { notes = value; }
		}

		/// <summary>
		/// Property relating to database column Owner(int,not null)
		/// </summary>
		public int Owner
		{
			get { return owner; }
			set { owner = value; }
		}

		/// <summary>
		/// Property relating to database column GroupID(int,null)
		/// </summary>
		public int GroupID
		{
			get { return groupID; }
			set { groupID = value; }
		}

		/// <summary>
		/// Property relating to database column Scope(tinyint,not null)
		/// </summary>
		public byte Scope
		{
			get { return scope; }
			set { scope = value; }
		}

		/// <summary>
		/// Property relating to database column Created_At(datetime,not null)
		/// </summary>
		public DateTime Created_At
		{
			get { return created_At; }
			set { created_At = value; }
		}

		/// <summary>
		/// Property relating to database column Created_By(int,not null)
		/// </summary>
		public int Created_By
		{
			get { return created_By; }
			set { created_By = value; }
		}

		/// <summary>
		/// Property relating to database column Last_Modified_At(datetime,not null)
		/// </summary>
		public DateTime Last_Modified_At
		{
			get { return last_Modified_At; }
			set { last_Modified_At = value; }
		}

		/// <summary>
		/// Property relating to database column Last_Modified_By(int,not null)
		/// </summary>
		public int Last_Modified_By
		{
			get { return last_Modified_By; }
			set { last_Modified_By = value; }
		}

		/// <summary>
		/// Property relating to database column flag(char(1),null)
		/// </summary>
		public string Flag
		{
			get { return flag; }
			set { flag = value; }
		}

        public string GroupName
		{
            get { return groupName; }
            set { groupName = value; }
		}

		#endregion

        #region "Public Methods"
        public override  string ToString()
           {
               StringBuilder sb = new StringBuilder();
  
               //Start VCard
               sb.AppendLine("BEGIN:VCARD"); sb.AppendLine("VERSION:2.1");
  
               //Name
               if( this.Fullname != null )
               {
                   sb.AppendLine("FN;CHARSET=utf-8:" + this.Fullname + "");
               }
               //Organisation
               sb.AppendLine("ORG;CHARSET=utf-8:" + this.OrgName + ";" + this.OrgUnit);
               //Title
               sb.AppendLine("TITLE;CHARSET=utf-8:" + this.OrgTitle);
               //Note
               sb.AppendLine("NOTE;CHARSET=utf-8:" + this.Notes);
               
               //Telephone
               sb.AppendLine("TEL;WORK;VOICE:" + this.OrgPhone);
               sb.AppendLine("TEL;HOME;VOICE:" + this.HomePhone);
                // Fax
               sb.AppendLine("TEL;WORK;FAX:" + this.OrgFax);
               sb.AppendLine("TEL;HOME;FAX:" + this.HomeFax);
               ////Mobile
               sb.AppendLine("TEL;CELL;VOICE:" + this.OrgMobile);
               sb.AppendLine("TEL;CELL;VOICE:" + this.HomeMobile);
               //Email
               sb.AppendLine("EMAIL;PREF;INTERNET:" + this.OrgEmail1);
               sb.AppendLine("EMAIL;INTERNET:" + this.OrgEmail2);
               ////Address
               sb.AppendLine("ADR;WORK:" + this.OrgAdr1);
               sb.AppendLine("ADR;HOME:" + this.OrgAdr2);
               //URL
               sb.AppendLine("URL;WORK:" + this.OrgWebsite);
               sb.AppendLine("URL;HOME:" + this.Homepage);

               sb.AppendLine("BDAY:" + this.Bday); 
              
               sb.Append("END:VCARD");
  
               return sb.ToString();
           }
        
        public void ReadFromString(String str)
        { 

            using (StringReader reader = new StringReader(str))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.IndexOf("FN") >= 0)
                        this.Fullname = line.Substring(line.IndexOf(":") + 1);
                    if (line.IndexOf("ORG") >= 0)
                        this.OrgName = line.Substring(line.IndexOf(":") + 1);
                    if (line.IndexOf("TITLE") >= 0)
                        this.OrgTitle = line.Substring(line.IndexOf(":") + 1);
                    if (line.IndexOf("NOTE") >= 0)
                        this.Notes = line.Substring(line.IndexOf(":") + 1);
                    if (line.IndexOf("BDAY") >= 0)
                    {
                        String d = line.Substring(line.IndexOf(":") + 1);
                        if (Utilities.IsNullOrEmpty(d))
                        {
                            d = d.Substring(0, 4) + "/" + d.Substring(4, 2) + "/" + d.Substring(6, 2);
                            this.Bday = DateTime.Parse(d);
                        }
                            
                        
                    }
                        
                    if (line.IndexOf("URL") >= 0)
                    {
                        if (line.IndexOf("WORK") >= 0) this.OrgWebsite = line.Substring(line.IndexOf(":") + 1);
                        if (line.IndexOf("HOME") >= 0) this.Homepage = line.Substring(line.IndexOf(":") + 1);
                    }
                    if (line.IndexOf("EMAIL") >= 0)
                    {
                        if (line.IndexOf("PREF") >= 0)
                            this.OrgEmail1 = line.Substring(line.IndexOf(":") + 1);
                        else
                            this.HomeEmail1 = line.Substring(line.IndexOf(":") + 1);
                    }
                    if (line.IndexOf("ADR") >= 0)
                    {
                        if (line.IndexOf("WORK") >= 0) this.OrgAdr1 = line.Substring(line.IndexOf(":") + 1);
                        if (line.IndexOf("HOME") >= 0) this.HomeAdr1 = line.Substring(line.IndexOf(":") + 1);
                    }
                    if (line.IndexOf("TEL") >= 0)
                    {
                        if (line.IndexOf("FAX") >= 0)
                        {
                            if (line.IndexOf("WORK") >= 0) this.OrgFax = line.Substring(line.IndexOf(":") + 1);
                            if (line.IndexOf("HOME") >= 0) this.HomeFax = line.Substring(line.IndexOf(":") + 1);
                        }
                        if (line.IndexOf("VOICE") >= 0)
                        {
                            if (line.IndexOf("WORK") >= 0) this.OrgPhone = line.Substring(line.IndexOf(":") + 1);
                            if (line.IndexOf("HOME") >= 0) this.HomePhone = line.Substring(line.IndexOf(":") + 1);
                            if (line.IndexOf("CELL") >= 0) this.OrgMobile = line.Substring(line.IndexOf(":") + 1);
                        }
                    }


                }
            }
 
        }
       
        #endregion
       }
}
