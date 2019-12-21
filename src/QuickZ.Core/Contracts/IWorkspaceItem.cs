using System;
using System.Linq;

namespace QuickZ.Core.Models
{
    public interface IWorkspace
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string ConnectionString { get; }
        string Database { get; set; }
        string DBType { get; set; }            
        string Password { get; set; }
        string Port { get; set; }
        string Server { get; set; }
        string UserName { get; set; }
    }
}
