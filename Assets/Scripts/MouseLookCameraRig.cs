using UnityEngine;
using System.Collections;

public class MouseLookCameraRig : MonoBehaviour 
{
    public GameObject target;

	void Start () 
	{
	    if (target == null)
        {
            Debug.Log("mouselookcameraRig: null target, using self as target!");
            target = this.gameObject;
        }
	}
	
	void Update () 
	{
        updateCamera();
	}

    private static Quaternion normalize(Quaternion q)
    {
        //HACK:
        return q;
        //TODO: q * (1.0 / q.length())? 

    }

	private Quaternion qMouseX = Quaternion.identity;
	private Quaternion qMouseY = Quaternion.identity;

	void updateCamera()
	{
		#if !UNITY_EDITOR
			return;
		#endif

		float mdx = Input.GetAxis("Mouse X");//get mouse deltas! //NOTE: bad on touchpad!
		float mdy = Input.GetAxis("Mouse Y");
		
 
        Vector3 MouseXAxis = Vector3.up;//y
        Vector3 MouseYAxis = Vector3.left;//x
        Vector3 ZAxis = Vector3.forward;//z

        float scaleMouseLookInput = 4.0f;// 2.0f;// 1.0f;
        float xAmount = mdx * scaleMouseLookInput;
        float yAmount = mdy * scaleMouseLookInput;
        float zAmount = 0.0f;

        float invertYFlag = 1.0f; //don't invert for now!

        //Quaternion qLookRotX = new Quaternion(MouseXAxis.x, MouseXAxis.y, MouseXAxis.z, xAmount * 1.0f);
        Quaternion qLookRotX = Quaternion.AngleAxis(xAmount * 1.0f, MouseXAxis);
        Quaternion qLookRotY = Quaternion.AngleAxis(yAmount * invertYFlag, MouseYAxis);
        //Quaternion qLookRotY = new Quaternion(MouseYAxis.x, MouseYAxis.y, MouseYAxis.z, yAmount * 1.0f);
        Quaternion qLookRotZ = Quaternion.AngleAxis(zAmount, ZAxis);
		qMouseX = normalize(qMouseX * qLookRotX);
		qMouseY = normalize(qMouseY * qLookRotY);
		if (true)
		{
			
			//normal branch
			qMouseY = new Quaternion(Mathf.Clamp(qMouseY.x, -0.49f, +0.49f), 0, 0, Mathf.Clamp(qMouseY.w, 0.49f, +0.71f));

		}
		else
		{
			//test: no clamping!
		}

		this.transform.localRotation = normalize(qMouseX * qMouseY);
    }
}
