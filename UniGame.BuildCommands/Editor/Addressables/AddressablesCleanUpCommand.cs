﻿namespace UniModules.UniGame.BuildCommands.Editor.Addressables
{
    using AddressableTools.Editor.Extensions;
    using UniBuild.Editor.ClientBuild.Commands.PreBuildCommands;
    using UniBuild.Editor.ClientBuild.Interfaces;
    using UnityEditor.Build.Pipeline.Utilities;
    using UnityEngine;

    public enum CleanType
    {
        CleanAll,
        CleanContentBuilders,
        CleanBuildPipelineCache,
    }
    
    [CreateAssetMenu(menuName = "UniGame/UniBuild/Commands/Addressables Cleanup", fileName = nameof(AddressablesCleanUpCommand))]
    public class AddressablesCleanUpCommand : UnityPreBuildCommand
    {
        [Tooltip("Clean Addressables Library cache")]
        public bool CleanUpLibraryCache = true;
        
        [Tooltip("Clean Addressables Library cache")]
        public bool CleanUpStreamingCache = true;

        public CleanType CleanType = CleanType.CleanAll;
        
        public override void Execute(IUniBuilderConfiguration buildParameters)
        {
            if (CleanUpLibraryCache) {
                AddressablesCleaner.RemoveLibraryCache();
            }

            if (CleanUpStreamingCache) {
                AddressablesCleaner.RemoveStreamingCache();
            }
            
            switch (CleanType) {
                case CleanType.CleanAll:
                    CleanAll();
                    break;
                case CleanType.CleanContentBuilders:
                    AddressablesCleaner.CleanPlayerContent(null);
                    break;
                case CleanType.CleanBuildPipelineCache:
                    OnCleanSBP();
                    break;
            }
        }
        
        public void CleanAll()
        {
            AddressablesCleaner.CleanAll();
            OnCleanSBP();
        }

        public void OnCleanSBP()
        {
            BuildCache.PurgeCache(true);
        }
        
    }
}