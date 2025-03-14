using UnityEngine;

public class alwaysWalk : MonoBehaviour
{
    private Animator Animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Animator.SetBool("IsWalking", true);
    }
}
