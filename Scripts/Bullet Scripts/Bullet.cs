using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 15f;

    [SerializeField]
    private float damageAmount = 35f;

    [SerializeField]
    private KeyCode shootKey = KeyCode.Space;

    private Vector3 moveVector = Vector3.zero;
    private Vector3 tempScale;

    private bool isShooting = false;

    private void Update()
    {
        if (Input.GetKeyDown(shootKey) && !isShooting)
        {
            isShooting = true;
            StartCoroutine(ShootBullet());
        }

        MoveBullet();
    }

    IEnumerator ShootBullet()
    {
        GameObject bullet = Instantiate(gameObject, transform.position, Quaternion.identity);
        Bullet bulletComponent = bullet.GetComponent<Bullet>();

        bulletComponent.SetNegativeSpeed();
        bulletComponent.moveSpeed = moveSpeed;

        yield return new WaitForSeconds(0.1f); // Adjust the delay between each shot if needed

        isShooting = false;
    }

    void MoveBullet()
    {
        moveVector.x = moveSpeed * Time.deltaTime;
        transform.position += moveVector;
    }

    public void SetNegativeSpeed()
    {
        moveSpeed *= -1f;

        tempScale = transform.localScale;
        tempScale.x = -tempScale.x;
        transform.localScale = tempScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.ENEMY_TAG))
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }
}
