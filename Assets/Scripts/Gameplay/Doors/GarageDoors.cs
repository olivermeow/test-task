using UnityEngine;

namespace Gameplay.Doors
{
    public class GarageDoors : MonoBehaviour, IClickInteractable
    {
        [SerializeField] private Door[] doors;

        private bool _openned;

        public void Interact()
        {
            if (_openned)
                return;
        
            foreach (var door in doors)
            {
                door.Open();
                _openned = true;
            }
        }
    
    
    }
}