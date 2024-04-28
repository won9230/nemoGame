using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
	private Vector3 moveDirectuon;
	private RaycastHit2D hit;
	
	[SerializeField] private float moveSpeed = 4f;
	[SerializeField] private float jumpForce = 10f;
	[SerializeField] private float maxJumpTime = 2f;

	private Rigidbody2D rb;
	private bool isJumping = false;
	private bool isReadyJump = false;
	private float jumpTime = 0f;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		//transform.rotation = Quaternion.LookRotation(moveDirectuon);
		transform.Translate(moveDirectuon * Time.deltaTime * moveSpeed);


	}
	private void FixedUpdate()
	{
		Debug.DrawRay(transform.position, new Vector3(0, -1f, 0) * 0.7f, Color.red);

		hit = Physics2D.Raycast(transform.position, new Vector3(0, -1f, 0) , 0.7f,LayerMask.GetMask("Ground"));

		if (hit.collider != null && hit.collider.CompareTag("Ground") && !isJumping)
		{
			isReadyJump = false;
		}

		if (isJumping)
		{
			if (jumpTime < maxJumpTime)
			{
				rb.velocity = new Vector2(rb.velocity.x, jumpForce);
				jumpTime += Time.fixedDeltaTime;
			}
			else
			{
				isJumping = false;
			}
		}
	}

	public void OnMove(InputAction.CallbackContext context)
	{
		Vector2 input = context.ReadValue<Vector2>();
		moveDirectuon = new Vector2(input.x, input.y);
	}
	public void OnJump(InputAction.CallbackContext context)
	{
		if(context.started && !isJumping && !isReadyJump)	//눌렀을 떄
		{
			Debug.Log("asd");
			isJumping = true;
			isReadyJump = true;
			jumpTime = 0f;
			Jump();
		}
		else if(context.performed && isJumping)
		{
			Jump();
		}
		else if (context.canceled && isJumping) //해제될때
		{
			isJumping = false;
		}
	}

	private void Jump()
	{
		rb.velocity = new Vector2(rb.velocity.x, jumpForce + (jumpTime * maxJumpTime));

	}
}
