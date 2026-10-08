using CraftingGame.Core.Items;

namespace CraftingGame.Core.Tests.Items;

/// <summary>
/// Tests for <see cref="ItemDefinition"/>.
/// </summary>
public sealed class ItemDefinitionTests
{
    [Fact]
    public void Constructor_WithValidValues_CreatesDefinition()
    {
        // Arrange
        var id = new ItemId("stone");

        // Act
        var definition = new ItemDefinition(id, "Stone");

        // Assert
        Assert.Equal(id, definition.Id);
        Assert.Equal("Stone", definition.DisplayName);
    }

    [Fact]
    public void Constructor_WithBlankDisplayName_Throws()
    {
        // Arrange
        var id = new ItemId("stone");

        // Act
        void act() { _ = new ItemDefinition(id, " "); }

        // Assert
        Assert.Throws<ArgumentException>(act);
    }
}
