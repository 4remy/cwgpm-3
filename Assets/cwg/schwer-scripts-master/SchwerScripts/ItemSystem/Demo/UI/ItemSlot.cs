using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Schwer.ItemSystem.Demo {
    public class ItemSlot : MonoBehaviour, ISelectHandler {
        [Header("Components")]
        [SerializeField] private Image sprite = default;
        [SerializeField] private Text count = default;

        public IItemSlotManager manager { get; set; }
        public Item item { get; private set; }

        public void SetItem(Item item, int itemCount) {
            this.item = item;
            if (item != null) {
                sprite.sprite = item.sprite;
                sprite.enabled = true;
                count.text = "x" + itemCount;
            }
            else {
                Clear();
            }
        }

        public void Clear() {
            item = null;
            sprite.enabled = false;
            sprite.sprite = null;
            count.text = "";
        }

        public void OnSelect(BaseEventData eventData) => manager?.OnItemSelected(item);
    }

    public interface IItemSlotManager {
        void OnItemSelected(Item item);
    }
}
