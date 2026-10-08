using CraftingGame.Core.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CraftingGame.Game.UI;

/// <summary>
/// Renders a simple visual representation of an item stack.
/// </summary>
internal sealed class ItemCardRenderer : IDisposable
{
    private const int Padding = 16;

    private readonly SpriteFont _font;
    private readonly Texture2D _pixel;

    /// <summary>
    /// Initializes a new instance of the <see cref="ItemCardRenderer"/> class.
    /// </summary>
    /// <param name="graphicsDevice">The active graphics device.</param>
    /// <param name="font">The font used to render item information.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="graphicsDevice"/> or <paramref name="font"/> is <see langword="null"/>.</exception>
    public ItemCardRenderer(
        GraphicsDevice graphicsDevice,
        SpriteFont font)
    {
        ArgumentNullException.ThrowIfNull(graphicsDevice);
        ArgumentNullException.ThrowIfNull(font);

        _font = font;

        _pixel = new Texture2D(graphicsDevice, 1, 1);
        _pixel.SetData([Color.White]);
    }

    /// <summary>
    /// Draws an item stack inside the supplied bounds.
    /// </summary>
    /// <param name="spriteBatch">The sprite batch used for rendering.</param>
    /// <param name="bounds">The bounds within which to draw the item stack.</param>
    /// <param name="definition">The definition of the item to draw.</param>
    /// <param name="stack">The item stack to draw.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="spriteBatch"/> or <paramref name="definition"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if the item definition does not match the item stack.</exception>
    public void Draw(
        SpriteBatch spriteBatch,
        Rectangle bounds,
        ItemDefinition definition,
        ItemStack stack)
    {
        ArgumentNullException.ThrowIfNull(spriteBatch);
        ArgumentNullException.ThrowIfNull(definition);

        if (definition.Id != stack.ItemId)
        {
            throw new ArgumentException(
                "The item definition does not match the item stack.",
                nameof(definition));
        }

        spriteBatch.Draw(
            _pixel,
            bounds,
            new Color(45, 50, 60));

        var innerBounds = new Rectangle(
            bounds.X + 3,
            bounds.Y + 3,
            bounds.Width - 6,
            bounds.Height - 6);

        spriteBatch.Draw(
            _pixel,
            innerBounds,
            new Color(65, 72, 84));

        var namePosition = new Vector2(
            bounds.X + Padding,
            bounds.Y + Padding);

        var quantityPosition = new Vector2(
            bounds.X + Padding,
            bounds.Y + Padding + 42);

        spriteBatch.DrawString(
            _font,
            definition.DisplayName,
            namePosition,
            Color.White);

        spriteBatch.DrawString(
            _font,
            $"x{stack.Quantity}",
            quantityPosition,
            Color.LightGray);
    }

    /// <inheritdoc />
    public void Dispose()
    {
        _pixel.Dispose();
    }
}
