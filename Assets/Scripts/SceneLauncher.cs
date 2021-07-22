using UnityEditor;
using UnityEditor.SceneManagement;

public static class SceneLauncher
{
	[MenuItem("Launcher/StartScene", priority = 0)]
	public static void OpenGameScene()
	{
		EditorSceneManager.OpenScene("Assets/Scenes/StartScene.unity", OpenSceneMode.Single);
	}

	[MenuItem("Launcher/IntervalScene", priority = 0)]
	public static void OpenSampleScene()
	{
		EditorSceneManager.OpenScene("Assets/Scenes/IntervalScene.unity", OpenSceneMode.Single);
	}

	[MenuItem("Launcher/MainScene", priority = 0)]
	public static void OpenTitleScene()
	{
		EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity", OpenSceneMode.Single);
	}
}