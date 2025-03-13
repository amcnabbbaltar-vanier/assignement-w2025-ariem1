using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
  private Animator animator;
  private CharacterMovement characterMovement;

  public AudioClip pickupSound;


  private Rigidbody rb;
  private int jumpCount = 0;
  public void Start()
  {
    animator = GetComponent<Animator>();
    characterMovement = GetComponent<CharacterMovement>();
    rb = GetComponent<Rigidbody>();
  }
  public void LateUpdate()
  {
    UpdateAnimator();
  }

  // TODO Fill this in with your animator calls
  void UpdateAnimator()
  {
    animator.SetFloat("Speed", rb.velocity.magnitude);
    animator.SetBool("IsGrounded", characterMovement.IsGrounded);

    //DO JUMP HERE
    if (Input.GetButtonUp("Jump"))
    {
      jumpCount++;
      Debug.Log(jumpCount);
      if (jumpCount == 2 && characterMovement.isJumpPowerUpActive)
      {

        animator.SetTrigger("doFlip");

        //  Play sound
        if (pickupSound != null)
        {
          AudioSource.PlayClipAtPoint(pickupSound, transform.position);
        }

        if (characterMovement.IsGrounded)
        {
          jumpCount = 0;
        }

      }
    }
  }
}
