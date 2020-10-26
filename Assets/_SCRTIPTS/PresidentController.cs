using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PresidentController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float speedOfWalk;

    const string WALK_ANIM = "Walk";
    const string DEATH_ANIM = "Death";

    private float currentSpeedOfWalk;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * currentSpeedOfWalk * Time.deltaTime);
    }

    public void GameStart()
    {
        //animator.SetBool("GameStart", true);
        animator.Play(WALK_ANIM);
        currentSpeedOfWalk = speedOfWalk;
    }

    public void GameOver()
    {
        animator.Play(DEATH_ANIM);
    }
}



