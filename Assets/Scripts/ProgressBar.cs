using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Player Player;
    public Transform FinishPlatform;
    public Slider Slider;
    public float AcceptableFinishPlayerDistance = 1.0f;

    private float _startY;
    private float _minimalReachedY;

    private void Start()
    {
        _startY = Player.transform.position.y;
    }

    private void Update()
    {
        _minimalReachedY = Mathf.Min(_minimalReachedY, Player.transform.position.y); 
        float currentY = Player.transform.position.y;
        float finishY = FinishPlatform.position.y;
        float t = Mathf.InverseLerp(_startY, finishY + AcceptableFinishPlayerDistance, _minimalReachedY);
        Slider.value = t;
    }
}
