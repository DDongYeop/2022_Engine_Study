using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Transform _cannonTrm;


    public Transform CannonTrm
    {
        get { return _cannonTrm; }
    }

    private CanonController _cannonController;

    #region 박스 스코어 관련 코드 
    private int _totalBoxCount = 0, _currentBoxCount = 0;
    private int _destroyCnt = 0;
    #endregion

    [SerializeField] private List<PoolableMono> _poolingList;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Multiple GameManager instance is running");
        }
        Instance = this;

        UIManager.Instance = new UIManager();

        _cannonController = _cannonTrm.GetComponent<CanonController>();

        GameObject timeController = new GameObject("TimeController");
        timeController.transform.parent = transform;
        TimeController.Instance = timeController.AddComponent<TimeController>();

        GameObject cameraManager = new GameObject("CameraManager");
        cameraManager.transform.parent = transform;
        CameraManager.Instance = cameraManager.AddComponent<CameraManager>();
        CameraManager.Instance.Init();

        PoolManager.Instance = new PoolManager(transform); // 게임매니저를 풀링 부모로 해서 풀매니저 싱글톤 생성
        foreach(PoolableMono p in _poolingList)
        {
            PoolManager.Instance.CreatePool(p, 40);
        }

        LoadStage(1);
    }

    public void LoadStage(int idx)
    {
        Stage stagePrefab = Resources.Load<Stage>($"Stage{idx}");
        Stage stage = Instantiate(stagePrefab, Vector3.zero, Quaternion.identity);
        
        CameraManager.Instance.SetConfiner(stage.CamBound);

        _cannonTrm.position = stage.CannonPosition;

        _currentBoxCount = _totalBoxCount = stage.BoxCount;
        stage.Init(() =>
        {
            _destroyCnt++;
        });
        UIManager.Instance.SetBoxScore(_currentBoxCount, _totalBoxCount);

        _cannonController.SetGameStart(3, () =>
        {
            Debug.Log("게임 클리어");
            UIManager.Instance.ShowResultWindow(3);
        });
    }

    private bool _isAnimated = false;

    private void Update()
    {
        if (_isAnimated == false && _destroyCnt > 0)
        {
            _currentBoxCount--;
            _isAnimated = true;
            _destroyCnt--;
            UIManager.Instance.SetBoxScore(_currentBoxCount, _totalBoxCount, () => 
            { 
                _isAnimated = false;
            });
        }

        //테스트 코드
        if(Input.GetKeyDown(KeyCode.T))
        {
            UIManager.Instance.ShowResultWindow(3);
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            UIManager.Instance.CloseResultWindow();
        }
    }
}
