using VietNamNet.Framework.Module;

namespace VietNamNet.Websites.Core.Common.ValueObject
{
  public class Comments : BaseObject
  {
    #region Members

    protected string detail;
    protected string email;
    protected string name;
    protected string phone;
    protected int pId;
    protected string subject;

    #endregion

    #region Public Properties

    /// <summary>
    /// Property relating to database column PId(int,not null)
    /// </summary>
    public int PId
    {
      get { return pId; }
      set { pId = value; }
    }

    /// <summary>
    /// Property relating to database column Name(nvarchar(255),not null)
    /// </summary>
    public string Name
    {
      get { return name; }
      set { name = value; }
    }

    /// <summary>
    /// Property relating to database column Email(nvarchar(255),not null)
    /// </summary>
    public string Email
    {
      get { return email; }
      set { email = value; }
    }

    /// <summary>
    /// Property relating to database column Phone(nvarchar(255),not null)
    /// </summary>
    public string Phone
    {
      get { return phone; }
      set { phone = value; }
    }

    /// <summary>
    /// Property relating to database column Subject(nvarchar(4000),not null)
    /// </summary>
    public string Subject
    {
      get { return subject; }
      set { subject = value; }
    }

    /// <summary>
    /// Property relating to database column Detail(nvarchar(4000),not null)
    /// </summary>
    public string Detail
    {
      get { return detail; }
      set { detail = value; }
    }

    #endregion
  }
}