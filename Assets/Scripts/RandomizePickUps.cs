using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizePickUps : MonoBehaviour {
    public int PICKUPS;
    public int EVILPICKUPS;
    public GameObject reference;
    public GameObject evilReference;
    private List<Vector3> pickupsOnGround = new List<Vector3>();
    private List<Vector3> evilPickUpsOnGround = new List<Vector3>();

	void Start () {
        for (int i = 0; i < PICKUPS; i++) {
            GameObject NewPickup = Instantiate(reference);
            Vector3 randomPos = new Vector3(Random.Range(-9, 9),
                                            0.5f, Random.Range(-9, 9));
            while(!IsAGoodPosition(randomPos)) {
                randomPos = new Vector3(Random.Range(-9, 9),
                                            0.5f, Random.Range(-9, 9)); 
            }
            NewPickup.transform.position = randomPos;
            pickupsOnGround.Add(randomPos);
        }
        for (int i = 0; i < EVILPICKUPS; i++) {
            GameObject NewEvilPickup = Instantiate(evilReference);
            Vector3 randomPos = new Vector3(Random.Range(-9, 9),
                                            0.5f, Random.Range(-9, 9));
            while (!IsAGoodPosition(randomPos)) {
                randomPos = new Vector3(Random.Range(-9, 9),
                                            0.5f, Random.Range(-9, 9));
                }
            NewEvilPickup.transform.position = randomPos;
            evilPickUpsOnGround.Add(randomPos);
         }
	}

    private bool IsAGoodPosition(Vector3 newPos) {
        int i = 0;
        bool goodPosition = true;
        while(i < pickupsOnGround.Count && goodPosition) {
            goodPosition = CalculateDistance(newPos, pickupsOnGround[i]) > 1;
            i++;
        }
        i = 0;
        while(i < evilPickUpsOnGround.Count && goodPosition) {
            goodPosition = CalculateDistance(newPos, evilPickUpsOnGround[i]) > 1;
            i++;
        }
        return goodPosition && (CalculateDistance(newPos, new Vector3(0, 0.5f, 0)) > 1);
    }

    private float CalculateDistance(Vector3 v1, Vector3 v2) {
        return Mathf.Sqrt(Mathf.Pow(v1.x - v2.x, 2) + Mathf.Pow(v1.y - v2.y, 2)
                   + Mathf.Pow(v1.z - v2.z, 2));
    }
}
