


using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    [SerializeField] private CanvasGroup coinCanvasGroup; 
    [SerializeField] private Transform sparkleEffect; 
    [SerializeField] private Transform coinTransform;
    [SerializeField] private Transform targetCorner;

    private void Start()
    {
        coinCanvasGroup.alpha = 0;
        sparkleEffect.gameObject.SetActive(false);
    }

    public void PlayCoinAnimation()
    {
        Sequence coinSequence = DOTween.Sequence();

        coinSequence.Append(coinCanvasGroup.DOFade(1, 0.5f));

        coinSequence.AppendCallback(() =>
        {
            sparkleEffect.gameObject.SetActive(true);
        });

        if (targetCorner != null)
        {
            StartCoroutine(MoveToTarget());
        }
        else
        {
            Debug.LogWarning("Target Corner не назначен в Inspector!");
        }

        coinSequence.AppendCallback(() =>
        {
            sparkleEffect.gameObject.SetActive(false);
        });
        coinSequence.Append(coinCanvasGroup.DOFade(0, 0.5f));

        coinSequence.OnComplete(() => Destroy(gameObject));
        coinSequence.Play();
    }

    private System.Collections.IEnumerator MoveToTarget()
    {
        float duration = 1f; 
        float elapsed = 0f; 

        Vector3 startPosition = coinTransform.position;

        while (elapsed < duration)
        {
            coinTransform.position = Vector3.Lerp(startPosition, targetCorner.position, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        coinTransform.position = targetCorner.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayCoinAnimation();
        }
    }
}
