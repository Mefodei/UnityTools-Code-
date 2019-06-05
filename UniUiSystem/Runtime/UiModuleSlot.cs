﻿
namespace UniUiSystem
{
    using UniGreenModules.UniCore.Runtime.DataFlow;
    using UniGreenModules.UniCore.Runtime.Interfaces;
    using UniGreenModules.UniCore.Runtime.ObjectPool;
    using UniModule.UnityTools.Interfaces;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UniUiSystem.Models;

    /// <summary>
    /// Ui module container
    /// </summary>
    public class UiModuleSlot : UIBehaviour, IUiModuleSlot
    {
        public string SlotName => name;
        
        public RectTransform Transform => transform as RectTransform;
        
        public void ApplySlotData(IContext context,ITypeData container,ILifeTime lifeTime)
        {
            
            var moduleData = CreateModuleData(context);
           
            lifeTime.AddCleanUpAction(() => moduleData.Despawn());
            container.Add(moduleData);

            UpdateContext(container,lifeTime);
            
        }

        /// <summary>
        /// create slot  
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected virtual UniUiModuleData CreateModuleData(IReadOnlyContext source)
        {
            var data = ClassPool.Spawn<UniUiModuleData>();
            data.Transform.Value = Transform;
            return data;
        }

        //update slot context data object
        protected virtual void UpdateContext(ITypeData container, ILifeTime lifeTime){}
    }
    
}