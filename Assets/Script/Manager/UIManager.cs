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

	[SerializeField] int cubeCount = 10;	//처음 생성되는 큐브 개수

	private void Awake()
	{
		#region 싱글톤
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			if (instance != null)
			{
				Destroy(gameObject);
				Debug.Log($"싱그톤 패턴으로 인하여{gameObject.name}가 삭제 되었습니다.");
			}
		}
		#endregion
	}

	private void Start()
	{
		content = GameObject.Find("Canvas").transform.Find("Scroll View").transform.Find("Viewport").transform.Find("Content");
		if (content == null)
			Debug.Log("canvas가 없습니다.");
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

	//오른쪽 위에 위치한 큐브 늘려주는 기능 (Pilar.cs에서 사용)
	public void MakeCubeUI(CubeColor _cubeColor, int _cubeSize)
	{
		cubes[_cubeSize].gameObject.SetActive(true);
		cubes[_cubeSize].GetComponent<Image>().color = _cubeColor.uiCubeColor;
	}

	//오른쪽 위에 위치한 큐브 줄여주는 기능 (PlayerManager.cs에서 사용)
	public void DeleteCubeUI()
	{
		cubes[0].gameObject.SetActive(false);
		GameObject tmpCube = cubes[0];
		cubes.RemoveAt(0);
		cubes.Add(tmpCube);
	}
}
