using UnityEngine;
using UnityEngine.EventSystems;

[AddComponentMenu("Project/UI/MultiInputSelectableElement")]
public class MultiInputSelectableElement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler
{
	private MenuSelectionHandler _menuSelectionHandler;

	private void Awake()
	{
		_menuSelectionHandler = transform.root.gameObject.GetComponentInChildren<MenuSelectionHandler>();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		_menuSelectionHandler.HandleMouseEnter(gameObject);
		Debug.Log("This " + gameObject + " Handeled " + eventData);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		_menuSelectionHandler.HandleMouseExit(gameObject);
		Debug.Log("This " + gameObject + " Handeled " + eventData);
	}

	public void OnSelect(BaseEventData eventData)
	{
		_menuSelectionHandler.UpdateSelection(gameObject);
		Debug.Log("This " + gameObject + " Handeled " + eventData);
	}
}