using UniStateMachine;
using UniStateMachine.NodeEditor;
using UniNodeSystem;
using UniNodeSystemEditor;

namespace Modules.UniTools.UniNodeSystem.Editor.Drawers
{
    public interface INodeEditorDrawer
    {
        
        bool Draw(INodeEditor editor,UniBaseNode node);
        
    }
}