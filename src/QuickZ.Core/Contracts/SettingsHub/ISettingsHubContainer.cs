using QuickZ.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace QuickZ.Core.SettingsHub
{

    public interface ISettingsHubContainer
    {
        IList Workspaces { get; }
    }
}
