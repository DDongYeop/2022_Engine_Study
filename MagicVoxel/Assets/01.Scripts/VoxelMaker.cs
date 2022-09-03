using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����ڰ� ���콺�� Ŭ���� ������ ������ 1�� ����� �ʹ�
// �ʿ� �Ӽ�: ���� ����
public class VoxelMaker : MonoBehaviour
{
    public GameObject voxelFactory; // ���� ����
    public int voxelPoolSize = 20; // ������Ʈ Ǯ�� ũ��
    public static List<GameObject> voxelPool = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < voxelPoolSize; i++) // ������Ʈ Ǯ�� ��Ȱ��ȭ�� ������ ��� �ʹ�
        {
            GameObject voxel = Instantiate(voxelFactory); // 1. ���� ���忡�� ���� �����ϱ�
            voxel.SetActive(false); // 2. ���� ��Ȱ��ȭ �ϱ�
            voxelPool.Add(voxel); // 3. ������ ������Ʈ Ǯ�� ��� �ʹ�
        }
    }

    private void Update()
    {
        // ����ڰ� ���콺�� Ŭ���� ������ ������ 1�� ����� �ʹ�
        if (Input.GetButtonDown("Fire1")) // 1. ����ڰ� ���콺�� Ŭ���ߴٸ� 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 2. ���콺�� �ٴ� ���� ��ġ���ִّm
            RaycastHit hitInfo = new RaycastHit();

            if (Physics.Raycast(ray, out hitInfo))// 2. ���콺�� ��ġ�� �ٴ� ���� ��ġ�� �ִٸ� 
            {
                // ���� ������Ʈ Ǯ �̿��ϱ�
                if (voxelPool.Count > 0) // 1. ���� ������Ʈ Ǯ�� ������ �ִٸ�
                {
                    GameObject voxel = voxelPool[0]; // 2. ������Ʈ Ǯ���� ������ �ϳ� �����´�
                    voxel.SetActive(true); // 3. ������ Ȱ��ȭ�Ѵ�
                    voxel.transform.position = hitInfo.point; // 4. ������ ��ġ�ϰ� �ʹ�
                    voxelPool.RemoveAt(0); // 5. ������Ʈ Ǯ���� ������ �����Ѵ�
                }
            }
        }
    }
}
