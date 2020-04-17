using UnityEngine;
using System.Collections;


public class GameManager : MonoBehaviour
{
    [Header("火光")]
    public GameObject Firelight;
    [Header("滾起來")]
    public Transform barrel;
    [Header("書")]
    public Transform book;
    [Header("喇叭")]
    public AudioSource aud;
    [Header("滾桶子")]
    public AudioClip soundBarrelroll;
    [Header("木板聲音")]
    public AudioClip Wooddoor;
    [Header("木板倒下")]
    public AudioClip doordown;
    [Header("門的動畫控制器")]
    public Animator aniDoor;

    private int countDoor;

    public int countBarrel;

    public void LookDoor()
    {
        countDoor++;

        if (countDoor == 1)
        {
            aud.PlayOneShot(Wooddoor, 0.3f);
        }
        else if (countDoor == 2)
        {
            aud.PlayOneShot(doordown, 0.5f);
            aniDoor.SetTrigger("倒下觸發器");
        }
    }

    public IEnumerator LightEffect()
    {
        Firelight.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        Firelight.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Firelight.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        Firelight.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Firelight.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        Firelight.SetActive(true);
    }
    public void StartMovebarrel()
    {
        StartCoroutine(Movebarrel());
    }
    public IEnumerator Movebarrel()
    {
        
        countBarrel++;

        if (countBarrel == 2)
        {
            barrel.GetComponent<MeshCollider>().enabled = false;

            aud.PlayOneShot(soundBarrelroll, 2f);


            for (int i = 0; i < 20; i++)
            {

                barrel.position -= barrel.forward * 0.08f;
                yield return new WaitForSeconds(0.3f);

            }
            

        }
    }
    }
   

