using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    public Transform mainCam;
    public Transform firePosition;
    public GameObject bullet;
    public Text startText;
    public int HP;
    public int score;
    public AudioClip fireSound;
    private AudioSource audioSource;
    private bool shoot = true;

    private void Start()
    {
        HP = 50;
        score = 0;
        UpdatetState();
        audioSource = this.GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        firePosition.rotation = mainCam.rotation;

        if (Input.GetMouseButtonDown(0) && shoot)
        {
            StartCoroutine(Fire());
        }

        if (HP <= 0)
        {
            StartCoroutine(ReStart());
        }
    }

    public void UpdatetState()
    {
        startText.text = " Score\n" + score + "\n" + " HP\n" + HP;
    }

    IEnumerator Fire()
    {
        shoot = false;
        Instantiate(bullet, firePosition.position, firePosition.rotation);
        audioSource.PlayOneShot(fireSound);
        yield return new WaitForSeconds(0.2f);
        shoot = true;
    }

    IEnumerator ReStart()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
