using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickZ.Core.Contracts.Templates
{
    public enum TemplateType
    {
        FileAttachment = 1, // Any File
        MailMerge = 2, // Snap Document
        DataReport = 3, // XtraReport
        Dashboard = 4, // XtraDashboard
        Spreadsheet = 5, // XtraSpreadsheet
        PortableForm = 6 // PDF Data Form
    }

    public interface IDocumentTemplate
    {
        string Name { get; set; }
        TemplateType TemplateType { get; }
        bool ShowAsInplaceDocument { get; set; }
    }

    public interface IDocumentTemplateAsAttachment
    {
        string FileNameAsAttachment { get; set; }
    }

    public interface ITemplateFile
    {
        byte[] Content { get; set; }
        string FileName { get; set; }
        string ExtName { get; }
        string RealFileName { get; }
        int StoredFileSize { get; }
        byte[] OriginalContent { get; set; }
        string OriginalFileName { get; set; }
        DateTime?OriginalDate { get; set; }        
        int OriginalSize { get; set; }
    }

    public interface ITemplateReport
    {
        string Category { get; set; }
        string DataTypeCaption { get; }
        string ParametersObjectTypeName { get; set; }
    }
}
