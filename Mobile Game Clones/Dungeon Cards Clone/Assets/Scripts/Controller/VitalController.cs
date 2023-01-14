public class VitalController : BaseController
{
    public VitalModel vitalModel;

    private void Update()
    {
        if (vitalModel) vitalModel.healthText.text = vitalModel.currentHealth.ToString();
    }
}