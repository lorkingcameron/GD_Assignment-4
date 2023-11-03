using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    // private Tween activeTween;
    private List<Tween> activeTweens = new List<Tween>();
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (activeTweens.Count > 0) {
            for (int i = 0; i < activeTweens.Count; i++) {
                float distance = Vector3.Distance(activeTweens[i].Target.position, activeTweens[i].EndPos);

                if (distance > 0.1f) {
                    Vector3 movePos = Vector3.MoveTowards(activeTweens[i].Target.position, activeTweens[i].EndPos, Time.deltaTime * activeTweens[i].Speed);
                    activeTweens[i].Target.position = movePos;
                } else {
                    activeTweens[i].Target.position = activeTweens[i].EndPos;
                    activeTweens.Remove(activeTweens[i]);
                }
            }
        } 
    }

    public bool AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float speed = 3.0f) {
        if (TweenExists(targetObject)) {
            return false;
        } else {
            activeTweens.Add(new Tween(targetObject, startPos, endPos, speed));
            return true;
        }
    }

    public bool TweenExists(Transform target) {
        foreach (Tween tween in activeTweens) {
            if (tween.Target.Equals(target)) {
                return true;
            }
        }
        return false;
    }
}
