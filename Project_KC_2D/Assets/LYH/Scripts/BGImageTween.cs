using UnityEngine;
using DG.Tweening; // DOTween 네임스페이스 추가

public class BGImageTween : MonoBehaviour
{
    [SerializeField] private float[] xLocations; // 이동할 x 좌표들
    private RectTransform rect;
    private int index = 0;

    [SerializeField] private float tweenTime = 0.6f; // 트윈 시간 (초)

    void Start()
    {
        rect = GetComponent<RectTransform>();
        index = 0;
    }

    public void MoveBG(int index)
    {
        if (index < 0 || index >= xLocations.Length)
        {
            Debug.LogWarning("잘못된 index 요청됨: " + index);
            return;
        }

        // 현재 y 값은 유지하고 x 값만 변경
        Vector2 targetPos = new Vector2(xLocations[index], rect.anchoredPosition.y);

        rect.DOAnchorPos(targetPos, tweenTime).SetEase(Ease.OutCubic);
    }

    public void changeUpIndex()
    {
        index++;
        if (index > 2) index = 2;
        MoveBG(index);
    }
    public void changeDownIndex()
    {
        index--;
        if (index < 0) index = 0;
        MoveBG(index);
    }
}
