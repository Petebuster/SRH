using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OnePiece
{
    public class Camera
    {
       

        private Color backgroundColor;
        private Rectangle bounds;
        private Vector2 position;
        private float rotation;
        private Matrix transformMatrix;
        private Viewport viewport;
        private Rectangle visbounds;
        private float zoom;

        private static Camera mainCamera;

        public static Camera Main
        {
            get
            {
                if (mainCamera == null) mainCamera = new Camera(); return mainCamera;
            }
            set
            {
                mainCamera = value;
            }
        }

        

        

        public Camera(GraphicsDeviceManager graphics = null)
        {
            Reset(graphics);
        }

       

        

        /// <summary>
        /// The color that will be used as Clear-Color.
        /// </summary>
        public Color BackgroundColor { get { return this.backgroundColor; } set { this.backgroundColor = value; } }

        public Rectangle Bounds
        {
            get
            {
                return visbounds;
            }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; updateMatrix(); }
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; updateMatrix(); }
        }

        /// <summary>
        /// The Transformation Matrix of the 2D-Camera
        /// </summary>
        public Matrix TransformMatrix
        {
            get
            {
                return transformMatrix;
            }
        }

        /// <summary>
        /// The Viewport in the real world
        /// </summary>
        public Viewport Viewport
        {
            get
            {
                return viewport;
            }
        }

        /// <summary>
        /// The current Zoomvalue
        /// </summary>
        public float Zoom { get { return this.zoom; } set { this.zoom = value; updateMatrix(); } }

        
        

        /// <summary>
        /// Resets the camera to its default values.
        /// </summary>
        public void Reset(GraphicsDeviceManager graphics = null)
        {
            if (graphics != null)
                this.bounds = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            this.zoom = 1;
            updateMatrix();
        }

        /// <summary>
        /// This method is used to get the Mouseposition on the world, translated by the camera. If
        /// the camera is moved, the position of the mouse in the world will change as well.
        /// </summary>
        /// <returns>A Vector2 for the translated MousePosition.</returns>
        public Vector2 TranslatedCursorPosition()
        {
            return Vector2.Transform(new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Matrix.Invert(transformMatrix));
        }

        

        

        private void updateMatrix()
        {
            transformMatrix = Matrix.CreateTranslation(new Vector3(-this.Position.X, -this.Position.Y, 0)) *
                    Matrix.CreateRotationZ(this.Rotation) *
                    Matrix.CreateScale(this.zoom) *
                    Matrix.CreateTranslation(new Vector3(this.bounds.Width * 0.5f, this.bounds.Height * 0.5f, 0)
                    );

            viewport = new Viewport(
                        (int)(this.bounds.Width * -0.5f * (1f / this.zoom) - Position.X),
                        (int)(this.bounds.Height * -0.5f * (1f / this.zoom) - Position.Y),
                        (int)(this.bounds.Width * (1f / this.zoom)),
                        (int)(this.bounds.Height * (1f / this.zoom))
                        );

            visbounds = new Rectangle(
                    -(viewport.Bounds.X + viewport.Bounds.Width),
                    -(viewport.Bounds.Y + viewport.Bounds.Height),
                    viewport.Width,
                    viewport.Height
                    );
        }

        
    }
}