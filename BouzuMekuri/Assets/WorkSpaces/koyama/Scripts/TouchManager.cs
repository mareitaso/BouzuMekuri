#if UNITY_EDITOR
#define IS_EDITOR
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    /// <summary>
    /// シングルトン
    /// </summary>
    private static TouchManager _instance;
    private static TouchManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var obj = new GameObject(typeof(TouchManager).Name);
                _instance = obj.AddComponent<TouchManager>();
            }
            return _instance;
        }
    }

    /// <summary>
    /// タッチ開始時のイベント
    /// </summary>
    public static event System.Action<TouchInfo> Started
    {
        add
        {
            Instance._started += value;
        }
        remove
        {
            Instance._started -= value;
        }
    }

    /// <summary>
    /// タッチ中のイベント
    /// </summary>
    public static event System.Action<TouchInfo> Moved
    {
        add
        {
            Instance._moved += value;
        }
        remove
        {
            Instance._moved -= value;
        }
    }

    /// <summary>
    /// タッチ終了時のイベント
    /// </summary>
    public static event System.Action<TouchInfo> Ended
    {
        add
        {
            Instance._ended += value;
        }
        remove
        {
            Instance._ended -= value;
        }
    }

    private TouchInfo _info = new TouchInfo();
    private event System.Action<TouchInfo> _started;
    private event System.Action<TouchInfo> _moved;
    private event System.Action<TouchInfo> _ended;

    /// <summary>
    /// 現在のタッチ状態
    /// </summary>
    private TouchState State
    {
        get
        {
#if IS_EDITOR
            // エディタの場合の処理
            if (Input.GetMouseButtonDown(0)){
                return TouchState.Started;
            }
            else if (Input.GetMouseButton(0)){
                return TouchState.Moved;
            }
            else if (Input.GetMouseButtonUp(0)){
                return TouchState.Ended;
            }
#else
            // エディタ以外の場合
            if (Input.touchCount > 0)
            {
                switch (Input.GetTouch(0).phase)
                {
                    case TouchPhase.Began:
                        return TouchState.Started;
                    case TouchPhase.Moved:
                    case TouchPhase.Stationary:
                        return TouchState.Moved;
                    case TouchPhase.Canceled:
                    case TouchPhase.Ended:
                        return TouchState.Ended;
                    default:
                        break;
                }
            }
#endif
            return TouchState.None;
        }
    }

    /// <summary>
    /// タッチされている位置
    /// </summary>
    private Vector2 Position
    {
        get
        {
#if IS_EDITOR
            return State == TouchState.None ? Vector2.zero : (Vector2)Input.mousePosition;
#else
            return Input.GetTouch(0).position;
#endif
        }
    }

    private void Update()
    {
        if (State == TouchState.Started)
        {
            _info.screenPoint = Position;
            _info.deltaScreenPoint = Vector2.zero;
            if (_started != null)
            {
                _started(_info);
            }
        }
        else if (State == TouchState.Moved)
        {
            _info.deltaScreenPoint = Position - _info.screenPoint;
            _info.screenPoint = Position;
            if (_moved != null)
            {
                _moved(_info);
            }
        }
        else if (State == TouchState.Ended)
        {
            _info.deltaScreenPoint = Position - _info.screenPoint;
            _info.screenPoint = Position;
            if (_ended != null)
            {
                _ended(_info);
            }
        }
        else
        {
            _info.deltaScreenPoint = Vector2.zero;
            _info.screenPoint = Vector2.zero;
        }
    }
}

/// <summary>
/// タッチ情報
/// </summary>
public class TouchInfo
{
    /// <summary>
    /// タッチされたスクリーン座標
    /// </summary>
    public Vector2 screenPoint;
    /// <summary>
    /// 1フレーム前にタッチされたスクリーン座標との差分
    /// </summary>
    public Vector2 deltaScreenPoint;
    /// <summary>
    /// タッチされたビューポート座標
    /// </summary>
    public Vector2 ViewportPoint
    {
        get
        {
            _viewportPoint.x = screenPoint.x / Screen.width;
            _viewportPoint.y = screenPoint.y / Screen.height;
            return _viewportPoint;
        }
    }
    /// <summary>
    /// 1フレーム前にタッチされたビューポート座標との差分
    /// </summary>
    public Vector2 DeltaViewportPoint
    {
        get
        {
            _deltaViewportPoint.x = deltaScreenPoint.x / Screen.width;
            _deltaViewportPoint.y = deltaScreenPoint.y / Screen.height;
            return _deltaViewportPoint;
        }
    }

    private Vector2 _viewportPoint = Vector2.zero;
    private Vector2 _deltaViewportPoint = Vector2.zero;
}

/// <summary>
/// タッチ状態
/// </summary>
public enum TouchState
{
    /// <summary>
    /// タッチなし
    /// </summary>
    None = 0,
    /// <summary>
    /// タッチ開始
    /// </summary>
    Started = 1,
    /// <summary>
    /// タッチ中
    /// </summary>
    Moved = 2,
    /// <summary>
    /// タッチ終了
    /// </summary>
    Ended = 3,
}
/*
public bool touch_flag;//タッチの有無
public Vector2 touch_position;//タッチ座標
public TouchPhase touch_phase;//タッチ状態

/// <summary>
/// コンストラクタ
/// </summary>
/// <param name="flag">タッチ有無</param>
/// <param name="position">タッチ座標(引数省略できるようにnullも許容)</param>
/// <param name="phase">タッチ状態</param>
public TouchManager(bool flag =false,Vector2? position = null,TouchPhase phase = TouchPhase.Began)
{
    this.touch_flag = flag;
    if(position == null)
    {
        this.touch_position = new Vector2(0, 0);
    }
    else
    {
        this.touch_position = (Vector2)position;
    }
    this.touch_phase = phase;
}

public void Update()
{
    if (Input.touchCount > 0)
    {
        Touch touch = Input.GetTouch(0);
        this.touch_position = touch.position;
        this.touch_phase = touch.phase;
        this.touch_flag = true;
    }
}
/// <summary>
/// タッチ状態取得
/// </summary>
/// <returns></returns>
public TouchManager GetTouch()
{
    return new TouchManager(this.touch_flag, this.touch_position, this.touch_phase);
}

}*/
