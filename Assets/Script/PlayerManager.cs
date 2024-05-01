using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public enum CubeColorType
{
	Normal,
	Red,
	Green,
	Blue,
	Yellow
}

public class PlayerManager : MonoBehaviour
{
	private Vector3 moveDirectuon;
	private RaycastHit2D hit;
	public SpriteRenderer spriteRenderer;
	public SpriteRenderer playerBody;
	public Queue<CubeColor> cubeColors = new Queue<CubeColor>();
	
	[SerializeField] private float moveSpeed = 4f;
	[SerializeField] private float jumpForce = 10f;
	[SerializeField] private float maxJumpTime = 2f;

	private Rigidbody2D rb;
	private bool isJumping = false;
	private bool isReadyJump = false;
	private float jumpTime = 0f;

	public Color playerColor = new Color(0.7f, 0.7f, 0.7f);

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.color = playerColor;
		playerBody = transform.GetChild(0).GetComponent<SpriteRenderer>();
	}

	private void Update()
	{
		//transform.rotation = Quaternion.LookRotation(moveDirectuon);
		transform.Translate(moveDirectuon * Time.deltaTime * moveSpeed);


	}
	private void FixedUpdate()
	{
		CheckGround();
	}

	//input System Move 이벤트
	public void OnMove(InputAction.CallbackContext context)
	{
		Vector2 input = context.ReadValue<Vector2>();
		moveDirectuon = new Vector2(input.x, input.y);
	}
	//input System Jump 이벤트
	public void OnJump(InputAction.CallbackContext context)
	{
		if(context.started && !isJumping && !isReadyJump)	//눌렀을 떄
		{
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

	//점프
	private void Jump()
	{
		rb.velocity = new Vector2(rb.velocity.x, jumpForce + (jumpTime * maxJumpTime));
	}
	//바닥 체크
	private void CheckGround()
	{
		hit = Physics2D.Raycast(transform.position, new Vector3(0, -1f, 0), 0.7f, LayerMask.GetMask("Ground"));

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

	//큐에 큐브 정보를 넣는다
	private void InQueueCube()
	{

	}
}
