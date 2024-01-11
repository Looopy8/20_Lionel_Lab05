using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovementScript : MonoBehaviour
{
    public float speed;
    public Rigidbody playerrigidbody;
    public float Coin;
    public TMP_Text CoinText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CoinText.text = "Coins Collected :" + Coin;
        if(Coin == 4)
        {
            SceneManager.LoadScene("GameWin");
        }
    }
    private void FixedUpdate()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(MoveHorizontal, 0, MoveVertical);
        transform.Translate(movement * Time.deltaTime * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            Coin++;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Wall")
        {
            SceneManager.LoadScene("GameLose");
        }
    }
}
