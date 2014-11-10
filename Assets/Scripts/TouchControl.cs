using UnityEngine;
using System.Collections;

public class TouchControl : MonoBehaviour {

	public float comfortZone = 70.0f;
	public float minSwipeDist = 14.0f;
	public float maxSwipeTime = 0.5f;
	
	private float startTime;
	private Vector2 startPos;
	private bool couldBeSwipe;
	
	public enum SwipeDirection {
		None,
		Up,
		Down
	}
	
	public SwipeDirection lastSwipe = TouchControl.SwipeDirection.None;
	public float lastSwipeTime;
	
	void  Update(){

		if (Input.touchCount > 0){

			Touch touch = Input.touches[0];
			
			switch (touch.phase){

			case TouchPhase.Began:
				lastSwipe = TouchControl.SwipeDirection.None;
				lastSwipeTime = 0;
				couldBeSwipe = true;
				startPos = touch.position;
				startTime = Time.time;
				break;
				
			/*case TouchPhase.Moved:
				if (Mathf.Abs(touch.position.x - startPos.x) > comfortZone)
					couldBeSwipe = false;
				break;
			*/
			case TouchPhase.Ended:
				if (couldBeSwipe){

					float swipeTime = Time.time - startTime;
					float swipeDist = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
					
					if ((swipeTime < maxSwipeTime) && (swipeDist > minSwipeDist)){

						float swipeValue = Mathf.Sign(touch.position.y - startPos.y);

						if (swipeValue > 0){
							lastSwipe = TouchControl.SwipeDirection.Up;
						
							// ############# SWIPE UP #############
						
							NotificationCenter.DefaultCenter().PostNotification(this, "swipeUp");
						
						}
						else if (swipeValue < 0){
							lastSwipe = TouchControl.SwipeDirection.Down;

							// ############# SWIPE DOWN #############

							NotificationCenter.DefaultCenter().PostNotification(this, "swipeDown");

						}

						lastSwipeTime = Time.time;

					}else if(swipeDist < minSwipeDist && swipeTime < maxSwipeTime){

						// ############# JUST ONE TAP #############

						NotificationCenter.DefaultCenter().PostNotification(this, "screenTouched");

					}
				}
				break;
			}
		}
	}
}