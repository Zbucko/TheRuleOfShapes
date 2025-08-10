using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource changeShapeFX;
    [SerializeField] AudioSource collisionFX;
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] AudioSource gameOverMusic;
    [SerializeField] AudioSource powerLostFX;
    [SerializeField] AudioSource powerCollectFX;

    public void PlayShapeChange()
    {
        changeShapeFX.Play();
    }

    public void PlayCollision()
    {
        collisionFX.Play();
    }

    public void GameOverMusic()
    {
        backgroundMusic.Stop();
        gameOverMusic.Play();
    }

    public void PowerLost()
    {
        powerLostFX.Play();
    }

    public void PowerCollect()
    {
        powerCollectFX.Play();
    }
}
