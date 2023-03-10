using UnityEngine;
using DG.Tweening;

public class TestAnimations : MonoBehaviour
{
    public Light pointLight;
    public Transform leftSphere;
    public Transform cube;
    public Transform rightSphere;

    public float duration;
    
    public float speed;
    private Vector3 startPositionOfLeftSphere;
    private Vector3 finishPositionOfLeftSphere;
    private float pathPercentage;
    
    private void Awake()
    {
        startPositionOfLeftSphere = leftSphere.position;
        finishPositionOfLeftSphere = startPositionOfLeftSphere + new Vector3(0, 0, 10);
    }
    
    private void Start()
    {
        // Initialize
        DOTween.Init();

        // The generic way (Move Sphere)
        DOTween.To(() => rightSphere.position,
            x => rightSphere.position = x,
            rightSphere.position + new Vector3(0, 0, 10),
            duration);
        
        // The shortcuts way (Rotate Sphere)
        rightSphere.DOLocalRotate(new Vector3(720, 0, 0), duration, RotateMode.FastBeyond360);

        var position = cube.position.y;
        var targetPosition = position + 2;
        
        // Create animation sequence
        var tweenAnimation = DOTween.Sequence();
        tweenAnimation.Append(cube.DOMoveY(targetPosition, duration));
        tweenAnimation.Join(cube.DOLocalRotate(new Vector3(0, 360, 0), duration, RotateMode.WorldAxisAdd));
        tweenAnimation.Append(cube.DOShakeRotation(duration));
        tweenAnimation.Join(cube.DOShakeScale(duration / 2).SetLoops(2));
        tweenAnimation.AppendCallback(AnimationPart);
        tweenAnimation.Append(cube.DOMoveY(position, duration));

        // Add Complete sequence action
        tweenAnimation.onComplete += FinishAnimation;
    }
    
    private void Update()
    {
        if (pathPercentage > 1f)
            return;
        
        pathPercentage += speed;
        leftSphere.position = Vector3.Lerp(startPositionOfLeftSphere, finishPositionOfLeftSphere, pathPercentage);
        leftSphere.eulerAngles = new Vector3(Mathf.Lerp(0, 720, pathPercentage), 0, 0);
    }
    
    private void AnimationPart()
    {
        var tweenAnimation = DOTween.Sequence();
        tweenAnimation.Append(cube.DOScale(Vector3.one * 0.1f, duration / 10f));
        tweenAnimation.AppendInterval(1);
        tweenAnimation.Append(cube.DOScale(Vector3.one * 2, duration / 10f));
    }

    private void FinishAnimation()
    {
        cube.DOScale(Vector3.zero, duration / 10f);
        pointLight.DOIntensity(0, duration);
        Debug.Log("Finished");
    }
}
