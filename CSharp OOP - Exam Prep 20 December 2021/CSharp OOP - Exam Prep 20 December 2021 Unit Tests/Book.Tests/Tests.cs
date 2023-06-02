namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void Book_ConstructorShouldWorkProperly()
        {
            string expectedBookName = "book";
            string expectedAuthor = "james";
            Book book = new Book(expectedBookName, expectedAuthor);
            Assert.AreEqual(expectedBookName, book.BookName);
            Assert.AreEqual(expectedAuthor, book.Author);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Book_PropertyBookNameShouldThrowExceptionWhenIsNullOrEmpty(string bookName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(bookName, "james");
            });
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Book_PropertyAuthorShouldThrowExceptionWhenIsNullOrEmpty(string author)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("book", author);
            });
        }

        [Test]
        public void Book_MethodAddFootnoteShouldWorkProperly()
        {
            Book book = new Book("book", "james");
            int initialFootnoteCount = book.FootnoteCount;
            book.AddFootnote(3, "footnote 3");
            Assert.AreEqual(initialFootnoteCount + 1, book.FootnoteCount);
        }

        [Test]
        public void Book_MethodAddFootnoteShouldThrowExceptionWhenFootnoteAlreadyExists()
        {
            Book book = new Book("book", "james");
            book.AddFootnote(3, "footnote 3");
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(3, "footnote 3");
            });
        }

        [Test]
        public void Book_MethodFindFootnoteShouldWorkProperly()
        {
            Book book = new Book("book", "james");
            book.AddFootnote(3, "footnote 3");
            string expectedText = "Footnote #3: footnote 3";
            Assert.AreEqual(expectedText, book.FindFootnote(3));
        }

        [Test]
        public void Book_MethodFindFootnoteShouldThrowExceptionWhenFootnoteDoesNotExist()
        {
            Book book = new Book("book", "james");
            book.AddFootnote(3, "footnote 3");
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(32);
            });
        }

        [Test]
        public void Book_MethodAlterFootnoteShouldWorkProperly()
        {
            Book book = new Book("book", "james");
            book.AddFootnote(3, "footnote 3");
            string alteredText = "new footnote 3";
            book.AlterFootnote(3, alteredText);
            string resultAfterAlter = "Footnote #3: new footnote 3";
            Assert.AreEqual(resultAfterAlter, book.FindFootnote(3));
        }

        [Test]
        public void Book_MethodAlterFootnoteShouldThrowExceptionWhenFootnoteDoesNotExist()
        {
            Book book = new Book("book", "james");
            book.AddFootnote(3, "footnote 3");
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(23,"some text");
            });
        }
    }
}