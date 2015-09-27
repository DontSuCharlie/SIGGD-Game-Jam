using UnityEngine;
using System.Collections;

public class FlashingLight : MonoBehaviour {
	private Light vLight;
	private AudioSource source;
	private float[] samples = new float[64];

	void Start () {
		source = GetComponent<AudioSource>();
		vLight = GetComponent<Light>();
	}
	
	void Update () {
		source.GetSpectrumData(samples, 0, FFTWindow.Rectangular);
		vLight.intensity = samples[0] * 7 + 1;
	}
}
