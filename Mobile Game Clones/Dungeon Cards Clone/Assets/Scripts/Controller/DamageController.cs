public class DamageController : FightController
{
    public void TakePoisonDamage()
    {
        if ( ((VitalModel)baseModel).currentHealth > 1)
        {
            ((VitalModel)baseModel).currentHealth--;
            if (((VitalModel)baseModel).currentHealth == 1)
            {
                GameManager.Instance.OnRoundChange -= TakePoisonDamage;
            }
        }
    }
}