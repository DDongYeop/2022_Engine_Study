using UnityEngine;

public class UIPausePanelAnimation : MonoBehaviour
{
	[SerializeField]
	private	GameObject	imageBackgroundOverlay;	// ����� �帮�� �����ִ� Image UI
	[SerializeField]
	private	Animator	animator;				// Panel ����/���� �ִϸ��̼� ��� ����

	public void OnAppear()
	{
		// ����� �帮�� �����ִ� Image Ȱ��ȭ
		imageBackgroundOverlay.SetActive(true);
		// ���� �Ͻ����� ������ �� ��µǴ� Panel Ȱ��ȭ
		gameObject.SetActive(true);

		// �Ͻ����� Panel ���� �ִϸ��̼� ���
		animator.SetTrigger("onAppear");
	}

	public void OnDisappear()
	{
		// �Ͻ����� Panel ���� �ִϸ��̼� ���
		animator.SetTrigger("onDisappear");
	}

	/// <summary>
	/// �Ͻ����� Panel ���� �ִϸ��̼��� ����� �� ȣ���ϴ� �̺�Ʈ �޼ҵ�
	/// </summary>
	public void EndOfDisappear()
	{
		// ����� �帮�� �����ִ� Image ��Ȱ��ȭ
		imageBackgroundOverlay.SetActive(false);
		// ���� �Ͻ����� ������ �� ��µǴ� Panel ��Ȱ��ȭ
		gameObject.SetActive(false);
	}
}

