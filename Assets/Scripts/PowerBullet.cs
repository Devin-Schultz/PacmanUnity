
using UnityEngine;

public class PowerBullet : MonoBehaviour
{
    public GameState gameState;
    private void EatPowerBullet()
    {
        Destroy(gameObject);
        gameState.score += 50;
        Debug.Log(gameState.score);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        bool isCollidingWithPacman = other.gameObject.CompareTag("Pacman");
        if (isCollidingWithPacman)
        {
            Vector2 pacmanPosition = other.bounds.center;
            Vector2 pelletPosition = GetComponent<Collider2D>().bounds.center;
            bool isWithinDistance = Vector2.Distance(pacmanPosition, pelletPosition) <= 0.5f;
            if (isWithinDistance) EatPowerBullet();
        }
    }


}
