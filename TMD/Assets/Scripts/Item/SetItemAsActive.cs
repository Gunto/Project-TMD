using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetItemAsActive : MonoBehaviour
{
    private Animator animator;
    private bool isActiveItem;
    public bool IsActiveItem { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isActiveItem = animator.GetBool("Active");
    }

    public void SwitchItem()
    {
        //Switch value
        isActiveItem = !isActiveItem;

        //Trigger animation
        animator.SetBool("Active", isActiveItem);

        //Set render order
        if (!isActiveItem)
        {
            transform.SetAsFirstSibling();
        }
    }
}
