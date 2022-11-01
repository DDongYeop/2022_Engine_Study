using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. ������ ������ �������� ���ư��� ��� �ߴ�
// �ʿ� �Ӽ�: ���ư� �ӵ�
// 2. ���� �ð��� ������ ������ �����ϰ� �ʹ�
// �ʿ� �Ӽ�: ������ ������ �ð�. ��� �ð�
public class Voxel : MonoBehaviour
{
    public float speed = 5; // 1. ������ ���ư� �ӵ� ����
    public float destoryTime = 3.0f; // ������ ������ �ð�
    float currentTime; // ����ð�

    private void OnEnable()
    {
        currentTime = 0;
        Vector3 direction = Random.insideUnitSphere; // 2. ������ ������ ã�´�
        Rigidbody rb = gameObject.GetComponent<Rigidbody>(); // 3. ������ �������� ���ư��� �ӵ��� �ش�
        rb.velocity = direction * speed;
    }


    private void Update()
    {
        // ���� �ð��� ������ ������ �����ϰ� �ʹ�
        currentTime += Time.deltaTime; // 1. �ð��� �귯�� �Ѵ�
        // ���Žð� �����ϱ�
        if (currentTime > destoryTime) // ���� ����ð��� ���� �ð��� �ʰ��ߴٸ�
        {
            gameObject.SetActive(false); // 3. ������ ��Ȱ��ȭ ��Ų��
            VoxelMaker.voxelPool.Add(gameObject); // ������Ʈ Ǯ�� �ٽ� �־��ش�
        }
    }
}
