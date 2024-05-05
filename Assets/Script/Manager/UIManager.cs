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
		#region 싱글톤
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
	}

	//오른쪽 위에 위치한 큐브 늘려주는 기능 (UIManger에서 사용)
	public void MakeCubeUI(GameObject _cube, CubeColor _cubeColor)
	{
		GameObject cube = Instantiate(_cube);
		cube.transform.SetParent(content,false);
		cube.GetComponent<Image>().color = _cubeColor.uiCubeColor;
	}
}
