using UnityEngine;
using System.Collections;

public class FlashingLight : MonoBehaviour {
	private Light light;
	private AudioSource source;
	private float[] samples = new float[64];

	void Start () {
		source = GetComponent<AudioSource>();
		light = GetComponent<Light>();
	}
	
	void Update () {
		source.GetSpectrumData(samples, 0, FFTWindow.Rectangular);
		light.intensity = samples[0] * 7 + 1;
	}
}
