using UnityEngine;
using UnityEngine.UI;

public class PanelFadeOut : MonoBehaviour
{
    private Image whitePanelImage;
    [SerializeField] private float fadeDuration = 1.5f;

    void Start()
    {
        whitePanelImage = GetComponent<Image>();
        StartCoroutine(FadeOut());
    }

    System.Collections.IEnumerator FadeOut()
    {
        float elapsed = 0f;
        Color startColor = whitePanelImage.color;

        yield return new WaitForSeconds(0.5f);

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            whitePanelImage.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        whitePanelImage.gameObject.SetActive(false);
    }
}
