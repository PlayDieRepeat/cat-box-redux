using UnityEngine;

[CreateAssetMenu(menuName = "Variable/FloatVariable")]
public class FloatVariableSO : DescriptionBaseSO
{
	public float Value;
	public bool IsRanged;
	public float minRange;
	public float maxRange;

	public void SetValue(float value)
	{
		Value = value;
	}

	public void SetValue(FloatVariableSO value)
	{
		Value = value.Value;
	}

	public void ApplyChange(float amount)
	{
		Value += amount;
	}

	public void ApplyChange(FloatVariableSO amount)
	{
		Value += amount.Value;
	}

	public void OnGUI()
	{
		
	}
}
