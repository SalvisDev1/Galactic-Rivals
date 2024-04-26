using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BaseStats
{
	[SerializeField]
	private float currentHealth;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float range;
    [SerializeField]
    private float baseDamage;
    [SerializeField]
    private float attackDelay;
    [SerializeField]
    private float currentAttackDelay;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private SphereCollider detectionObject;
	[SerializeField]
	private GameConstants.OBJECT_TYPE objectType;
	[SerializeField]
	private GameConstants.OBJECT_ATTACKABLE objectAttackable;

	public GameConstants.OBJECT_ATTACKABLE ObjectAttackable
	{
		get { return objectAttackable; }
		set { objectAttackable = value; }
	}
	public GameConstants.OBJECT_TYPE ObjectType
	{
		get { return objectType; }
		set { objectType = value; }
	}
	public SphereCollider DetectionObject
	{
		get { return detectionObject; }
	}
	public Image HealthBar
	{
		get { return healthBar; }
	}
	public float MoveSpeed
	{
		get { return moveSpeed; }
		set { moveSpeed = value; }
	}
	public float CurrentAttackDelay
	{
		get { return currentAttackDelay; }
		set { currentAttackDelay = value; }
	}
	public float AttackDelay
	{
		get { return attackDelay; }
	}
	public float BaseDamage
	{
		get { return baseDamage; }
	}
	public float Range
	{
		get { return range; }
	}
	public float MaxHealth
	{
		get { return maxHealth; }
	}
	public float Percentfloat
	{
		get { return currentHealth / maxHealth; }
	}
	public float CurrentHealth
	{
		get { return currentHealth; }
		set
		{
			if(value <= 0)
			{
				currentHealth = 0;
			} else if(value >= maxHealth)
			{
				currentHealth = maxHealth;
			} else
			{
				currentHealth = value;
			}
		}
	}

	public void UpdateStats()
	{
		healthBar.fillAmount = Percentfloat;
		detectionObject.radius = range;
		if(currentAttackDelay < attackDelay)
		{
			currentAttackDelay += Time.deltaTime;
		}
	}
}
