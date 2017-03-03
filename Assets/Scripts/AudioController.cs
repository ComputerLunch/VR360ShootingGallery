using UnityEngine;
using System.Collections.Generic;

public class AudioController : MonoBehaviour
{
	private static AudioController singleton;

	public static AudioController getSingleton()
	{
		if (singleton == null)
		{
			singleton = new AudioController();
		}
			
		return singleton;
	}
		
	void Start () 
	{
		singleton = this;
	}

	void OnDestroy()
	{
		if (singleton == this)
		{
			singleton = null;
		}
	}
		
	public void PlaySFX( string url , float volume = 1.0f)
	{
		AudioClip ac  = Resources.Load(url) as AudioClip;

		if(ac == null){

			Debug.Log("MISSING Sound effect url");
			return;
		}

		GameObject sfx = new GameObject(); // create the temp object
		sfx.transform.position = Vector3.zero; // set its position
		AudioSource aSource = sfx.AddComponent<AudioSource>(); // add an audio source
		aSource.clip = ac; // define the clip
		aSource.volume = volume;
		aSource.spatialBlend = 0.0f;
		aSource.Play(); // start the sound
		DontDestroyOnLoad(sfx);
		Destroy(sfx, ac.length + 0.5f); // destroy object after clip duration
	}

	public void PlaySFX3D( string url ,  Transform trans, float volume = 1.0f)
	{
		AudioClip ac  = Resources.Load(url) as AudioClip;

		if(ac == null){

			Debug.Log("MISSING Sound effect url");
			return;
		}

		GameObject sfx = new GameObject(); // create the temp object
		sfx.transform.position = trans.position;
		AudioSource aSource = sfx.AddComponent<AudioSource>(); // add an audio source
		aSource.clip = ac; // define the clip
		aSource.volume = volume;
		aSource.spatialBlend = 1.0f;
		aSource.Play(); // start the sound
		DontDestroyOnLoad(sfx);
		Destroy(sfx, ac.length + 0.5f); // destroy object after clip duration
	}


	GameObject bg;

	public void PlayBG( string url , float volume = 1.0f, bool loop = true)
	{
		AudioClip ac  = Resources.Load(url) as AudioClip;

		if(ac == null){

			Debug.Log("MISSING Sound effect url");
			return;
		}

		if(bg){

			Destroy(bg);
		}

		bg = new GameObject(); // create the temp object
		bg.transform.position = Vector3.zero; // set its position
		AudioSource aSource = bg.AddComponent<AudioSource>(); // add an audio source
		aSource.clip = ac; // define the clip
		aSource.loop = loop;
		aSource.volume = volume;
		aSource.Play(); // start the sound
		//DontDestroyOnLoad(bg);

		//Destroy(sfx, ac.length + 0.5f); // destroy object after clip duration
	}

	public void StopBG(){

		//if(bg){

			Destroy(bg);
		//}
	}

}