using UnityEngine;

/// <summary>
/// Base class for ScriptableObjects that need a public description field.
/// </summary>
public class DescriptionBaseSO : ScriptableObject
{
	[TextArea(2,10)] public string description;
}