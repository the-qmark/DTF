using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PresidentController : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] float speedOfWalk;

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
        animator.SetBool("GameStart", true);
        currentSpeedOfWalk = speedOfWalk;
    }

    public void GameOver()
    {
        animator.SetBool("GameOver", true);
    }
}
