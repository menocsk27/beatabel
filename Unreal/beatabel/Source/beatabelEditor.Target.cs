// No copyright

using UnrealBuildTool;
using System.Collections.Generic;

public class beatabelEditorTarget : TargetRules
{
	public beatabelEditorTarget(TargetInfo Target) : base(Target)
	{
		Type = TargetType.Editor;

		ExtraModuleNames.AddRange( new string[] { "beatabel" } );
	}
}
