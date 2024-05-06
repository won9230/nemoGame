using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public static UIManager instance;
	
	public Transform content;

	public GameObject cubePrefab;
	public List<GameObject> cubes = new List<GameObject>();

	[SerializeField] int cubeCount = 10;	//ó�� �����Ǵ� ť�� ����

	private void Awake()
	{
		#region �̱���
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			if (instance != null)
			{
				Destroy(gameObject);
				Debug.Log($"�̱��� �������� ���Ͽ�{gameObject.name}�� ���� �Ǿ����ϴ�.");
			}
		}
		#endregion
	}

	private void Start()
	{
		content = GameObject.Find("Canvas").transform.Find("Scroll View").transform.Find("Viewport").transform.Find("Content");
		if (content == null)
			Debug.Log("canvas�� �����ϴ�.");
		StartMakeCubeUI();
	}

	private void StartMakeCubeUI()
	{
		for (int i = 0; i < cubeCount; i++)
		{
			GameObject cube = Instantiate(cubePrefab);
			cube.transform.SetParent(content, false);
			cubes.Add(cube);
			cube.SetActive(false);
		}
	}

	//������ ���� ��ġ�� ť�� �÷��ִ� ��� (Pilar.cs���� ���)
	public void MakeCubeUI(CubeColor _cubeColor, int _cubeSize)
	{
		cubes[_cubeSize].gameObject.SetActive(true);
		cubes[_cubeSize].GetComponent<Image>().color = _cubeColor.uiCubeColor;
	}

	//������ ���� ��ġ�� ť�� �ٿ��ִ� ��� (PlayerManager.cs���� ���)
	public void DeleteCubeUI()
	{
		cubes[0].gameObject.SetActive(false);
		GameObject tmpCube = cubes[0];
		cubes.RemoveAt(0);
		cubes.Add(tmpCube);
	}
}
