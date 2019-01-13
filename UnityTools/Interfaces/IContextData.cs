﻿using System.Collections.Generic;
using Assets.Modules.UnityToolsModule.Tools.UnityTools.DataFlow;
using Assets.Tools.UnityTools.ObjectPool.Scripts;
using UnityTools.Common;

namespace Assets.Tools.UnityTools.Interfaces
{

    public interface IContextData<TContext> : IContextDataWriter<TContext>, ICopyableData<TContext>
    {
        IReadOnlyCollection<TContext> Contexts { get; }

        TData Get<TData>(TContext context);

        bool RemoveContext(TContext context);
        
        bool Remove<TData>(TContext context);

    }

    public interface IContextDataWriter<TContext>
    {
             
        bool HasContext(TContext context);
   
        void UpdateValue<TData>(TContext context, TData value);

    }

    public interface ICopyableData<TContext>
    {
        /// <summary>
        /// copy context values to new container
        /// </summary>
        /// <param name="context">key context</param>
        /// <param name="writer">container writer</param>
        void CopyTo(TContext context, IDataWriter writer);
    }
}