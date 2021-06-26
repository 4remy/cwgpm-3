using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Schwer.ItemSystem.Demo {
    public class InventoryManager : MonoBehaviour {
        [SerializeField] private InventorySO _inventory = default;
        private Inventory inventory => _inventory.value;

        [Header("Item Display components")]
        [SerializeField] private Text nameDisplay = default;
        [SerializeField] private Text descriptionDisplay = default;
        [SerializeField] private GameObject useButton = default;

        private List<ItemSlot> itemSlots = new List<ItemSlot>();

        private Item selectedItem;

        private void OnEnable() {
            inventory.OnContentsChanged += UpdateSlots;

            var selected = EventSystem.current.currentSelectedGameObject;
            if (selected == null || !selected.transform.IsChildOf(this.transform)) {
                EventSystem.current.SetSelectedGameObject(itemSlots[0].gameObject);
            }

            Initialise();
        }

        private void OnDisable() => inventory.OnContentsChanged -= UpdateSlots;

        private void Awake() {
            GetComponentsInChildren<ItemSlot>(itemSlots);

            foreach (var slot in itemSlots) {
                slot.manager = this;
            }
        }

        private void Initialise() {
            UpdateDisplay(null);
            if (inventory != null) {
                UpdateSlots();
            }
        }

        public void UpdateSlots() => UpdateSlots(null, 0);
        private void UpdateSlots(Item item, int count) {
            for (int i = 0; i < itemSlots.Count; i++) {
                if (i < inventory.Count) {
                    var entry = inventory.ElementAt(i);
                    itemSlots[i].SetItem(entry.Key, entry.Value);
                }
                else {
                    itemSlots[i].Clear();
                }
            }

            var current = EventSystem.current.currentSelectedGameObject?.GetComponent<ItemSlot>();
            if (current != null) {
                UpdateDisplay(current.item);
            }
        }

        public void UpdateDisplay(Item item) {
            selectedItem = item;

            if (item != null) {
                nameDisplay.text = item.name;
                descriptionDisplay.text = item.description;
            }
            else {
                nameDisplay.text = "";
                descriptionDisplay.text = "";
            }

            // UpdateDisplay handles displaying information about
            // the currently selected item.
            // ∴ the active status of the use button should be
            //   handled here, since it depends on the selected item.
            useButton.SetActive((item is UsableItem));
        }

        // Called by the use button's OnClick UnityEvent
        public void UseButtonPressed() {
            if (selectedItem is UsableItem selectedUsable) {
                selectedUsable.Use();
                inventory[selectedUsable]--;

                // Need to set the selected item to null and update the display to reflect this.
                if (inventory[selectedItem] <= 0) {
                    UpdateDisplay(null);
                }
            }
        }
    }
}
