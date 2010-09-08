//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.Presentation.DependencyObjectSpecs.BindingSpecs.DependencyObjectSpecs
{
    using System;

    using Machine.Specifications;

    using Moq;

    using RedBadger.Xpf.Graphics;
    using RedBadger.Xpf.Presentation;
    using RedBadger.Xpf.Presentation.Controls;
    using RedBadger.Xpf.Presentation.Data;
    using RedBadger.Xpf.Presentation.Media;

    using It = Machine.Specifications.It;

    public class TestBindingObject : DependencyObject
    {
        public static readonly Property<Brush, TestBindingObject> BrushProperty =
            Property<Brush, TestBindingObject>.Register("Brush");

        public static readonly Property<SolidColorBrush, TestBindingObject> SolidColorBrushProperty =
            Property<SolidColorBrush, TestBindingObject>.Register("SolidColorBrush");

        public Brush Brush
        {
            get
            {
                return this.GetValue(BrushProperty);
            }

            set
            {
                this.SetValue(BrushProperty, value);
            }
        }

        public SolidColorBrush SolidColorBrush
        {
            get
            {
                return this.GetValue(SolidColorBrushProperty);
            }

            set
            {
                this.SetValue(SolidColorBrushProperty, value);
            }
        }

        public static readonly Property<double, TestBindingObject> WidthProperty = Property<double, TestBindingObject>.Register("Width");

        public double Width
        {
            get
            {
                return this.GetValue(WidthProperty);
            }

            set
            {
                this.SetValue(WidthProperty, value);
            }
        }
    }

    [Subject(typeof(DependencyObject))]
    public class when_a_binding_is_one_way
    {
        private const double ExpectedWidth = 10d;

        private static TestBindingObject source;

        private static Border target;

        private Establish context = () =>
            {
                source = new TestBindingObject();
                target = new Border();

                IObservable<double> fromSource = BindingFactory.CreateOneWay(source, TestBindingObject.WidthProperty);
                target.Bind(UIElement.WidthProperty, fromSource);
            };

        private Because of = () => source.Width = ExpectedWidth;

        private It should_have_the_correct_brush = () => target.Width.ShouldEqual(ExpectedWidth);
    }

    [Subject(typeof(DependencyObject))]
    public class when_a_binding_is_one_way_and_the_source_property_type_is_more_derived
    {
        private static readonly SolidColorBrush expectedBrush = new SolidColorBrush(Colors.Brown);

        private static TestBindingObject source;

        private static Border target;

        private Establish context = () =>
            {
                source = new TestBindingObject();
                target = new Border();

                IObservable<Brush> fromSource = BindingFactory.CreateOneWay(source, TestBindingObject.SolidColorBrushProperty);
                target.Bind(Border.BorderBrushProperty, fromSource);
            };

        private Because of = () => source.SolidColorBrush = expectedBrush;

        private It should_have_the_correct_brush = () => target.BorderBrush.ShouldEqual(expectedBrush);
    }

    [Subject(typeof(DependencyObject))]
    public class when_a_binding_is_one_way_to_source
    {
        private static readonly Brush expectedBrush = new SolidColorBrush(Colors.Brown);

        private static TestBindingObject source;

        private static Border target;

        private Establish context = () =>
            {
                source = new TestBindingObject();
                target = new Border();

                IObserver<Brush> toSource = BindingFactory.CreateOneWayToSource(
                    source, TestBindingObject.BrushProperty);
                target.Bind(Border.BorderBrushProperty, toSource);
            };

        private Because of = () => target.BorderBrush = expectedBrush;

        private It should_have_the_correct_brush = () => source.Brush.ShouldEqual(expectedBrush);
    }

    [Subject(typeof(DependencyObject))]
    public class when_a_binding_is_one_way_to_source_and_the_type_of_the_target_property_is_derived
    {
        private static readonly SolidColorBrush expectedBrush = new SolidColorBrush(Colors.Brown);

        private static Border source;

        private static TestBindingObject target;

        private Establish context = () =>
            {
                target = new TestBindingObject();
                source = new Border();

                IObserver<Brush> toSource = BindingFactory.CreateOneWayToSource(source, Border.BorderBrushProperty);
                target.Bind(TestBindingObject.SolidColorBrushProperty, toSource);
            };

        private Because of = () => target.SolidColorBrush = expectedBrush;

        private It should_have_the_correct_brush = () => source.BorderBrush.ShouldEqual(expectedBrush);
    }

    [Subject(typeof(UIElement))]
    public class when_a_binding_is_two_way
    {
    }

    [Subject(typeof(DependencyObject))]
    public class when_binding_to_the_data_context
    {
        private const string ExpectedValue = "Value";

        private static TextBlock target;

        private Establish context =
            () => target = new TextBlock(new Mock<ISpriteFont>().Object) { DataContext = ExpectedValue };

        private Because of = () => target.Bind(TextBlock.TextProperty);

        private It should_bind_to_the_object = () => target.Text.ShouldEqual(ExpectedValue);
    }

    [Subject(typeof(UIElement))]
    public class when_the_data_context_is_set_after_the_binding_has_been_created
    {
        private const string ExpectedValue = "Value";

        private static TextBlock target;

        private Establish context = () =>
            {
                target = new TextBlock(new Mock<ISpriteFont>().Object);
                target.Bind(TextBlock.TextProperty);
            };

        private Because of = () => target.DataContext = ExpectedValue;

        private It should_bind_to_the_data_context = () => target.Text.ShouldEqual(ExpectedValue);
    }

    [Subject(typeof(DependencyObject))]
    public class when_binding_to_the_data_context_and_the_data_context_is_changed
    {
        private const string NewDataContext = "New Data Context";

        private static TextBlock target;

        private Establish context =
            () =>
                {
                    target = new TextBlock(new Mock<ISpriteFont>().Object) { DataContext = "Old Data Context" };
                    target.Bind(TextBlock.TextProperty);
                };

        private Because of = () => target.DataContext = NewDataContext;

        private It should_use_the_new_data_context = () => target.Text.ShouldEqual(NewDataContext);
    }
}