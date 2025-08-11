using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Variables of audio sources
    [SerializeField] AudioSource changeShapeFX;
    [SerializeField] AudioSource collisionFX;
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] AudioSource gameOverMusic;
    [SerializeField] AudioSource powerLostFX;
    [SerializeField] AudioSource powerCollectFX;

    //Played when shape change occurs.
    public void PlayShapeChange()
    {
        changeShapeFX.Play();
    }

    //Played when collision occurs.
    public void PlayCollision()
    {
        collisionFX.Play();
    }

    //Played when its game over.
    public void GameOverMusic()
    {
        backgroundMusic.Stop();
        gameOverMusic.Play();
    }

    //Played when powerup timer runs out.
    public void PowerLost()
    {
        powerLostFX.Play();
    }

    //Played when collecting powerup.
    public void PowerCollect()
    {
        powerCollectFX.Play();
    }
}
