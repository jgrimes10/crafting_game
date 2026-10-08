using CraftingGame.Core.Items;

namespace CraftingGame.Core.Tests.Items;

/// <summary>
/// Tests for <see cref="ItemStack"/>.
/// </summary>
public sealed class ItemStackTests
{
    [Fact]
    public void Constructor_WithPositiveQuantity_CreatesStack()
    {
        // Arrange
        var stoneId = new ItemId("stone");

        // Act
        var stack = new ItemStack(stoneId, 12);

        // Assert
        Assert.Equal(stoneId, stack.ItemId);
        Assert.Equal(12, stack.Quantity);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Constructor_WithNonPositiveQuantity_Throws(int quantity)
    {
        // Arrange
        var stoneId = new ItemId("stone");

        // Act
        void act() { _ = new ItemStack(stoneId, quantity); }

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }
}
