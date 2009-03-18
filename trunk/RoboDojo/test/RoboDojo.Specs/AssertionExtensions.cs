using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoboDojo.Specs
{
    public static class AssertionExtensions
    {
        public static void ShouldBeTrue(this bool value)
        {
            Assert.IsTrue(value);
        }

        public static void ShouldBeFalse(this bool value)
        {
            Assert.IsFalse(value);
        }

        public static void ShouldNotEqual(this object actual, object value)
        {
            Assert.AreNotEqual(value, actual);
        }

        public static void ShouldEqual(this object actual, object value)
        {
            Assert.AreEqual(value, actual);
        }

        public static void ShouldNotBeNull(this object value)
        {
            Assert.IsNotNull(value);
        }

        public static void ShouldBeNull(this object value)
        {
            Assert.IsNull(value);
        }
    }
}