public class FightController : VitalController
{

    public void TakeDamage(int damageAmount)
    {
        //Tek tek dönüştürmem hatalı mı yoksa geçici bir variable'ı bir kez dönüştürüp mü hepsinde kullanmalıyım
        ((VitalModel)baseModel).currentHealth = ((VitalModel)baseModel).currentHealth - damageAmount > 0 ? ((VitalModel)baseModel).currentHealth - damageAmount : 0;
        if(((VitalModel)baseModel).currentHealth == 0) Destroy(gameObject);
    }
}