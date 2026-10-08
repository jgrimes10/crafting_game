namespace CraftingGame.Core.Items;

/// <summary>
/// Describes an item type that can exist in the game.
/// </summary>
public sealed class ItemDefinition
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ItemDefinition"/> class.
    /// </summary>
    /// <param name="id">The stable identifier for this item type.</param>
    /// <param name="displayName">The player-facing name of this item type.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="displayName"/> is null or whitespace.</exception>
    public ItemDefinition(ItemId id, string displayName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(displayName);

        Id = id;
        DisplayName = displayName;
    }

    /// <summary>
    /// Gets the stable identifier for this item type.
    /// </summary>
    public ItemId Id { get; }

    /// <summary>
    /// Gets the player-facing name of this item type.
    /// </summary>
    public string DisplayName { get; }
}
