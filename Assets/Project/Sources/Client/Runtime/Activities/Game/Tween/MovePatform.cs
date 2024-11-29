using UnityEngine;
using DG.Tweening;

public class PlatformMoveAnimation : MonoBehaviour
{
    [SerializeField] private Transform _platform; 
    [SerializeField] private float moveDistance = 5f; 
    [SerializeField] private float duration = 2f; 

    private void Start()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        Vector3 targetPosition = _platform.position + new Vector3(moveDistance, 0, 0);

        _platform.DOMoveX(targetPosition.x, duration)
                 .SetLoops(-1, LoopType.Yoyo)
                 .SetEase(Ease.Linear);
    }
}
