using System;
using System.Collections.Generic;
using System.Text;
using Ultimate.Search.Processors;

namespace Processors
{
    public static class ResultSets
    {
        public static List<Document> pdfDocuments = new List<Document>
        {
            new Document
            {
                objectType = "pdf",
                Data = "Reginald Porter seeker gun-owner"
            },
            new Document
            {
                objectType = "pdf",
                Data = "Abdullah Sayegh seeker military conflict"
            },
            new Document
            {
                objectType = "pdf",
                Data = "Naif Asghar permit ex-military"
            },
            new Document
            {
                objectType = "pdf",
                Data = "Amid Sarkis citizenship doctor"
            },
            new Document
            {
                objectType = "pdf",
                Data = "Janis Jarans citizenship teacher"
            }
        };

        public static List<Document> caseDocuments = new List<Document>
        {
            new Document
            {
                objectType = "case",
                Data = "Reginald Porter "
            },
            new Document
            {
                objectType = "case",
                Data = "Abdullah Sayegh"
            },
            new Document
            {
                objectType = "case",
                Data = "Naif Asghar"
            }
        };
    }
}