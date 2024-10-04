/************************************************************************/
/* File Name  : Constants.cs                                            */
/* File Version  : 1.0                                                  */
/* Project Name  : VietNamNet.AddOn.Tracker                             */
/* Product Version : 1.0                                                */
/* Copyright(C) 2010 Developer Team - VietNamNet. All Rights Reserved   */
/************************************************************************/
/* Description : Khai báo const của các Tracker                         */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/* File history                                                         */
/* 17/09/2010 File Create                                               */
/* 08/11/2010 Edit for thethao.vietnamnet.vn                            */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/************************************************************************/
namespace VietNamNet.AddOn.Tracker.Components
{
    public class SurveyConstants
    {
        public class ServiceName
        {

        }
        public class ParameterName
        {
            public const string RandId = "randId";
            public const string SurveyId = "surveyId";
            public const string ItemId = "itemId";

            // tracking for Survey game in Thethao.vietnamnet.vn
            public const string Name = "name"; // Ho ten
            public const string IdentityCard = "identityCard"; // CMND
            public const string Phone = "phone"; // So dien thoai
            public const string Address = "address"; // Dia chi lien lac
            public const string Email = "email"; // Dia chi Email


        }

    }
}
