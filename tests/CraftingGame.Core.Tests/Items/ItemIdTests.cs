using CraftingGame.Core.Items;

namespace CraftingGame.Core.Tests.Items;

/// <summary>
/// Tests for <see cref="ItemId"/>.
/// </summary>
public sealed class ItemIdTests
{
    [Fact]
    public void EqualValues_AreEqual()
    {
        // Arrange
        var first = new ItemId("stone");
        var second = new ItemId("stone");

        // Act
        var areEqual = first == second;

        // Assert
        Assert.True(areEqual);
    }
}
