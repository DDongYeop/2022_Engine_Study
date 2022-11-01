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

    #region �ڽ� ���ھ� ���� �ڵ� 
    private int _totalBoxCount = 0, _currentBoxCount = 0;
    private int _destroyCnt = 0;
    #endregion

    [SerializeField] private int _initBallCount = 3;

    [SerializeField] private List<PoolableMono> _poolingList;

    #region �������� ���� �ڵ�
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

        PoolManager.Instance = new PoolManager(transform); // ���ӸŴ����� Ǯ�� �θ�� �ؼ� Ǯ�Ŵ��� �̱��� ����
        foreach(PoolableMono p in _poolingList)
        {
            PoolManager.Instance.CreatePool(p, 40);
        }

        //�� �κ��� ���̺� �����Ϳ��� �ҷ��ͼ� �����ϴ���, �ƴϸ� �ٸ� ������� �����ϰ� �ɰŴ�. 
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
            Destroy(_currentStageObject.gameObject); //���� �������� �����ְ�
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

        //�׽�Ʈ �ڵ�
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
