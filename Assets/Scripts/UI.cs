using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class UI : MonoBehaviour, IPointerDownHandler
{
    public GameObject currentVideo;
    public GameObject nextVideo;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        currentVideo.SetActive(false);
        nextVideo.SetActive(true);

    }
}