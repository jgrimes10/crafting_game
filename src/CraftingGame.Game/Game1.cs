using CraftingGame.Core.Items;
using CraftingGame.Game.GameData;
using CraftingGame.Game.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CraftingGame.Game;

/// <summary>
/// Hosts the main MonoGame application.
/// </summary>
public class Game1 : Microsoft.Xna.Framework.Game
{
    private readonly GraphicsDeviceManager _graphics;
    private readonly ItemStack _stoneStack;

    private SpriteBatch _spriteBatch = null!;
    private ItemCardRenderer _itemCardRenderer = null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="Game1"/> class.
    /// </summary>
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);

        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _graphics.PreferredBackBufferWidth = 960;
        _graphics.PreferredBackBufferHeight = 540;

        _stoneStack = new ItemStack(
            PrototypeItems.Stone.Id,
            quantity: 12);
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        var font = Content.Load<SpriteFont>("Fonts/Default");

        _itemCardRenderer = new ItemCardRenderer(
            GraphicsDevice,
            font);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(new Color(20, 22, 27));

        _spriteBatch.Begin(
            samplerState: SamplerState.PointClamp);

        var itemBounds = new Rectangle(
            x: 40,
            y: 40,
            width: 220,
            height: 110);

        _itemCardRenderer.Draw(
            _spriteBatch,
            itemBounds,
            PrototypeItems.Stone,
            _stoneStack);

        _spriteBatch.End();

        base.Draw(gameTime);
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _itemCardRenderer?.Dispose();
            _spriteBatch?.Dispose();
        }

        base.Dispose(disposing);
    }
}
