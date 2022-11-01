using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사용자가 마우스를 클릭한 지점에 복셀을 1개 만들고 싶다
// 필요 속성: 복셀 공장
public class VoxelMaker : MonoBehaviour
{
    public GameObject voxelFactory; // 복셀 공장
    public int voxelPoolSize = 20; // 오프젝트 풀의 크기
    public static List<GameObject> voxelPool = new List<GameObject>();
    public float createTime = 0.1f; // 생성 시간
    float currentTime = 0; // 경과 시간

    private void Start()
    {
        for (int i = 0; i < voxelPoolSize; i++) // 오브젝트 풀에 비활성화된 복셀을 담고 싶다
        {
            GameObject voxel = Instantiate(voxelFactory); // 1. 복셀 공장에서 복셀 생성하기
            voxel.SetActive(false); // 2. 복셀 비활성화 하기
            voxelPool.Add(voxel); // 3. 복셀을 오브젝트 풀에 담고 싶다
        }
    }

    private void Update()
    {
        // 일정 시간마다 복셀을 만들고 싶다
        currentTime += Time.deltaTime; // 1. 경과시간이 흐른다

        if (currentTime > createTime) // 2. 경과시간이 생성 시간을 초과하면
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 2. 마우스가 바닥 위에 위치해있다몀
            RaycastHit hitInfo = new RaycastHit();

            if (Physics.Raycast(ray, out hitInfo))// 2. 마우스의 위치가 바닥 위에 위치해 있다면 
            {
                // 복셀 오브젝트 풀 이용하기
                if (voxelPool.Count > 0) // 1. 만약 오브젝트 풀에 복셀이 있다면
                {
                    currentTime = 0; // 복셀을 생성했을 때만 경과 시간을 초가화한다
                    GameObject voxel = voxelPool[0]; // 2. 오브젝트 풀에서 복셀을 하나 가져온다
                    voxel.SetActive(true); // 3. 복셀을 활성화한다
                    voxel.transform.position = hitInfo.point; // 4. 복셀을 배치하고 싶다
                    voxelPool.RemoveAt(0); // 5. 오브젝트 풀에서 복셀을 제거한다
                }
            }
        }
    }
}
