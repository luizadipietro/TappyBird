using UnityEngine;
using System.Collections;

public class GroundController : MonoBehaviour {
	public  GameObject[] downwardRocks;
	public  GameObject[] upwardRocks;
	public  GameObject   ground1;
	public  GameObject   ground2;
	public  float        backgroundBorder;
	public  float        minTopY;
	public  float        maxTopY;
	public  float        minBottomY;
	public  float        maxBottomY;
	public  float        groundSpeed;
	public  float        rockSpeed;
	private float        initialXPosition;

	public void Start() {
		initialXPosition = ground2.transform.position.x;
	}
	
	public void Update() {
		ground1.transform.Translate(-groundSpeed * Time.deltaTime, 0, 0);
		if (ground1.transform.position.x < 0) {
			ground1.transform.position = new Vector3(initialXPosition, ground1.transform.position.y, 0);
		}

		ground2.transform.Translate(-groundSpeed * Time.deltaTime, 0, 0);
		if (ground2.transform.position.x < 0) {
			ground2.transform.position = new Vector3(initialXPosition, ground2.transform.position.y, 0);
		}

		for (int i = 0; i < downwardRocks.Length; i++) {
			downwardRocks[i].transform.Translate(-rockSpeed * Time.deltaTime, 0, 0);
			//if (!downwardRocks[i].GetComponent<Renderer>().isVisible && downwardRocks[i].transform.position.x < 0)
			if (downwardRocks[i].transform.position.x + downwardRocks[i].transform.localScale.x < 0)
				ResetDownRock(downwardRocks[i].transform);
		}

		for (int i = 0; i < upwardRocks.Length; i++) {
			upwardRocks[i].transform.Translate(-rockSpeed * Time.deltaTime, 0, 0);
			//if (!upwardRocks[i].GetComponent<Renderer>().isVisible && upwardRocks[i].transform.position.x < 0)
			if (upwardRocks[i].transform.position.x + upwardRocks[i].transform.localScale.x < 0)
				ResetUpRock(upwardRocks[i].transform);
		}
	}

	private void ResetDownRock(Transform t) {
		float x = UnityEngine.Random.Range(backgroundBorder, initialXPosition);
		float y = UnityEngine.Random.Range(minTopY, maxTopY);

		t.position = new Vector3(x, y, 0);
	}

	private void ResetUpRock(Transform t) {
		float x = UnityEngine.Random.Range(backgroundBorder, initialXPosition);
		float y = UnityEngine.Random.Range(minBottomY, maxBottomY);

		t.position = new Vector3(x, y, 0);
	}
}
