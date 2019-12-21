using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using QuickZ.Core.Contracts.Templates;
using System;
using System.Linq;

namespace QuickZ.Persistent.Xpo.BusinessObjects.Templates
{
    [NavigationItem(false), CreatableItem(true)]
    [XafDefaultProperty("DocumentName")]
    [ImageName("BOBusinessDocumentData")]
    [DevExpress.ExpressApp.DC.XafDisplayName("Business Document")]
    [MapInheritance(MapInheritanceType.ParentTable)]
    public abstract class QuickZTemplateDocumentBase : QuickZTemplateFileBase, IDocumentTemplate
    {                
        private bool _ShowAsInplaceDocument;        
        private string _Description;
        private string _Name;
        private TemplateType documentType;

        public QuickZTemplateDocumentBase(Session session)
            : base(session)
        {

        }
        public QuickZTemplateDocumentBase(Session session, Guid oidOverride)
            : base(session, oidOverride)
        {
            
        }

        /// This Filename will override the FileName after a particular data-merging process 
        // For example:
        // 1. When generating attachments to an Email
        string fileNameAsAttachment;
        [Size(255)]
        public string FileNameAsAttachment
        {
            get
            {
                return fileNameAsAttachment;
            }
            set
            {
                SetPropertyValue("FileNameAsAttachment", ref fileNameAsAttachment, value);
            }
        }

        [VisibleInDetailView(false)]
        [Size(255)]
        [ImmediatePostData]
        [XafDisplayName("Document Name")]
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                SetPropertyValue(nameof(Name), ref _Name, value);
            }
        }

        [VisibleInDetailView(false)]
        [ImmediatePostData]
        public TemplateType TemplateType
        {
            get { return documentType; }
            set { SetPropertyValue("DocumentType", ref documentType, value); }

        }

        [Size(2048)]
        public string Description
        {
            get
            {
                return _Description;
            }
            set

            {
                SetPropertyValue("Description", ref _Description, value);
            }
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);

            switch (propertyName)
            {
                case "DocumentName":
                    if (String.IsNullOrEmpty(FileNameAsAttachment) && TemplateType != TemplateType.FileAttachment)
                        FileNameAsAttachment = Name + ".pdf";
                    break;
            }
        }

        /// <summary>
        /// Filters which documents are shown in a Print List option
        /// </summary>
        public bool ShowAsInplaceDocument
        {
            get
            {
                return _ShowAsInplaceDocument;
            }
            set
            {
                SetPropertyValue("ShowAsInplaceDocument", ref _ShowAsInplaceDocument, value);
            }
        }

        protected override void OnSaving()
        {
            base.OnSaving();            
        }

    }
}
