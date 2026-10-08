using CraftingGame.Core.Items;

namespace CraftingGame.Core.Tests.Inventory;

/// <summary>
/// Test for <see cref="Core.Inventory.Inventory"/>.
/// </summary>
public sealed class InventoryTests
{
    private static readonly ItemId StoneId = new("stone");
    private static readonly ItemId WoodId = new("wood");

    [Fact]
    public void Constructor_WithCapacity_CreatesEmptySlots()
    {
        // Act
        var inventory = new Core.Inventory.Inventory(3);

        // Assert
        Assert.Equal(3, inventory.Capacity);
        Assert.Null(inventory[0]);
        Assert.Null(inventory[1]);
        Assert.Null(inventory[2]);
    }

    [Fact]
    public void TryAdd_ToEmptyInventory_AddsStackToFirstSlot()
    {
        // Arrange
        var inventory = new Core.Inventory.Inventory(3);

        // Act
        var added = inventory.TryAdd(StoneId, 4);

        // Assert
        Assert.True(added);

        Assert.Equal(
            new ItemStack(StoneId, 4),
            inventory[0]);
    }

    [Fact]
    public void TryAdd_WhenItemAlreadyExists_IncreasesExistingStack()
    {
        // Arrange
        var inventory = new Core.Inventory.Inventory(3);

        inventory.TryAdd(StoneId, 4);

        // Act
        var added = inventory.TryAdd(StoneId, 3);

        // Assert
        Assert.True(added);

        Assert.Equal(
            new ItemStack(StoneId, 7),
            inventory[0]);

        Assert.Null(inventory[1]);
    }

    [Fact]
    public void TryAdd_DifferentItem_UsesNextEmptySlot()
    {
        // Arrange
        var inventory = new Core.Inventory.Inventory(3);

        inventory.TryAdd(StoneId, 4);

        // Act
        var added = inventory.TryAdd(WoodId, 2);

        // Assert
        Assert.True(added);

        Assert.Equal(
            new ItemStack(StoneId, 4),
            inventory[0]);

        Assert.Equal(
            new ItemStack(WoodId, 2),
            inventory[1]);
    }

    [Fact]
    public void TryAdd_WhenInventoryIsFull_ReturnsFalse()
    {
        // Arrange
        var inventory = new Core.Inventory.Inventory(1);

        inventory.TryAdd(StoneId, 1);

        // Act
        var added = inventory.TryAdd(WoodId, 1);

        // Assert
        Assert.False(added);

        Assert.Equal(
            new ItemStack(StoneId, 1),
            inventory[0]);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void TryAdd_WithNonPositiveQuantity_Throws(int quantity)
    {
        // Arrange
        var inventory = new Core.Inventory.Inventory(3);

        // Act
        void act() { _ = inventory.TryAdd(StoneId, quantity); }

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }
}
