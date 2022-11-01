using UnityEngine;

public class TouchController : MonoBehaviour
{
	[SerializeField] private float dragDistance = 25;
	private	Vector3	_touchStart, _touchEnd;
	private	bool _isTouch = false;

	public Direction UpdateTouch()
	{
		Direction direction = Direction.None;

		if ( Input.GetMouseButtonDown(0) )
		{
			_isTouch = true;
			_touchStart = Input.mousePosition;
		}
		else if ( Input.GetMouseButton(0) )
		{
			if ( _isTouch == false ) 
				return Direction.None;

			_touchEnd = Input.mousePosition;

			float deltaX = _touchEnd.x - _touchStart.x;
			float deltaY = _touchEnd.y - _touchStart.y;

			if ( Mathf.Abs(deltaX) < dragDistance && Mathf.Abs(deltaY) < dragDistance ) 
				return Direction.None;

			if ( Mathf.Abs(deltaX) > Mathf.Abs(deltaY) )
			{
				if ( Mathf.Sign(deltaX) >= 0 )
					direction = Direction.Right;
				else
					direction = Direction.Left;
			}
			else
			{
				if ( Mathf.Sign(deltaY) >= 0 )
					direction = Direction.Up;
				else
					direction = Direction.Down;
			}
		}

		if ( direction != Direction.None ) 
			_isTouch = false;

		return direction;
	}
}

