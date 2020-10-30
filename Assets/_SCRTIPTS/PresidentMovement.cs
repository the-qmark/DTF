using System.Collections;
//using System.Collections.Generic;
//using UnityEditor.Rendering;
using UnityEngine;

public class PresidentMovement : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float speedOfWalkMin;
    [SerializeField] float speedOfWalkMax;

    const string WALK_ANIM = "Walk";
    const string DEATH_ANIM = "Death";

    private float currentSpeedOfWalk;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.right * currentSpeedOfWalk * Time.deltaTime);
    }

    public void GameStart()
    {
        animator.Play(WALK_ANIM);
        currentSpeedOfWalk = speedOfWalkMin;
        StartCoroutine(SpeedIncrease());
    }

    public void GameOver()
    {
        animator.Play(DEATH_ANIM);
        currentSpeedOfWalk = 0;
        StopCoroutine(SpeedIncrease());
    }

    private IEnumerator SpeedIncrease()
    {
        WaitForSeconds tenSec = new WaitForSeconds(10f);

        while(currentSpeedOfWalk < speedOfWalkMax)
        {
            yield return tenSec;
            currentSpeedOfWalk += 1;
        }
    }
}