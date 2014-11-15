// <copyright file="CommonMarkRegexTests.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Tests.Markdown
{
    using System.Text.RegularExpressions;

    using MfGames.Text.Markup.Markdown;

    using NUnit.Framework;

    /// <summary>
    /// Tests the various regular expressions against the CommonMark specification
    /// examples.
    /// </summary>
    [TestFixture]
    public class CommonMarkRegexTests
    {
        #region Public Methods and Operators

        /// <summary>
        /// Tests the regular expressions against CommonMark 0.12 § 4.2 examples.
        /// </summary>
        [Test]
        public void Example023AtxHeader1()
        {
            Match matches = CommonMarkSpecification.AtxHeaderRegex.Match(
                "# foo");

            Assert.AreEqual(
                true, 
                matches.Success, 
                "The success was unexpected.");
            Assert.AreEqual(
                3, 
                matches.Groups.Count, 
                "The number of groups was unexpected.");
            Assert.AreEqual(
                "#", 
                matches.Groups[1].Value, 
                "The heading count was unexpected.");
            Assert.AreEqual(
                "foo", 
                matches.Groups[2].Value, 
                "The heading text was unexpected.");
        }

        /// <summary>
        /// Tests the regular expressions against CommonMark 0.12 § 4.2 examples.
        /// </summary>
        [Test]
        public void Example023AtxHeader2()
        {
            Match matches =
                CommonMarkSpecification.AtxHeaderRegex.Match("## foo");

            Assert.AreEqual(
                true, 
                matches.Success, 
                "The success was unexpected.");
            Assert.AreEqual(
                3, 
                matches.Groups.Count, 
                "The number of groups was unexpected.");
            Assert.AreEqual(
                "##", 
                matches.Groups[1].Value, 
                "The heading count was unexpected.");
            Assert.AreEqual(
                "foo", 
                matches.Groups[2].Value, 
                "The heading text was unexpected.");
        }

        /// <summary>
        /// Tests the regular expressions against CommonMark 0.12 § 4.2 examples.
        /// </summary>
        [Test]
        public void Example023AtxHeader3()
        {
            Match matches =
                CommonMarkSpecification.AtxHeaderRegex.Match("### foo");

            Assert.AreEqual(
                true, 
                matches.Success, 
                "The success was unexpected.");
            Assert.AreEqual(
                3, 
                matches.Groups.Count, 
                "The number of groups was unexpected.");
            Assert.AreEqual(
                "###", 
                matches.Groups[1].Value, 
                "The heading count was unexpected.");
            Assert.AreEqual(
                "foo", 
                matches.Groups[2].Value, 
                "The heading text was unexpected.");
        }

        /// <summary>
        /// Tests the regular expressions against CommonMark 0.12 § 4.2 examples.
        /// </summary>
        [Test]
        public void Example023AtxHeader4()
        {
            Match matches =
                CommonMarkSpecification.AtxHeaderRegex.Match("#### foo");

            Assert.AreEqual(
                true, 
                matches.Success, 
                "The success was unexpected.");
            Assert.AreEqual(
                3, 
                matches.Groups.Count, 
                "The number of groups was unexpected.");
            Assert.AreEqual(
                "####", 
                matches.Groups[1].Value, 
                "The heading count was unexpected.");
            Assert.AreEqual(
                "foo", 
                matches.Groups[2].Value, 
                "The heading text was unexpected.");
        }

        /// <summary>
        /// Tests the regular expressions against CommonMark 0.12 § 4.2 examples.
        /// </summary>
        [Test]
        public void Example023AtxHeader5()
        {
            Match matches =
                CommonMarkSpecification.AtxHeaderRegex.Match("##### foo");

            Assert.AreEqual(
                true, 
                matches.Success, 
                "The success was unexpected.");
            Assert.AreEqual(
                3, 
                matches.Groups.Count, 
                "The number of groups was unexpected.");
            Assert.AreEqual(
                "#####", 
                matches.Groups[1].Value, 
                "The heading count was unexpected.");
            Assert.AreEqual(
                "foo", 
                matches.Groups[2].Value, 
                "The heading text was unexpected.");
        }

        /// <summary>
        /// Tests the regular expressions against CommonMark 0.12 § 4.2 examples.
        /// </summary>
        [Test]
        public void Example023AtxHeader6()
        {
            Match matches =
                CommonMarkSpecification.AtxHeaderRegex.Match("###### foo");

            Assert.AreEqual(
                true, 
                matches.Success, 
                "The success was unexpected.");
            Assert.AreEqual(
                3, 
                matches.Groups.Count, 
                "The number of groups was unexpected.");
            Assert.AreEqual(
                "######", 
                matches.Groups[1].Value, 
                "The heading count was unexpected.");
            Assert.AreEqual(
                "foo", 
                matches.Groups[2].Value, 
                "The heading text was unexpected.");
        }

        /// <summary>
        /// Tests the regular expressions against CommonMark 0.12 § 4.2 examples.
        /// </summary>
        [Test]
        public void Example024AtxHeader()
        {
            Match matches =
                CommonMarkSpecification.AtxHeaderRegex.Match("####### foo");

            Assert.AreEqual(
                false, 
                matches.Success, 
                "The success was unexpected.");
        }

        /// <summary>
        /// Tests the regular expressions against CommonMark 0.12 § 4.2 examples.
        /// </summary>
        [Test]
        public void Example025AtxHeader()
        {
            Match matches =
                CommonMarkSpecification.AtxHeaderRegex.Match("#5 foo");

            Assert.AreEqual(
                false, 
                matches.Success, 
                "The success was unexpected.");
        }

        /// <summary>
        /// Tests the regular expressions against CommonMark 0.12 § 4.2 examples.
        /// </summary>
        [Test]
        public void Example026AtxHeader()
        {
            Match matches =
                CommonMarkSpecification.AtxHeaderRegex.Match(@"\## foo");

            Assert.AreEqual(
                false, 
                matches.Success, 
                "The success was unexpected.");
        }

        /// <summary>
        /// Tests the regular expressions against CommonMark 0.12 § 4.2 examples.
        /// </summary>
        [Test]
        public void Example028AtxHeader()
        {
            Match matches =
                CommonMarkSpecification.AtxHeaderRegex.Match(
                    "#               foo            ");

            Assert.AreEqual(
                true, 
                matches.Success, 
                "The success was unexpected.");
            Assert.AreEqual(
                3, 
                matches.Groups.Count, 
                "The number of groups was unexpected.");
            Assert.AreEqual(
                "#", 
                matches.Groups[1].Value, 
                "The heading count was unexpected.");
            Assert.AreEqual(
                "foo", 
                matches.Groups[2].Value, 
                "The heading text was unexpected.");
        }

        /// <summary>
        /// Tests the regular expressions against CommonMark 0.12 § 4.2 examples.
        /// </summary>
        [Test]
        public void Example029AtxHeader1()
        {
            Match matches =
                CommonMarkSpecification.AtxHeaderRegex.Match(" ### foo");

            Assert.AreEqual(
                true, 
                matches.Success, 
                "The success was unexpected.");
            Assert.AreEqual(
                3, 
                matches.Groups.Count, 
                "The number of groups was unexpected.");
            Assert.AreEqual(
                "###", 
                matches.Groups[1].Value, 
                "The heading count was unexpected.");
            Assert.AreEqual(
                "foo", 
                matches.Groups[2].Value, 
                "The heading text was unexpected.");
        }

        /// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
        [Test]
        public void Example029AtxHeader2()
        {
            Match matches =
                CommonMarkSpecification.AtxHeaderRegex.Match("  ## foo");

            Assert.AreEqual(
                true, 
                matches.Success, 
                "The success was unexpected.");
            Assert.AreEqual(
                3, 
                matches.Groups.Count, 
                "The number of groups was unexpected.");
            Assert.AreEqual(
                "##", 
                matches.Groups[1].Value, 
                "The heading count was unexpected.");
            Assert.AreEqual(
                "foo", 
                matches.Groups[2].Value, 
                "The heading text was unexpected.");
        }

        /// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
        [Test]
        public void Example029AtxHeader3()
        {
            Match matches =
                CommonMarkSpecification.AtxHeaderRegex.Match("   # foo");

            Assert.AreEqual(
                true, 
                matches.Success, 
                "The success was unexpected.");
            Assert.AreEqual(
                3, 
                matches.Groups.Count, 
                "The number of groups was unexpected.");
            Assert.AreEqual(
                "#", 
                matches.Groups[1].Value, 
                "The heading count was unexpected.");
            Assert.AreEqual(
                "foo", 
                matches.Groups[2].Value, 
                "The heading text was unexpected.");
        }

        /// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
        [Test]
        public void Example030AtxHeader()
        {
            Match matches =
                CommonMarkSpecification.AtxHeaderRegex.Match("    # foo");

            Assert.AreEqual(
                false, 
                matches.Success, 
                "The success was unexpected.");
        }

        /// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
        [Test]
        public void Example032AtxHeader1()
        {
            Match matches =
                CommonMarkSpecification.AtxHeaderRegex.Match("## foo ##");

            Assert.AreEqual(
                true, 
                matches.Success, 
                "The success was unexpected.");
            Assert.AreEqual(
                3, 
                matches.Groups.Count, 
                "The number of groups was unexpected.");
            Assert.AreEqual(
                "##", 
                matches.Groups[1].Value, 
                "The heading count was unexpected.");
            Assert.AreEqual(
                "foo", 
                matches.Groups[2].Value, 
                "The heading text was unexpected.");
        }

        /// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
        [Test]
        public void Example032AtxHeader2()
        {
            Match matches =
                CommonMarkSpecification.AtxHeaderRegex.Match(
                    "  ###   foo    ###");

            Assert.AreEqual(
                true, 
                matches.Success, 
                "The success was unexpected.");
            Assert.AreEqual(
                3, 
                matches.Groups.Count, 
                "The number of groups was unexpected.");
            Assert.AreEqual(
                "###", 
                matches.Groups[1].Value, 
                "The heading count was unexpected.");
            Assert.AreEqual(
                "foo", 
                matches.Groups[2].Value, 
                "The heading text was unexpected.");
        }

        /// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
        [Test]
        public void Example033AtxHeader1()
        {
            Match matches =
                CommonMarkSpecification.AtxHeaderRegex.Match(
                    "# foo #####################");

            Assert.AreEqual(
                true, 
                matches.Success, 
                "The success was unexpected.");
            Assert.AreEqual(
                3, 
                matches.Groups.Count, 
                "The number of groups was unexpected.");
            Assert.AreEqual(
                "#", 
                matches.Groups[1].Value, 
                "The heading count was unexpected.");
            Assert.AreEqual(
                "foo", 
                matches.Groups[2].Value, 
                "The heading text was unexpected.");
        }

        /// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
        [Test]
        public void Example033AtxHeader2()
        {
            Match matches =
                CommonMarkSpecification.AtxHeaderRegex.Match("##### foo #");

            Assert.AreEqual(
                true, 
                matches.Success, 
                "The success was unexpected.");
            Assert.AreEqual(
                3, 
                matches.Groups.Count, 
                "The number of groups was unexpected.");
            Assert.AreEqual(
                "#####", 
                matches.Groups[1].Value, 
                "The heading count was unexpected.");
            Assert.AreEqual(
                "foo", 
                matches.Groups[2].Value, 
                "The heading text was unexpected.");
        }

        /// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
        [Test]
        public void Example034AtxHeader()
        {
            Match matches =
                CommonMarkSpecification.AtxHeaderRegex.Match("### foo ###   ");

            Assert.AreEqual(
                true, 
                matches.Success, 
                "The success was unexpected.");
            Assert.AreEqual(
                3, 
                matches.Groups.Count, 
                "The number of groups was unexpected.");
            Assert.AreEqual(
                "###", 
                matches.Groups[1].Value, 
                "The heading count was unexpected.");
            Assert.AreEqual(
                "foo", 
                matches.Groups[2].Value, 
                "The heading text was unexpected.");
        }

        /// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
        [Test]
        public void Example035AtxHeader()
        {
            Match matches =
                CommonMarkSpecification.AtxHeaderRegex.Match("### foo ### b");

            Assert.AreEqual(
                true, 
                matches.Success, 
                "The success was unexpected.");
            Assert.AreEqual(
                3, 
                matches.Groups.Count, 
                "The number of groups was unexpected.");
            Assert.AreEqual(
                "###", 
                matches.Groups[1].Value, 
                "The heading count was unexpected.");
            Assert.AreEqual(
                "foo ### b", 
                matches.Groups[2].Value, 
                "The heading text was unexpected.");
        }

        /// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
        [Test]
        public void Example036AtxHeader()
        {
            Match matches =
                CommonMarkSpecification.AtxHeaderRegex.Match("# foo#");

            Assert.AreEqual(
                true, 
                matches.Success, 
                "The success was unexpected.");
            Assert.AreEqual(
                3, 
                matches.Groups.Count, 
                "The number of groups was unexpected.");
            Assert.AreEqual(
                "#", 
                matches.Groups[1].Value, 
                "The heading count was unexpected.");
            Assert.AreEqual(
                "foo#", 
                matches.Groups[2].Value, 
                "The heading text was unexpected.");
        }

        /// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
        [Test]
        public void Example037AtxHeader1()
        {
            Match matches =
                CommonMarkSpecification.AtxHeaderRegex.Match(@"### foo \###");

            Assert.AreEqual(
                true, 
                matches.Success, 
                "The success was unexpected.");
            Assert.AreEqual(
                3, 
                matches.Groups.Count, 
                "The number of groups was unexpected.");
            Assert.AreEqual(
                "###", 
                matches.Groups[1].Value, 
                "The heading count was unexpected.");
            Assert.AreEqual(
                @"foo \###", 
                matches.Groups[2].Value, 
                "The heading text was unexpected.");
        }

        /// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
        [Test]
        public void Example037AtxHeader2()
        {
            Match matches =
                CommonMarkSpecification.AtxHeaderRegex.Match(@"### foo #\##");

            Assert.AreEqual(
                true, 
                matches.Success, 
                "The success was unexpected.");
            Assert.AreEqual(
                3, 
                matches.Groups.Count, 
                "The number of groups was unexpected.");
            Assert.AreEqual(
                "###", 
                matches.Groups[1].Value, 
                "The heading count was unexpected.");
            Assert.AreEqual(
                @"foo #\##", 
                matches.Groups[2].Value, 
                "The heading text was unexpected.");
        }

        /// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
        [Test]
        public void Example037AtxHeader3()
        {
            Match matches =
                CommonMarkSpecification.AtxHeaderRegex.Match(@"# foo \#");

            Assert.AreEqual(
                true, 
                matches.Success, 
                "The success was unexpected.");
            Assert.AreEqual(
                3, 
                matches.Groups.Count, 
                "The number of groups was unexpected.");
            Assert.AreEqual(
                "#", 
                matches.Groups[1].Value, 
                "The heading count was unexpected.");
            Assert.AreEqual(
                @"foo \#", 
                matches.Groups[2].Value, 
                "The heading text was unexpected.");
        }

        /// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
        [Test]
        public void Example040AtxHeader1()
        {
            Match matches = CommonMarkSpecification.AtxHeaderRegex.Match("## ");

            Assert.AreEqual(
                true, 
                matches.Success, 
                "The success was unexpected.");
            Assert.AreEqual(
                3, 
                matches.Groups.Count, 
                "The number of groups was unexpected.");
            Assert.AreEqual(
                "##", 
                matches.Groups[1].Value, 
                "The heading count was unexpected.");
            Assert.AreEqual(
                string.Empty, 
                matches.Groups[2].Value, 
                "The heading text was unexpected.");
        }

        /// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
        [Test]
        public void Example040AtxHeader2()
        {
            Match matches = CommonMarkSpecification.AtxHeaderRegex.Match("#");

            Assert.AreEqual(
                true, 
                matches.Success, 
                "The success was unexpected.");
            Assert.AreEqual(
                3, 
                matches.Groups.Count, 
                "The number of groups was unexpected.");
            Assert.AreEqual(
                "#", 
                matches.Groups[1].Value, 
                "The heading count was unexpected.");
            Assert.AreEqual(
                string.Empty, 
                matches.Groups[2].Value, 
                "The heading text was unexpected.");
        }

        /// <summary>Tests the regular expressions against CommonMark 0.12 § 4.2 examples.</summary>
        [Test]
        public void Example040AtxHeader3()
        {
            Match matches =
                CommonMarkSpecification.AtxHeaderRegex.Match("### ###");

            Assert.AreEqual(
                true, 
                matches.Success, 
                "The success was unexpected.");
            Assert.AreEqual(
                3, 
                matches.Groups.Count, 
                "The number of groups was unexpected.");
            Assert.AreEqual(
                "###", 
                matches.Groups[1].Value, 
                "The heading count was unexpected.");
            Assert.AreEqual(
                string.Empty, 
                matches.Groups[2].Value, 
                "The heading text was unexpected.");
        }

        #endregion
    }
}