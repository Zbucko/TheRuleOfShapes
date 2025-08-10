using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource changeShapeFX;
    [SerializeField] AudioSource collisionFX;
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] AudioSource gameOverMusic;

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
}
