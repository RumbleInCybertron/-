using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] int enemyLayer = 10;
    [SerializeField] float maxHealthPoints = 100f;
    [SerializeField] float attackDamagePerHit = 10f;
    [SerializeField] float minTimeBetweenHits = .5f;
    [SerializeField] float maxAttackRange = 2f;

    GameObject currentTarget;
    CameraRaycaster cameraRaycaster;

    float currentHealthPoints;
    float lastHitTime = 0f;

    public float healthAsPercentage { get { return currentHealthPoints / maxHealthPoints; }}

    void Start()
    {
        cameraRaycaster = FindObjectOfType<CameraRaycaster>();
        cameraRaycaster.notifyMouseClickObservers += OnMouseClick;   // registering
        currentHealthPoints = maxHealthPoints;
    }

    void OnMouseClick(RaycastHit raycastHit, int layerHit)
    {
        if(layerHit == enemyLayer)
        {
            var enemy = raycastHit.collider.gameObject;
           
            // Check enemy is in range
            if((enemy.transform.position - transform.position).magnitude > maxAttackRange)
            {
                return;
            }

            currentTarget = enemy;

            //currentTarget.GetComponent<Enemy>().TakeDamage(attackDamagePerHit);
            var enemyComponent = enemy.GetComponent<Enemy>();
            if(Time.time - lastHitTime > minTimeBetweenHits)
            {
                enemyComponent.TakeDamage(attackDamagePerHit);
                lastHitTime = Time.time;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealthPoints = Mathf.Clamp(currentHealthPoints - damage, 0f, maxHealthPoints);        
    }
}
