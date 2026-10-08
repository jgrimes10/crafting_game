using CraftingGame.Core.Items;

namespace CraftingGame.Core.Inventory;

/// <summary>
/// Stores item stacks in a fixed number of inventory slots.
/// </summary>
public sealed class Inventory
{
    private readonly ItemStack?[] _slots;

    public Inventory(int capacity)
    {
        if (capacity <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(capacity),
                capacity,
                "Inventory capacity must be greater than zero.");
        }

        _slots = new ItemStack?[capacity];
    }

    /// <summary>
    /// Gets the total number of slots in the inventory.
    /// </summary>
    public int Capacity => _slots.Length;

    /// <summary>
    /// Gets the item stack contained in the specified slot.
    /// </summary>
    /// <param name="index">The zero-based slot index.</param>
    /// <returns>The item stack contained in the specified slot, or null if the slot is empty.</returns>
    public ItemStack? this[int index] => _slots[index];

    /// <summary>
    /// Attempts to add items to the inventory.
    /// </summary>
    /// <param name="itemId">The item type to add.</param>
    /// <param name="quantity">The quantity to add.</param>
    /// <returns>
    /// <see langword="true"/> if the items were added;
    /// otherwise, <see langword="false"/> if there was no available slot to add the items.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="quantity"/> is less than or equal to zero.
    /// </exception>
    public bool TryAdd(ItemId itemId, int quantity)
    {
        // Only allow adding positive quantities of items to the inventory.
        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(quantity),
                quantity,
                "Quantity must be greater than zero.");
        }

        // Check if the item already exists in the inventory.
        var existingSlotIndex = FindSlotContaining(itemId);

        // If the item already exists, increase the quantity in that slot.
        if (existingSlotIndex >= 0)
        {
            var existingStack = _slots[existingSlotIndex]!.Value;

            _slots[existingSlotIndex] = new ItemStack(
                itemId,
                existingStack.Quantity + quantity);

            return true;
        }

        // Item does not exist in the inventory, so find an empty slot to add it to.
        var emptySlotIndex = FindEmptySlot();

        // If no empty slots are available, return false to indicate that the item could not be added.
        if (emptySlotIndex < 0)
        {
            return false;
        }

        // Add the new item stack to the empty slot.
        _slots[emptySlotIndex] = new ItemStack(itemId, quantity);

        return true;
    }

    /// <summary>
    /// Find the slot containing the specified item ID.
    /// </summary>
    /// <param name="itemId">The ID of the item to find.</param>
    /// <returns>The zero-based index of the slot containing the specified item ID, or -1 if the item is not found.</returns>
    private int FindSlotContaining(ItemId itemId)
    {
        for (var index = 0; index < _slots.Length; index++)
        {
            if (_slots[index]?.ItemId == itemId)
            {
                return index;
            }
        }

        return -1;
    }

    /// <summary>
    /// Finds the first empty inventory slot.
    /// </summary>
    /// <returns>The zero-based index of the first empty slot, or -1 if no empty slots are available.</returns>
    private int FindEmptySlot()
    {
        for (var index = 0; index < _slots.Length; index++)
        {
            if (_slots[index] is null)
            {
                return index;
            }
        }

        return -1;
    }
}
