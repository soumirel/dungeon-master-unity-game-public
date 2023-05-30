using UnityEngine;

namespace UI
{
    public abstract class InteractionWindowContent : MonoBehaviour
    {
        protected FieldCell currentCell;

        public FieldCell CurrentCell
        {
            get => currentCell;
            set => currentCell = value;
        }
    }
}