using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;

namespace DAL
{
    /// <summary>
    /// Controller class for User
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class UserController
    {
        // Preload our schema..
        User thisSchemaLoad = new User();
        private string userName = string.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}

					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}

				}

				return userName;
            }

        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public UserCollection FetchAll()
        {
            UserCollection coll = new UserCollection();
            Query qry = new Query(User.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public UserCollection FetchByID(object Id)
        {
            UserCollection coll = new UserCollection().Where("Id", Id).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public UserCollection FetchByQuery(Query qry)
        {
            UserCollection coll = new UserCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (User.Delete(Id) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (User.Destroy(Id) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Status,string LoginName,string Email,DateTime? Birthday,string Sex,string FullName,string Password,string Address,string Phone,string Mobile,DateTime? LastLogin,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag)
	    {
		    User item = new User();
		    
            item.Status = Status;
            
            item.LoginName = LoginName;
            
            item.Email = Email;
            
            item.Birthday = Birthday;
            
            item.Sex = Sex;
            
            item.FullName = FullName;
            
            item.Password = Password;
            
            item.Address = Address;
            
            item.Phone = Phone;
            
            item.Mobile = Mobile;
            
            item.LastLogin = LastLogin;
            
            item.CreatedAt = CreatedAt;
            
            item.CreatedBy = CreatedBy;
            
            item.LastModifiedAt = LastModifiedAt;
            
            item.LastModifiedBy = LastModifiedBy;
            
            item.Flag = Flag;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string Status,string LoginName,string Email,DateTime? Birthday,string Sex,string FullName,string Password,string Address,string Phone,string Mobile,DateTime? LastLogin,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag)
	    {
		    User item = new User();
		    
				item.Id = Id;
				
				item.Status = Status;
				
				item.LoginName = LoginName;
				
				item.Email = Email;
				
				item.Birthday = Birthday;
				
				item.Sex = Sex;
				
				item.FullName = FullName;
				
				item.Password = Password;
				
				item.Address = Address;
				
				item.Phone = Phone;
				
				item.Mobile = Mobile;
				
				item.LastLogin = LastLogin;
				
				item.CreatedAt = CreatedAt;
				
				item.CreatedBy = CreatedBy;
				
				item.LastModifiedAt = LastModifiedAt;
				
				item.LastModifiedBy = LastModifiedBy;
				
				item.Flag = Flag;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}


