using UnityEngine;

public class SingleCubeVisualizer : MonoBehaviour
{
  [SerializeField] private int band;
  [SerializeField] private float scaleMultiplier;
  private float currVelocity;
  private void Update()
  {
    transform.localScale = new Vector3(1f,  Mathf.SmoothDamp(transform.localScale.y, (AudioParse.freqBand[band]*scaleMultiplier),ref currVelocity ,0.05f), 1f);
  }
}