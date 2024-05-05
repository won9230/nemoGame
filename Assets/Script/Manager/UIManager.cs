using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public static UIManager instance;
	
	public Transform content;

	private void Awake()
	{
		#region �̱���
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
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
	}

	//������ ���� ��ġ�� ť�� �÷��ִ� ��� (UIManger���� ���)
	public void MakeCubeUI(GameObject _cube, CubeColor _cubeColor)
	{
		GameObject cube = Instantiate(_cube);
		cube.transform.SetParent(content,false);
		cube.GetComponent<Image>().color = _cubeColor.uiCubeColor;
	}
}
