namespace Gameplay.Doors
{
    public class InteractableDoor : Door, IClickInteractable
    {
        public void Interact() => Open();
    }
}
