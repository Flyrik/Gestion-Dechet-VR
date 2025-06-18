using UnityEngine;
using DG.Tweening;
public class AnimationArrow : MonoBehaviour
{
    public float moveDistance = 0.5f; 
    public float moveDuration = 2f; 
    void Start()
    {
        
        AnimationDown();
    }

    void Update()
    {

    }

    public void AnimationDown()
    {
        transform.DOLocalMoveY(transform.position.y - moveDistance, moveDuration).SetEase(Ease.InOutSine).OnComplete(() =>

          transform.DOLocalMoveY(transform.position.y + moveDistance, moveDuration).SetEase(Ease.InOutSine).OnComplete(() =>
          
          AnimationDown()
          ));
           
    }
}
