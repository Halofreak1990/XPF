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
    using System;

    using Machine.Specifications;

    using Microsoft.Xna.Framework;

    using Moq;

    using RedBadger.Xpf.Graphics;
    using RedBadger.Xpf.Presentation;
    using RedBadger.Xpf.Presentation.Media;

    using It = Machine.Specifications.It;

    [Subject(typeof(DrawingContext), "Text")]
    public class when_drawing_text_starts_before_the_context_is_opened : a_DrawingContext
    {
        private static Exception exception;

        private Because of =
            () =>
            exception =
            Catch.Exception(
                () => DrawingContext.DrawText(SpriteFont.Object, string.Empty, new SolidColorBrush(Color.AliceBlue)));

        private It should_throw_an_exception = () => exception.ShouldBeOfType<InvalidOperationException>();
    }

    [Subject(typeof(DrawingContext), "Text")]
    public class when_drawing_text : a_DrawingContext
    {
        private const string ExpectedString = "String Value";

        private static readonly Color expectedColor = Color.Black;

        private static readonly Vector2 expectedDrawPosition = Vector2.Zero;

        private Because of = () =>
            {
                DrawingContext.Open(UiElement.Object);
                DrawingContext.DrawText(SpriteFont.Object, ExpectedString, new SolidColorBrush(expectedColor));
                DrawingContext.Close();
                DrawingContext.Draw(SpriteBatch.Object);
            };

        private It should_render_text =
            () =>
            SpriteBatch.Verify(
                batch => batch.DrawString(SpriteFont.Object, ExpectedString, expectedDrawPosition, expectedColor));
    }

    [Subject(typeof(DrawingContext), "Rectangle")]
    public class when_drawing_a_rectangle_starts_before_the_context_is_opened : a_DrawingContext
    {
        private static Exception exception;

        private Because of =
            () =>
            exception =
            Catch.Exception(() => DrawingContext.DrawRectangle(Rect.Empty, new SolidColorBrush(Color.AliceBlue)));

        private It should_throw_an_exception = () => exception.ShouldBeOfType<InvalidOperationException>();
    }

    [Subject(typeof(DrawingContext), "Rectangle")]
    public class when_drawing_a_rectangle : a_DrawingContext
    {
        private static readonly SolidColorBrush expectedColor = new SolidColorBrush(Color.AliceBlue);

        private static readonly Rect expectedRect = new Rect(10, 20, 30, 40);

        private Because of = () =>
            {
                DrawingContext.Open(UiElement.Object);
                DrawingContext.DrawRectangle(expectedRect, expectedColor);
                DrawingContext.Close();
                DrawingContext.Draw(SpriteBatch.Object);
            };

        private It should_render_a_rectangle =
            () => SpriteBatch.Verify(batch => batch.Draw(Moq.It.IsAny<ITexture2D>(), expectedRect, expectedColor.Color));
    }

    [Subject(typeof(DrawingContext), "Rectangle")]
    public class when_resolving_offsets_for_a_rectangle : a_DrawingContext
    {
        private static readonly Vector2 absoluteOffset = new Vector2(20, 30);

        private static readonly Rect rect = new Rect(10, 20, 30, 40);

        private static Mock<IElement> uIElement;

        private Establish conetxt = () =>
            {
                uIElement = new Mock<IElement>();
                uIElement.SetupGet(element => element.AbsoluteOffset).Returns(absoluteOffset);
            };

        private Because of = () =>
            {
                DrawingContext.Open(uIElement.Object);
                DrawingContext.DrawRectangle(rect, new SolidColorBrush(Color.AliceBlue));
                DrawingContext.Close();
                DrawingContext.ResolveOffsets();
                DrawingContext.Draw(SpriteBatch.Object);
            };

        private It should_render_with_the_correct_offset =
            () =>
            SpriteBatch.Verify(
                batch =>
                batch.Draw(
                    Moq.It.IsAny<ITexture2D>(), 
                    new Rect(absoluteOffset.X + rect.X, absoluteOffset.Y + rect.Y, rect.Width, rect.Height), 
                    Moq.It.IsAny<Color>()));
    }

    [Subject(typeof(DrawingContext), "Text")]
    public class when_resolving_offsets_for_text : a_DrawingContext
    {
        private static readonly Vector2 absoluteOffset = new Vector2(20, 30);

        private static readonly Vector2 textOffset = new Vector2(10, 20);

        private static Mock<IElement> uIElement;

        private Establish conetxt = () =>
            {
                uIElement = new Mock<IElement>();
                uIElement.SetupGet(element => element.AbsoluteOffset).Returns(absoluteOffset);
            };

        private Because of = () =>
            {
                DrawingContext.Open(uIElement.Object);
                DrawingContext.DrawText(
                    SpriteFont.Object, string.Empty, textOffset, new SolidColorBrush(Color.AliceBlue));
                DrawingContext.Close();
                DrawingContext.ResolveOffsets();
                DrawingContext.Draw(SpriteBatch.Object);
            };

        private It should_render_with_the_correct_offset =
            () =>
            SpriteBatch.Verify(
                batch =>
                batch.DrawString(
                    Moq.It.IsAny<ISpriteFont>(), 
                    Moq.It.IsAny<string>(), 
                    absoluteOffset + textOffset, 
                    Moq.It.IsAny<Color>()));
    }
}