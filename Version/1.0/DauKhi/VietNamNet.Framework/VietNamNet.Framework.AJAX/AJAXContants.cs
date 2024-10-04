namespace VietNamNet.Framework.AJAX
{
    public enum AJAXType
    {
        HTML,
        XML,
        JavaScriptObject
    }

    public enum AJAXStatus
    {
        Start,
        BeforeExecute,
        Execute,
        AfterExecute,
        End,
        Error
    }

    public enum AJAXWhen
    {
        BeforeExecute,
        AfterExecute,
        Always
    }
}