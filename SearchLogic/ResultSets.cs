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
                Title = "Measure Request",
                Name = "Reginald Porter",
                Data = "seeker gun-owner"
            },
            new Document
            {
                objectType = "pdf",
                Title = "External Record",
                Name = "Abdullah Sayegh",
                Data = "seeker military conflict"
            },
            new Document
            {
                objectType = "pdf",
                Title = "Measure Request",
                Name = "Naif Asghar",
                Data = "permit ex-military"
            },
            new Document
            {
                objectType = "pdf",
                Title = "External Record",
                Name = "Amid Sarkis",
                Data = "citizenship doctor"
            },
            new Document
            {
                objectType = "pdf",
                Title = "Measure Request",
                Name = "Janis Jarans",
                Data = "citizenship teacher"
            },
            new Document
            {
                objectType = "pdf",
                Title = "Measure Request",
                Name = "Amid Sarkis",
                Data = "citizenship doctor"
            }
        };

        public static List<Document> caseDocuments = new List<Document>
        {
            new Document
            {
                objectType = "case",
                Title = "Citizenship",
                Name = "Janis Jarans",
                Data = "citizenship teacher"
            },
            new Document
            {
                objectType = "case",
                Title = "Citizenship",
                Name = "Abdullah Sayegh",
                Data = "seeker military conflict"
            },
            new Document
            {
                objectType = "case",
                Title = "Residence permit",
                Name = "Amid Sarkis",
                Data = "citizenship doctor"
            },
            new Document
            {
                objectType = "case",
                Title = "Asylum",
                Name = "Naif Asghar",
                Data = "permit ex-military"
            }
        };
    }
}