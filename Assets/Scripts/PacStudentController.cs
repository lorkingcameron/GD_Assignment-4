using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    // enum Direction {Up, Down, Left, Right};

    // x + 0.5, y * -1 + 0.5
    [SerializeField]
    private GameObject item;
    private int lastInput = 0;
    private int currentInput = 0;
    private Vector3 move;
    private int[] currentPos = {1, 1};
    private string dir;
    private Tweener tweener;
    private Animator anim;
    public AudioClip movingAudio;
    private AudioSource audioSource;
    private DustParticleEffect dustEffect;

    private int[,] levelMap = {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7,7,2,2,2,2,2,2,2,2,2,2,2,2,1},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4,4,5,5,5,5,5,5,5,5,5,5,5,5,2},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4,4,5,3,4,4,4,3,5,3,4,4,3,5,2},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4,4,5,4,0,0,0,4,5,4,0,0,4,6,2},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3,3,5,3,4,4,4,3,5,3,4,4,3,5,2},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4,4,4,4,3,5,3,3,5,3,4,4,3,5,2},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3,3,4,4,3,5,4,4,5,3,4,4,3,5,2},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,5,5,2},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4,4,0,3,4,4,3,4,5,1,2,2,2,2,1},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3,3,0,3,4,4,3,4,5,2,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0,0,0,0,0,0,4,4,5,2,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0,0,4,4,3,0,4,4,5,2,0,0,0,0,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0,0,0,0,4,0,3,3,5,1,2,2,2,2,2},
        {2,0,0,0,0,0,5,0,0,0,4,0,0,0,0,0,0,4,0,0,0,5,0,0,0,0,0,2},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0,0,0,0,4,0,3,3,5,1,2,2,2,2,2},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0,0,4,4,3,0,4,4,5,2,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0,0,0,0,0,0,4,4,5,2,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3,3,0,3,4,4,3,4,5,2,0,0,0,0,0},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4,4,0,3,4,4,3,4,5,1,2,2,2,2,1},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,5,5,2},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3,3,4,4,3,5,4,4,5,3,4,4,3,5,2},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4,4,4,4,3,5,3,3,5,3,4,4,3,5,2},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3,3,5,3,4,4,4,3,5,3,4,4,3,5,2},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4,4,5,4,0,0,0,4,5,4,0,0,4,6,2},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4,4,5,3,4,4,4,3,5,3,4,4,3,5,2},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4,4,5,5,5,5,5,5,5,5,5,5,5,5,2},
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7,7,2,2,2,2,2,2,2,2,2,2,2,2,1}
    };
    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
        anim = item.GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = movingAudio;
        anim.SetTrigger("Stop");

        dustEffect = item.GetComponent<DustParticleEffect>();
        // audioSource.Play();
        // audioSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            lastInput = 1;
        } else if (Input.GetKeyDown(KeyCode.A)) {
            lastInput = 2;
        } else if (Input.GetKeyDown(KeyCode.S)) {
            lastInput = 3;
        } else if (Input.GetKeyDown(KeyCode.D)) {
            lastInput = 4;
        }

        // If item in grid square
        if (Math.Abs(item.transform.position.x) % 1 == 0.5 && Math.Abs(item.transform.position.y % 1) == 0.5) {
            if (lastInput != 0) {
                switch (lastInput) {
                    case 1:
                        move = new Vector3(0, 1, 0);
                        dir = "Up";
                        break;
                    case 2:
                        move = new Vector3(-1, 0, 0);
                        dir = "Left";
                        break;
                    case 3:
                        move = new Vector3(0, -1, 0);
                        dir = "Down";
                        break;
                    case 4:
                        move = new Vector3(1, 0, 0);
                        dir = "Right";
                        break;
                }
                // If next square walkable
                if (new int[] {0, 5, 6}.Contains(levelMap[currentPos[1] - (int)move.y, currentPos[0] + (int)move.x])) {
                    audioSource.Play();
                    if (lastInput != currentInput || currentInput == 0) {
                        anim.ResetTrigger("Stop");
                        anim.SetTrigger(dir);
                    }
                    currentInput = lastInput;
                    if (tweener.AddTween(item.transform, item.transform.position, item.transform.position + move)) {
                        currentPos = new int[] {currentPos[0] + (int)move.x, currentPos[1] - (int)move.y};
                        dustEffect.Play();
                    }
                } else {
                    if (currentInput != 0) {
                        switch (currentInput) {
                            case 1:
                                move = new Vector3(0, 1, 0);
                                dir = "Up";
                                break;
                            case 2:
                                move = new Vector3(-1, 0, 0);
                                dir = "Left";
                                break;
                            case 3:
                                move = new Vector3(0, -1, 0);
                                dir = "Down";
                                break;
                            case 4:
                                move = new Vector3(1, 0, 0);
                                dir = "Right";
                                break;
                        }

                        // If next square walkable
                        if (new int[] {0, 5, 6}.Contains(levelMap[currentPos[1] - (int)move.y, currentPos[0] + (int)move.x])) {
                            if (tweener.AddTween(item.transform, item.transform.position, item.transform.position + move)) {
                                currentPos = new int[] {currentPos[0] + (int)move.x, currentPos[1] - (int)move.y};
                                audioSource.Play();
                                dustEffect.Play();
                            }
                        } else {
                            dustEffect.Stop();
                            anim.SetTrigger("Stop");
                            audioSource.Stop();
                        }
                    }
                }
            }
        }
    }
}
