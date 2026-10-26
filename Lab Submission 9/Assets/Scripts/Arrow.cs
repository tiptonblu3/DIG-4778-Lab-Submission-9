using System;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    //this is used to send a event out for the score script to update
    public static event Action<int> OnScoreUpdated;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 8f);

        if (transform.position.y > 11f)
        {
            gameObject.SetActive(false);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Enemy"))
        {

            ScoreUpdater();
            Debug.Log("it is detecting");

            Destroy(other.gameObject);
            gameObject.SetActive(false);

        }
    }

    private void ScoreUpdater()
    {
        int newScore;
        int score = UnityEngine.Random.Range(50, 100);
        newScore = score; 


        OnScoreUpdated?.Invoke(newScore);//this sends out the variable to anything that is listening
    }
}
