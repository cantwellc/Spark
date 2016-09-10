using UnityEditor;
class BuildScript
{
	
	static void PerformBuild ()
	{
		var sceneArray = new EditorBuildSettingsScene[1];
		sceneArray[0] = new EditorBuildSettingsScene("Assets/Scenes/WormholeTest.unity", true);
		EditorBuildSettings.scenes = sceneArray;
	}
}
