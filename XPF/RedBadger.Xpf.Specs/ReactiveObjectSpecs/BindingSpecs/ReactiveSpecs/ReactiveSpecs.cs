//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.ReactiveObjectSpecs.BindingSpecs.ReactiveSpecs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Subjects;
    using System.Reactive.Linq;
    using Machine.Specifications;
    using RedBadger.Xpf.Controls;
    using RedBadger.Xpf.Media;
    using System.Reactive;

    public class TestBindingObject
    {
        private readonly BehaviorSubject<Brush> brushProperty = new BehaviorSubject<Brush>(null);

        private readonly BehaviorSubject<SolidColorBrush> solidColorBrushProperty =
            new BehaviorSubject<SolidColorBrush>(null);

        private readonly BehaviorSubject<double> widthProperty = new BehaviorSubject<double>(Double.NaN);

        public Brush Brush
        {
            get
            {
                return this.brushProperty.First();
            }

            set
            {
                this.brushProperty.OnNext(value);
            }
        }

        public IObservable<Brush> BrushObservable
        {
            get
            {
                return this.brushProperty.AsObservable();
            }
        }

        public IObserver<Brush> BrushObserver
        {
            get
            {
                return this.brushProperty.AsObserver();
            }
        }

        public SolidColorBrush SolidColorBrush
        {
            get
            {
                return this.solidColorBrushProperty.First();
            }

            set
            {
                this.solidColorBrushProperty.OnNext(value);
            }
        }

        public IObservable<SolidColorBrush> SolidColorBrushObservable
        {
            get
            {
                return this.solidColorBrushProperty.AsObservable();
            }
        }

        public IObserver<SolidColorBrush> SolidColorBrushObserver
        {
            get
            {
                return this.solidColorBrushProperty.AsObserver();
            }
        }

        public double Width
        {
            get
            {
                return this.widthProperty.First();
            }

            set
            {
                this.widthProperty.OnNext(value);
            }
        }

        public IObservable<double> WidthObservable
        {
            get
            {
                return this.widthProperty.AsObservable();
            }
        }

        public IObserver<double> WidthObserver
        {
            get
            {
                return this.widthProperty.AsObserver();
            }
        }
    }

    [Subject(typeof(ReactiveObject), "One Way")]
    public class when_there_is_a_one_way_binding_to_a_property_on_a_specified_source
    {
        private const double ExpectedWidth = 10d;

        private static TestBindingObject source;

        private static Border target;

        private Establish context = () =>
            {
                source = new TestBindingObject();
                target = new Border();

                target.Bind(UIElement.WidthProperty, source.WidthObservable);
            };

        private Because of = () => source.Width = ExpectedWidth;

        private It should_update_the_target = () => target.Width.ShouldEqual(ExpectedWidth);
    }

    [Subject(typeof(ReactiveObject), "One Way")]
    public class when_a_binding_is_one_way_and_the_source_property_type_is_more_derived
    {
        private static readonly SolidColorBrush expectedBrush = new SolidColorBrush(Colors.Brown);

        private static TestBindingObject source;

        private static Border target;

        private Establish context = () =>
            {
                source = new TestBindingObject();
                target = new Border();

                target.Bind(Border.BorderBrushProperty, source.SolidColorBrushObservable);
            };

        private Because of = () => source.SolidColorBrush = expectedBrush;

        private It should_update_the_target = () => target.BorderBrush.ShouldEqual(expectedBrush);
    }

    [Subject(typeof(ReactiveObject), "One Way")]
    public class when_a_one_way_binding_to_a_property_on_a_specified_source_is_cleared
    {
        private static readonly Brush expectedBrush = new SolidColorBrush(Colors.Brown);

        private static TestBindingObject source;

        private static Border target;

        private Establish context = () =>
            {
                source = new TestBindingObject();
                target = new Border();

                target.Bind(Border.BorderBrushProperty, source.BrushObservable);
            };

        private Because of = () =>
            {
                source.Brush = expectedBrush;
                target.ClearBinding(Border.BorderBrushProperty);

                source.Brush = new SolidColorBrush(Colors.Black);
            };

        private It should_not_use_the_binding = () => target.BorderBrush.ShouldEqual(expectedBrush);
    }

    [Subject(typeof(ReactiveObject), "One Way To Source")]
    public class when_there_is_a_one_way_to_source_binding_to_a_specified_source
    {
        private static readonly Brush expectedBrush = new SolidColorBrush(Colors.Brown);

        private static TestBindingObject source;

        private static Border target;

        private Establish context = () =>
            {
                source = new TestBindingObject();
                target = new Border();

                target.Bind(Border.BorderBrushProperty, source.BrushObserver);
            };

        private Because of = () => target.BorderBrush = expectedBrush;

        private It should_update_the_source = () => source.Brush.ShouldEqual(expectedBrush);
    }

    [Subject(typeof(ReactiveObject), "One Way To Source")]
    public class when_a_one_way_to_source_binding_to_a_specified_source_is_cleared
    {
        private static readonly Brush expectedBrush = new SolidColorBrush(Colors.Brown);

        private static TestBindingObject source;

        private static Border target;

        private Establish context = () =>
            {
                source = new TestBindingObject();
                target = new Border();

                target.Bind(Border.BorderBrushProperty, source.BrushObserver);
            };

        private Because of = () =>
            {
                target.BorderBrush = expectedBrush;
                target.ClearBinding(Border.BorderBrushProperty);

                target.BorderBrush = new SolidColorBrush(Colors.Yellow);
            };

        private It should_not_update_the_source = () => source.Brush.ShouldEqual(expectedBrush);
    }

    [Subject(typeof(ReactiveObject), "Two Way")]
    public class when_a_binding_is_two_way_to_a_property_on_a_specified_source
    {
        private static readonly Brush expectedSourceBrush = new SolidColorBrush(Colors.Blue);

        private static readonly Brush expectedTargetBrush = new SolidColorBrush(Colors.Red);

        private static Brush actualBrushOnSource;

        private static Brush actualBrushOnTarget;

        private static TestBindingObject source;

        private static Border target;

        private Establish context = () =>
            {
                source = new TestBindingObject();
                target = new Border();

                target.Bind(Border.BorderBrushProperty, source.BrushObservable, source.BrushObserver);
            };

        private Because of = () =>
            {
                target.BorderBrush = expectedTargetBrush;
                actualBrushOnSource = source.Brush;

                source.Brush = expectedSourceBrush;
                actualBrushOnTarget = target.BorderBrush;
            };

        private It should_update_the_source = () => actualBrushOnSource.ShouldEqual(expectedTargetBrush);

        private It should_update_the_target = () => actualBrushOnTarget.ShouldEqual(expectedSourceBrush);
    }

    [Subject(typeof(ReactiveObject), "Two Way")]
    public class when_a_binding_is_two_way_to_a_property_on_a_specified_source_and_the_binding_is_cleared
    {
        private static TestBindingObject source;

        private static Color sourceColor;

        private static Border target;

        private static Color targetColor;

        private Establish context = () =>
            {
                source = new TestBindingObject { Brush = new SolidColorBrush(Colors.Green) };
                target = new Border();

                target.Bind(Border.BorderBrushProperty, source.BrushObservable, source.BrushObserver);
            };

        private Because of = () =>
            {
                target.ClearBinding(Border.BorderBrushProperty);

                source.Brush = new SolidColorBrush(Colors.Blue);
                targetColor = ((SolidColorBrush)target.BorderBrush).Color;

                target.BorderBrush = new SolidColorBrush(Colors.Red);
                sourceColor = ((SolidColorBrush)source.Brush).Color;
            };

        private It should_stop_updating_the_source = () => sourceColor.ShouldEqual(Colors.Blue);

        private It should_stop_updating_the_target = () => targetColor.ShouldEqual(Colors.Green);
    }
}