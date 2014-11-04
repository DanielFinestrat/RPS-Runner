using UnityEngine;
using System.Collections;

public class HorizontalSwipe : MonoBehaviour {
	
	// Values to set:
	public float comfortZone = 70.0f;
	public float minSwipeDist = 14.0f;
	public float maxSwipeTime = 0.5f;
	
	private float startTime;
	private Vector2 startPos;
	private bool couldBeSwipe;
	
	public enum SwipeDirection {
		None,
		Right,
		Left
	}
	
	public SwipeDirection lastSwipe = HorizontalSwipe.SwipeDirection.None;
	public float lastSwipeTime;
	
	void  Update(){
		
		if (Input.touchCount > 0){
			
			Touch touch = Input.touches[0];
			
			switch (touch.phase){
				
			case TouchPhase.Began:
				lastSwipe = HorizontalSwipe.SwipeDirection.None;
				lastSwipeTime = 0;
				couldBeSwipe = true;
				startPos = touch.position;
				startTime = Time.time;
				break;
				
			case TouchPhase.Moved:
				if (Mathf.Abs(touch.position.y - startPos.y) > comfortZone)
					couldBeSwipe = false;
				break;
				
			case TouchPhase.Ended:
				if (couldBeSwipe){
					
					float swipeTime = Time.time - startTime;
					float swipeDist = (new Vector3(0, touch.position.x, 0) - new Vector3(0, startPos.x, 0)).magnitude;
					
					if ((swipeTime < maxSwipeTime) && (swipeDist > minSwipeDist)){
						
						float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
						
						if (swipeValue > 0){
							// ############# RightSwipe #############
							lastSwipe = HorizontalSwipe.SwipeDirection.Right;
							NotificationCenter.DefaultCenter().PostNotification(this, "swipeRight");
						}

						else if (swipeValue < 0)
							lastSwipe = HorizontalSwipe.SwipeDirection.Left;

						
						lastSwipeTime = Time.time;
						
					}
				}
				break;
			}
		}
	}
}