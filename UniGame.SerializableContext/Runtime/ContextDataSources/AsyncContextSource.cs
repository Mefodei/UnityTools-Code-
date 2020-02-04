﻿namespace UniGreenModules.UniGame.SerializableContext.Runtime.Scriptable
{
    using Addressables;
    using AddressableTools.Runtime.Attributes;
    using Context.Runtime.Interfaces;
    using UniCore.Runtime.Interfaces;
    using UniRx.Async;
    using UnityEngine;

    [CreateAssetMenu(menuName = "UniGame/GameSystem/Sources/AsyncContext", fileName = nameof(AsyncContextSource))]
    public class AsyncContextSource : AsyncContextDataSource
    {
        [ShowAssetReference]
        public ContextAssetReference contextAsset;
    
        public override async UniTask<IContext> RegisterAsync(IContext context)
        {
            var contextReference = await contextAsset.LoadAssetAsync().Task;
            await contextReference.RegisterAsync(context);
            return context;
        }    
    }
}
