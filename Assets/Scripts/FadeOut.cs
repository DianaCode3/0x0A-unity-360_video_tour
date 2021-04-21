using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public SpriteRenderer image;
    public GameObject imageObject;
    private GameObject _currentVideo;
    private GameObject _nextVideo;

    
    public void FadeStart(GameObject currentVideo, GameObject nextVideo)
    {
        _currentVideo = currentVideo;
        _nextVideo = nextVideo;

        LeanTween.value(imageObject, 0, 1, 2f).setOnUpdate((float val) =>
        {
            Color c = image.color;
            c.a = val;
            image.color = c;
        }).setOnComplete(FadeFinished);
    }
    
    private void FadeFinished()
    {
        _currentVideo.SetActive(false);
        _nextVideo.SetActive(true);
        
        LeanTween.value(imageObject, 1, 0, 2f).setOnUpdate((float val) =>
        {
            Color c = image.color;
            c.a = val;
            image.color = c;
        });
    }
}
