using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public RectTransform image;
    private GameObject _currentVideo;
    private GameObject _nextVideo;
    
    public void FadeStart(GameObject currentVideo, GameObject nextVideo)
    {
        _currentVideo = currentVideo;
        _nextVideo = nextVideo;
        LeanTween.alpha(image, 1f, 1f).setEase(LeanTweenType.linear).setOnComplete(FadeFinished);
    }
    
    private void FadeFinished()
    {
        _currentVideo.SetActive(false);
        _nextVideo.SetActive(true);
        LeanTween.alpha(image, 0f, 1f).setEase(LeanTweenType.linear);
    }
}
