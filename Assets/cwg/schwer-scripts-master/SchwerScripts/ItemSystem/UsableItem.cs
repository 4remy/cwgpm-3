﻿using UnityEngine;
using UnityEngine.Events;

namespace Schwer.ItemSystem {
    [CreateAssetMenu(menuName = "Item System/Usable Item")]
    public class UsableItem : Item {
        [SerializeField] private UnityEvent OnUse = default;

        public void Use() => OnUse.Invoke();
    }
}
