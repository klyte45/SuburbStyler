using Klyte.SuburbStyler.Interfaces;
using Klyte.SuburbStyler.Utils;

namespace Klyte.SuburbStyler.TextureAtlas
{
    public class SSToolbarTextureAtlas : TextureAtlasDescriptor<SSToolbarTextureAtlas, SSResourceLoader>
    {
        protected override int Height => 49;
        protected override int Width => 43;
        protected override string ResourceName => "UI.Images.toolbar.png";
        protected override string CommonName => "SuburbStylerToolbarSprites";
        public override string[] SpriteNames => new string[] {
                    "ToolbarIconGroup6Hovered",    "ToolbarIconGroup6Focused",   "ToolbarIconGroup6Pressed",    "SuburbStylerIcon"
                };
    }
}
