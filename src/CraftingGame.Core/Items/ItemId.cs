namespace CraftingGame.Core.Items;

/// <summary>
/// Uniquely identifies an item type within the game.
/// </summary>
/// <param name="Value">The stable identifier for the item.</param>
public readonly record struct ItemId(string Value)
{
    /// <inheritdoc />
    public override string ToString() => Value;
}
