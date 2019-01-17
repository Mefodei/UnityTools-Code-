﻿using System;
using UniEditorTools;
using UniStateMachine;
using UniStateMachine.Nodes;
using UnityEngine;
using XNode;
using XNodeEditor;

namespace SubModules.Scripts.UniStateMachine.NodeEditor
{
	[CustomNodeEditor(typeof(UniGraphNode))]
	public class UniNodeEditor : XNodeEditor.NodeEditor
	{
		public static Type UniPortValueType = typeof(UniPortValue);
		
		public bool IsSelected()
		{
			var node = target as UniGraphNode;
			if (!node)
				return false;
			return node.IsAnyActive;
		}
		
		private static GUIStyle SelectedHeaderStyle = 
			new GUIStyle()
		{
			alignment = TextAnchor.MiddleCenter,
			fontStyle = FontStyle.Bold,		
		};

		public override void OnHeaderGUI()
		{
			if (IsSelected())
			{
				EditorDrawerUtils.DrawWithContentColor(Color.red, base.OnHeaderGUI);
				return;
			}
			base.OnHeaderGUI();
		}

		public override void OnBodyGUI()
		{
			var node = target as UniGraphNode;
			
			base.OnBodyGUI();
			
			//node.Invalidate();
			node.UpdatePortsCache();

			DrawPorts(node);
		}

		public override GUIStyle GetBodyStyle()
		{
			return base.GetBodyStyle();
		}

		public virtual void DrawPorts(UniGraphNode node)
		{

			foreach (var portValue in node.PortValues)
			{
				
				var port = node.GetPort(portValue.Name);
				var portStyle = GetPortStyle(port);
				
				port.DrawPortField(portStyle);
			}
			
		}


		private NodeGuiLayoutStyle GetPortStyle(NodePort port)
		{
			var portStyle = NodeEditorGUILayout.GetDefaultPortStyle(port);

			if (port == null)
				return portStyle;
			
  			if (port.fieldName == UniNode.OutputPortName || port.fieldName == UniNode.InputPortName)
			{
				portStyle.Background = Color.blue;
				portStyle.Color = Color.white;
				return portStyle;
			}
			
			if (port.IsDynamic)
			{
				portStyle.Name = port.fieldName;
				portStyle.Background = Color.red;
				portStyle.Color = port.direction  == NodePort.IO.Input ?
					Color.green : Color.blue;
			}
			
			return portStyle;
		}
		
	}
}