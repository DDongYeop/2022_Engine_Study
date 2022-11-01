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

    [SerializeField] private int _initBallCount = 3;

    [SerializeField] private List<PoolableMono> _poolingList;

    #region 스테이지 관련 코드
    private int _currentStage = 1;
    private Stage _currentStageObject = null;
    #endregion

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

        //이 부분은 세이브 데이터에서 불러와서 셋팅하던지, 아니면 다른 방법으로 셋팅하게 될거다. 
        _currentStage = 1;
    }

    private void Start()
    {
        LoadStage(_currentStage);
    }

    public void RestartStage()
    {
        LoadStage(_currentStage);
    }

    public void LoadNextStage()
    {
        _currentStage++;
        LoadStage(_currentStage);
    }

    public void LoadStage(int idx)
    {
        if(_currentStageObject != null)
        {
            Destroy(_currentStageObject.gameObject); //이전 스테이지 날려주고
        }

        Stage stagePrefab = Resources.Load<Stage>($"Stage{idx}");
        _currentStageObject = Instantiate(stagePrefab, Vector3.zero, Quaternion.identity);
        
        CameraManager.Instance.SetConfiner(_currentStageObject.CamBound);

        _cannonTrm.position = _currentStageObject.CannonPosition;

        _currentBoxCount = _totalBoxCount = _currentStageObject.BoxCount;
        _currentStageObject.Init(() =>
        {
            _destroyCnt++;
        });
        UIManager.Instance.SetBoxScore(_currentBoxCount, _totalBoxCount);

        _cannonController.SetGameStart(_initBallCount, () =>
        {
            float ratio = (float) (_totalBoxCount - _currentBoxCount) / _totalBoxCount;

            if(ratio > 0.9f)
            {
                UIManager.Instance.ShowResultWindow(3);
            }
            else if (ratio > 0.5f)
            {
                UIManager.Instance.ShowResultWindow(2);
            }
            else
            {
                UIManager.Instance.ShowResultWindow(1);
            }
        });

        UIManager.Instance.CloseBlackScreen();
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
        if (Input.GetKeyDown(KeyCode.U))
        {
            UIManager.Instance.ShowResultWindow(1);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UIManager.Instance.CloseResultWindow();
        }
    }
}
