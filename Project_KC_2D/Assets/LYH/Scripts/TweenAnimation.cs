using UnityEngine;
using DG.Tweening;

public class TweenAnimation : MonoBehaviour
{
    [SerializeField] Vector2 targetPos = new Vector2(200, 200);
    [SerializeField] Vector2 targetSize = new Vector2(1200, 2000);
    [SerializeField] bool changeSize = false;

    private RectTransform movingObject;
    private Vector2 originalPos;
    private Vector2 originalSize;

    private void Start()
    {
        movingObject = GetComponent<RectTransform>();
        originalPos = movingObject.anchoredPosition;   // 시작할 때 위치 저장
        originalSize = movingObject.sizeDelta;         // 시작할 때 width/height 저장
    }

    public void moveAway() // targetPos, targetSize로 이동/확대
    {
        if (movingObject != null)
        {
            movingObject.DOAnchorPos(targetPos, 0.6f).SetEase(Ease.OutQuad);
            if (changeSize)
            {
                movingObject.DOSizeDelta(targetSize, 0.6f).SetEase(Ease.OutQuad);
            }
        }
        else
        {
            Debug.LogWarning("movingObject가 할당되지 않았습니다!");
        }
    }

    public void moveBack() // 원래 위치, 크기로 복귀
    {
        if (movingObject != null)
        {
            movingObject.DOAnchorPos(originalPos, 0.6f).SetEase(Ease.OutQuad);
            movingObject.DOSizeDelta(originalSize, 0.6f).SetEase(Ease.OutQuad);
        }
        else
        {
            Debug.LogWarning("movingObject가 할당되지 않았습니다!");
        }
    }
}
