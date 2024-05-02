using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D enemyRigid;
    public int strikeForce = 3;
    public int damage_counter = 0;
    public int enemyHp = 3;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("projectile"))
        {
            damage_counter++;
            if (damage_counter >= enemyHp)
            {
                enemyRigid.AddForce(new Vector2(2, strikeForce * 15), ForceMode2D.Impulse);

                Destroy(gameObject, 2.0f);
            }
        }
    }
}
