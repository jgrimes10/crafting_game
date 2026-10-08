using CraftingGame.Core.Items;

namespace CraftingGame.Game.GameData;

/// <summary>
/// Contains temporary item definitions used while developing the prototype.
/// </summary>
/// <remarks>
/// This will eventually be replaced by data-driven item loading.
/// </remarks>
internal static class PrototypeItems
{
    /// <summary>
    /// Gets the prototype stone item.
    /// </summary>
    public static ItemDefinition Stone { get; } =
        new(new ItemId("stone"), "Stone");
}
