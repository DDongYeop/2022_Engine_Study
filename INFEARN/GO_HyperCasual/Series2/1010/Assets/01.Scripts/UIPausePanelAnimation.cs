using UnityEngine;

public class UIPausePanelAnimation : MonoBehaviour
{
	[SerializeField]
	private	GameObject	imageBackgroundOverlay;	// 배경을 흐리게 가려주는 Image UI
	[SerializeField]
	private	Animator	animator;				// Panel 등장/퇴장 애니메이션 재생 제어

	public void OnAppear()
	{
		// 배경을 흐리게 가려주는 Image 활성화
		imageBackgroundOverlay.SetActive(true);
		// 게임 일시정지 상태일 때 출력되는 Panel 활성화
		gameObject.SetActive(true);

		// 일시정지 Panel 등장 애니메이션 재생
		animator.SetTrigger("onAppear");
	}

	public void OnDisappear()
	{
		// 일시정지 Panel 퇴장 애니메이션 재생
		animator.SetTrigger("onDisappear");
	}

	/// <summary>
	/// 일시정지 Panel 퇴장 애니메이션이 종료된 후 호출하는 이벤트 메소드
	/// </summary>
	public void EndOfDisappear()
	{
		// 배경을 흐리게 가려주는 Image 비활성화
		imageBackgroundOverlay.SetActive(false);
		// 게임 일시정지 상태일 때 출력되는 Panel 비활성화
		gameObject.SetActive(false);
	}
}

