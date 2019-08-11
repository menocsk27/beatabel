// No copyright

using UnrealBuildTool;
using System.Collections.Generic;

public class beatabelTarget : TargetRules
{
	public beatabelTarget(TargetInfo Target) : base(Target)
	{
		Type = TargetType.Game;

		ExtraModuleNames.AddRange( new string[] { "beatabel" } );
	}
}
