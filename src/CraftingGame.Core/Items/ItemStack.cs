namespace CraftingGame.Core.Items;

/// <summary>
/// Represents a positive quantity of a particular item type.
/// </summary>
public readonly record struct ItemStack
{
    public ItemStack(ItemId itemId, int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(quantity),
                quantity,
                "An item stack must contain at least one item.");
        }

        ItemId = itemId;
        Quantity = quantity;
    }

    /// <summary>
    /// Gets the identifier of the item contained in this stack.
    /// </summary>
    public ItemId ItemId { get; }

    /// <summary>
    /// Gets the number of items contained in this stack.
    /// </summary>
    public int Quantity { get; }
}
