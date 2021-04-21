using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VREyeRaycaster : MonoBehaviour
{
    private Camera _camera;
    private GameObject _gazedObject = null;

    private void Start() => _camera = Camera.main;
    
    
    public void Update()
    {
        var pointer = new PointerEventData(EventSystem.current);
        // set eye position (2d)
        pointer.position = _camera.WorldToScreenPoint(transform.forward);
        var raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, raycastResults);

    if (raycastResults.Count > 0) 
        {
            //GameObject detected in front of the camera.
            Debug.Log($"Gazed Object: {raycastResults[0].gameObject.name}");
            
            if (_gazedObject != raycastResults[0].gameObject)
            {
                // New GameObject.
                _gazedObject?.SendMessage("OnPointerExit", pointer);
                _gazedObject = raycastResults[0].gameObject;
                _gazedObject.SendMessage("OnPointerEnter", pointer);
            }
        }
        else
        {
            // No GameObject detected in front of the camera.
            _gazedObject?.SendMessage("OnPointerExit", pointer); // always getting one error when I disabled that object because it can't run the 'OnPointerExit' method
            _gazedObject = null;
        }
        
        // Checks for screen touches. (Cardboard and Editor)
        if (Google.XR.Cardboard.Api.IsTriggerPressed || Input.GetKeyDown(KeyCode.Space))
        {
            _gazedObject?.SendMessage("OnPointerClick", pointer);
        }
    }
}
