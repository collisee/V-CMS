namespace VietNamNet.Framework.Tracking
{
    public class TrackingConstants
    {
        #region ParameterName

        public class ParameterName
        {
            public const string Domain = "dm";
            public const string ServiceName = "sn";
            public const string Action = "at";
            public const string User = "us";
            public const string Visit = "vs";
        }

        #endregion

        #region ConfigKey

        public class ConfigKey
        {
            public const string AllowServices = "AllowServices";
            public const string TrackingFolder = "TrackingFolder";
        }

        #endregion

        #region ServiceName

        public class ServiceName
        {
            public const string All = "All";
            public const string Default = "default";
        }

        #endregion
    }
}