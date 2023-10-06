using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{

    [SerializeField]
    private GameObject item;
    private Tweener tweener;
    private List<Vector3> moves;
    private int movesIndex;
    private Animator anim;
    public AudioClip movingAudio;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
        anim = item.GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = movingAudio;
        audioSource.Play();
        audioSource.loop = true;

        moves = new List<Vector3>();
        moves.Add(new Vector3(5.0f, 0.0f, 0.0f));
        moves.Add(new Vector3(0.0f, -4.0f, 0.0f));
        moves.Add(new Vector3(-5.0f, 0.0f, 0.0f));
        moves.Add(new Vector3(0.0f, 4.0f, 0.0f));
        movesIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (tweener.AddTween(item.transform, item.transform.position, item.transform.position + moves[movesIndex])) {
            
            var dir = movesIndex == 0 ? "Right" :
                movesIndex == 1 ? "Down" :
                movesIndex == 2 ? "Left" : "Up";
            anim.SetTrigger(dir);
            movesIndex++;
            movesIndex = (movesIndex == 4) ? 0 : movesIndex;
        }
    }
}
