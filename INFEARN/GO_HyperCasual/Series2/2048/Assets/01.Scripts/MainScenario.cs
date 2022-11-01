using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainScenario : MonoBehaviour
{
	[SerializeField] private Image imageMatrix;
	[SerializeField] private TextMeshProUGUI textMatrix;
	[SerializeField] private Sprite[] spritesMatrix;

	private	int _matrixIndex = 0;

	public void OnClickGameStart()
	{
		PlayerPrefs.SetInt("BlockCount", _matrixIndex+3);
		SceneManager.LoadScene("02Game");
	}

	public void OnClickGameExit()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.ExitPlaymode();
		#else
		Application.Quit();
		#endif
	}

	public void OnClickLeft()
	{
		_matrixIndex = _matrixIndex > 0 ? _matrixIndex-1 : spritesMatrix.Length-1;

		imageMatrix.sprite = spritesMatrix[_matrixIndex];
		textMatrix.text = spritesMatrix[_matrixIndex].name;
	}

	public void OnClickRight()
	{
		_matrixIndex = _matrixIndex < spritesMatrix.Length-1 ? _matrixIndex+1 : 0;

		imageMatrix.sprite = spritesMatrix[_matrixIndex];
		textMatrix.text = spritesMatrix[_matrixIndex].name;
	}
}

