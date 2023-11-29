using Game.Systems.PlayerSystem.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Systems.PlayerSystem.Controller
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private Animator[] animators;
        [SerializeField]
        private Rigidbody2D myRigidbody;

        [SerializeField]
        private PlayerRuntimeData runtimeData; 
        
        private float speed = 4f;
        private Vector3 playerMovement;

        private void Start()
        {
            // animators = GetComponent<Animator>();
            // myRigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            playerMovement = Vector3.zero;
            playerMovement.x = Input.GetAxisRaw("Horizontal");
            playerMovement.y = Input.GetAxisRaw("Vertical");

            UpdateAnimationAndMove();
        }

        private void UpdateAnimationAndMove()
        {
            if (playerMovement != Vector3.zero && !runtimeData.IsPlayerBusy())
            {
                MoveCharacter();
                SetAnimationData(playerMovement.x, playerMovement.y, true);
            }
            else
            {
                SetAnimationData(playerMovement.x, playerMovement.y, false);
            }
        }
        
        private void MoveCharacter()
        {
            myRigidbody.MovePosition(transform.position + playerMovement * (speed * Time.deltaTime));
        }
        
        private void SetAnimationData(float x, float y, bool isMoving)
        {
            foreach (Animator animator in animators)
            {
                animator.SetBool("moving", isMoving);

                if (isMoving)
                {
                    animator.SetFloat("moveX", x);
                    animator.SetFloat("moveY", y);
                }
            }
        }
    }
}