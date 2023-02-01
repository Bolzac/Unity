public class Empty : Base
{
    private void Start()
    {
        StartCoroutine(baseController.SetName());
    }
}