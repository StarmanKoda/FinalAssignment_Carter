using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource Music;
    public AudioSource gunshotsound;
    public AudioSource moneygetsound;
    public AudioSource enemypacified;
    public AudioSource damage;
    public float musictiming = 0;
    public static MusicManager Instance;
    public bool gunshot = false;
    public bool moneyget = false;
    public bool enemyfine = false;
    public bool dmgsound = false;
    public int musiclength;
    // Start is called before the first frame update
    void Start()
    {
        Music.Play();
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        musictiming += Time.deltaTime;

        if (musictiming > musiclength)
        {
            Music.Play();
        }
        if (gunshot == true)
        {
            gunshotsound.Play();
            gunshot = false;
        }
        if (dmgsound == true)
        {
            damage.Play();
            dmgsound = false;
        }
        if (moneyget == true)
        {
            moneygetsound.Play();
            moneyget = false;
        }
        if (enemyfine == true)
        {
            enemypacified.Play();
            enemyfine = false;
        }
    }
}
