using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. 복셀은 랜덤한 방향으로 날아가는 운동을 했다
// 필요 속성: 날아갈 속도
// 2. 일정 시간이 지나면 복셀을 제거하고 싶다
// 필요 속성: 복셀을 제거할 시간. 경과 시간
public class Voxel : MonoBehaviour
{
    public float speed = 5; // 1. 복셀이 날아갈 속도 조정
    public float destoryTime = 3.0f; // 복셀을 제거할 시간
    float currentTime; // 경과시간

    private void OnEnable()
    {
        currentTime = 0;
        Vector3 direction = Random.insideUnitSphere; // 2. 랜덤한 방향을 찾는다
        Rigidbody rb = gameObject.GetComponent<Rigidbody>(); // 3. 랜덤한 방향으로 날아가는 속도를 준다
        rb.velocity = direction * speed;
    }


    private void Update()
    {
        // 일정 시간이 지나면 복셀을 제거하고 싶다
        currentTime += Time.deltaTime; // 1. 시간이 흘러야 한다
        // 제거시간 됐으니까
        if (currentTime > destoryTime) // 만약 경과시간이 제거 시간을 초과했다면
        {
            gameObject.SetActive(false); // 3. 복셀을 비활성화 시킨다
            VoxelMaker.voxelPool.Add(gameObject); // 오브젝트 풀에 다시 넣어준다
        }
    }
}
