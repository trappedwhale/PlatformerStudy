using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PlatformerStudy;

public class Game1 : Game {
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D _trappedWhaleTexture;

    public Game1() {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize() {
        base.Initialize();
    }

    protected override void LoadContent() {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // 이미지 로드
        _trappedWhaleTexture = Content.Load<Texture2D>("Assets/Splash/trapped_whale");
    }

    protected override void Update(GameTime gameTime) {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        // 화면 크기
        var screenWidth = _graphics.PreferredBackBufferWidth;
        var screenHeight = _graphics.PreferredBackBufferHeight;

        // 축소 비율
        float scale = 0.5f;

        // 축소된 크기
        var scaledWidth = _trappedWhaleTexture.Width * scale;
        var scaledHeight = _trappedWhaleTexture.Height * scale;

        // 화면 중앙 위치 계산
        var position = new Vector2(
            (screenWidth - scaledWidth) / 2f,
            (screenHeight - scaledHeight) / 2f
        );

        // 이미지 그리기 (축소 포함)
        _spriteBatch.Draw(
            _trappedWhaleTexture,
            position,
            null,
            Color.White,
            0f,
            Vector2.Zero,
            scale,
            SpriteEffects.None,
            0f
        );

        _spriteBatch.End();

        base.Draw(gameTime);
    }

}
