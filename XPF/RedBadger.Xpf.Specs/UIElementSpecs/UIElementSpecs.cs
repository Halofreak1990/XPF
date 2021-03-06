#region License
/* The MIT License
 *
 * Copyright (c) 2011 Red Badger Consulting
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
*/
#endregion

//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.UIElementSpecs
{
    using System.Collections.Generic;
    using System.Linq;

    using Machine.Specifications;

    [Subject(typeof(UIElement), "Children")]
    public class when_children_are_requested : a_UIElement
    {
        private static IEnumerable<IElement> enumerable;

        private Because of = () => enumerable = Subject.Object.GetVisualChildren();

        private It should_not_return_any_children = () => enumerable.Count().ShouldEqual(0);
    }

    [Subject(typeof(UIElement), "Hit Testing")]
    public class when_a_point_is_inside_an_element : a_UIElement_in_a_RootElement
    {
        private static bool hitTestResult;

        private Establish context = () => RootElement.Object.Update();

        private Because of = () => hitTestResult = Subject.Object.HitTest(new Point(40, 50));

        private It should_return_a_positive_hit_test = () => hitTestResult.ShouldBeTrue();
    }

    [Subject(typeof(UIElement), "Hit Testing")]
    public class when_a_point_is_outside_an_element : a_UIElement_in_a_RootElement
    {
        private static bool hitTestResult;

        private Establish context = () => RootElement.Object.Update();

        private Because of = () => hitTestResult = Subject.Object.HitTest(new Point(20, 30));

        private It should_return_a_negative_hit_test = () => hitTestResult.ShouldBeFalse();
    }
}
