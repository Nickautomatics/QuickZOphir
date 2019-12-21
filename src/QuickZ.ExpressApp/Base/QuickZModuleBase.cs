using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Updating;

namespace QuickZ.ExpressApp
{
    public abstract class QuickZModuleBase : ModuleBase
    {
        public QuickZModuleBase()
         => DiffsStore = new NullDiffsStore(GetType().Assembly); 

        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
            => ModuleUpdater.EmptyModuleUpdaters;

        protected override IEnumerable<Type> GetDeclaredControllerTypes()
            => Type.EmptyTypes;

        protected override IEnumerable<Type> GetDeclaredExportedTypes()
            => Type.EmptyTypes;

        protected override IEnumerable<Type> GetRegularTypes()
            => Type.EmptyTypes;

        protected override ModuleTypeList GetRequiredModuleTypesCore()
            => new ModuleTypeList(
                typeof(SystemModule)
            );

        protected override void RegisterEditorDescriptors(EditorDescriptorsFactory editorDescriptorsFactory)
        {
        }
    }

    public class NullDiffsStore : ModelStoreBase
    {
        Assembly _Assembly;

        public NullDiffsStore(Assembly assembly)
            => _Assembly = assembly;

        public override string Name => $"{nameof(NullDiffsStore)} of the assembly '{_Assembly.FullName}'";

        public override void Load(ModelApplicationBase model)
        {
        }

        public override bool ReadOnly => true;
    }

    public static class ModuleBaseExtentions
    {
        public static ModuleTypeList AddModuleTypes(this ModuleTypeList moduleTypeList, params Type[] types)
        {
            moduleTypeList.AddRange(types);
            return moduleTypeList;
        }
    }
}

