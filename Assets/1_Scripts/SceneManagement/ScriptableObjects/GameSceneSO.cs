using UnityEngine;
using UnityEngine.AddressableAssets;

/// <summary>
/// This class is a base class which contains what is common to all game scenes
/// </summary>
public class GameSceneSO : DescriptionBaseSO
{
	public GameSceneTypeSO sceneType;
	public AssetReference sceneReference; //Used at runtime to load the scene from the right AssetBundle
	//public AudioCueSO musicTrack;
}