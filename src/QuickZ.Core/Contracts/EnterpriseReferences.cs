using System;
using System.Collections;
using System.Linq;

namespace QuickZ.Core.Contracts
{
    public enum EnterpriseAccountTypeEnum
    {
        /// <summary>
        /// License is applied to a single User
        /// </summary>
        Personal = 0,

        /// <summary>
        /// License can be applied to more than one User
        /// </summary>
        Corporate = 1
    }
   
    public interface IHasDisplayText
    {
        string GetDisplayText();
    }

    /// <summary>
    /// Any object that get saved to the local disk or a User
    /// </summary>
    public interface ISettingsHubObject
    {
    }
    public interface IReadOnlySetting {
    }

    /// <summary>
    /// Any object that is used internally by the enterprise system
    /// </summary>
    public interface IEnterpriseObject
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IEnterpriseAccountFactory
    {
        string FactoryName { get; set; }
        /// <summary>
        /// Tells QuickZ to create the Account data in the End-user's Local Disk
        /// </summary>
        Guid Oid { get;  }
    }

    /// <summary>
    /// A distinct account for a Unique User within the Enterprise
    /// A Unique User can come from an Active Directory or can be managed by the Enterprise itself
    /// </summary>
    public interface IEnterpriseAccount
    {
        string AccountName { get; set; }        
        string MasterLicense { get; set; }
        Guid Oid { get; }
    }

    public interface IAccountWithLicenses
    {
        /// <summary>
        /// A collection of licenses in XML format
        /// </summary>
        string Licenses { get; }
    }

    public interface IEnterpriseProduct
    {
        string ProductName { get; set; }
        string ProductCode { get; set; }
        string LatestVersion { get; set; }
        string Versions { get; set; }
    }

    /// <summary>
    /// Represents an instance of a User's Workspace state and data
    ///</summary>
    // TODO: Must be encrypted to protect sensitive data
    public interface IEnterpriseWorkspace
    {
        IEnterpriseAccount Account { get; }
        string ConnectionString { get; set; }
        bool IsLastActiveWorkSpace { get; set; }
        string LicenseKey { get; set; }
        string Name { get; set; }
        Guid Oid { get; }
    }

    public interface ILocalWorkspaceStash : IEnterpriseWorkspace
    {
        IEnterpriseWorkspace AccountWorkspace { get; }
        int Index { get; set; }
    }
}
