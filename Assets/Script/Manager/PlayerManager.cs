using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
	[HideInInspector] public SpriteRenderer spriteRenderer;
	[HideInInspector] public SpriteRenderer playerBody;
	public GameObject cubePrefab;
	public Queue<CubeColor> cubeColors = new Queue<CubeColor>();

	[SerializeField] private float moveSpeed = 4f;
	[SerializeField] private float jumpForce = 10f;
	[SerializeField] private float maxJumpTime = 2f;
	private float jumpTime = 0f;

	private Rigidbody2D rb;

	private bool isJumping = false;
	private bool isReadyJump = false;
	public int queueCount = 0;

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
		transform.Translate(moveDirectuon * Time.deltaTime * moveSpeed);
	}
	private void FixedUpdate()
	{
		CheckGround();
	}

	//input System (Move)
	public void OnMove(InputAction.CallbackContext context)
	{
		Vector2 input = context.ReadValue<Vector2>();
		moveDirectuon = new Vector2(input.x, input.y);
	}
	//input System (Jump) 
	public void OnJump(InputAction.CallbackContext context)
	{
		if(context.started && !isJumping && !isReadyJump)	
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
		else if (context.canceled && isJumping) 
		{
			isJumping = false;
		}
	}
	public void OnChangeColor(InputAction.CallbackContext context)
	{
		//	PlayerManager playerManager = _gameObject.GetComponent<PlayerManager>();
		if (context.started)
		{
			OutQueueCube();	
		}
	}

	//점프
	private void Jump()
	{
		rb.velocity = new Vector2(rb.velocity.x, jumpForce + (jumpTime * maxJumpTime));
	}
	//바닥체크
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

	//큐에 넣기
	public void InQueueCube(CubeColor _cubeColor)
	{
		cubeColors.Enqueue(_cubeColor);
	}

	public void OutQueueCube()
	{
		if(cubeColors.Count > 0)
		{
			CubeColor color = cubeColors.Dequeue();
			playerBody.color = color.mainColor;
			spriteRenderer.color = color.lineColor;
			UIManager.instance.DeleteCubeUI();
			queueCount--;
		}
	}
}
