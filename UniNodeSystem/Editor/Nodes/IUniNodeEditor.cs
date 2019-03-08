using System.Collections.Generic;
using Modules.UniTools.UniNodeSystem.Editor.BaseEditor;
using UniStateMachine;
using UnityEngine;
using UniNodeSystem;
using UniNodeSystemEditor;

namespace UniStateMachine.NodeEditor
{
    public interface IUniNodeEditor : INodeEditor
    {
        bool IsSelected();

    }
}