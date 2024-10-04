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
/* 26/11/2010 File Create                                               */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/************************************************************************/
using System;
using System.Xml.Serialization;

namespace VietNamNet.AddOn.Tracker.Components
{
    [Serializable]
    [XmlRoot("msg")]
    public class ArticleMessageObj
    {
        #region Members
        private string _articleId;
        private string _categoryAlias;
        private DateTime _createdAt; 
        #endregion

        #region Public Properties

        [XmlAttribute("aid")]
        public string ArticleId
        {
            get { return _articleId; }
            set { _articleId = value; }
        }

        [XmlAttribute("cate")]
        public string CategoryAlias
        {
            get { return _categoryAlias; }
            set { _categoryAlias = value; }
        }

        #endregion

        #region Contructor

        public ArticleMessageObj()
        {
        }

        public ArticleMessageObj(string articleId, string categoryAlias)
        {
            _articleId = articleId;
            _categoryAlias = categoryAlias;
        }

        #endregion

    }
}
