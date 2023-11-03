using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween
{
    public Transform Target { get; private set; }
    public Vector3 StartPos { get; private set; }
    public Vector3 EndPos { get; private set; }
    public float Speed { get; private set; }
    public float StartTime { get; private set; }

    public Tween(Transform target, Vector3 startPos, Vector3 endPos, float speed)
    {
        Target = target;
        StartPos = startPos;
        EndPos = endPos;
        Speed = speed;
    }
}
