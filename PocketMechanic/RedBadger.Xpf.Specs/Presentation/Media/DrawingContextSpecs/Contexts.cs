//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.Presentation.Media.DrawingContextSpecs
{
    using Machine.Specifications;

    using Moq;

    using RedBadger.Xpf.Graphics;
    using RedBadger.Xpf.Presentation;
    using RedBadger.Xpf.Presentation.Media;

    public abstract class a_DrawingContext
    {
        protected static IDrawingContext DrawingContext;

        protected static IRenderer Renderer;

        protected static Mock<ISpriteBatch> SpriteBatch;

        protected static Mock<ISpriteFont> SpriteFont;

        protected static Mock<IElement> UiElement;

        private Establish context = () =>
            {
                SpriteBatch = new Mock<ISpriteBatch>();
                Renderer = new Renderer(SpriteBatch.Object, new Mock<IPrimitivesService>().Object);
                UiElement = new Mock<IElement>();
                DrawingContext = Renderer.GetDrawingContext(UiElement.Object);

                SpriteFont = new Mock<ISpriteFont>();
            };
    }
}