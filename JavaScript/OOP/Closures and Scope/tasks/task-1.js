/* Task Description */
/* 
 *	Create a module for working with books
 *	The module must provide the following functionalities:
 *	Add a new book to category
 *	Each book has unique title, author and ISBN
 *	It must return the newly created book with assigned ID
 *	If the category is missing, it must be automatically created
 *	List all books
 *	Books are sorted by ID
 *	This can be done by author, by category or all
 *	List all categories
 *	Categories are sorted by ID
 *	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
 *	When adding a book/category, the ID is generated automatically
 *	Add validation everywhere, where possible
 *	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
 *	Author is any non-empty string
 *	Unique params are Book title and Book ISBN
 *	Book ISBN is an unique code that contains either 10 or 13 digits
 *	If something is not valid - throw Error
 */
//

function solve() {
    var library = (function () {
        var books = [];
        var categories = [];

        function listBooks(obj) {
            var result = [];
            if (arguments.length > 0) {
                if (typeof obj.category !== 'undefined') {
                    books.forEach(function (book) {
                        if (book.category === obj.category) {
                            result.push(book);
                        }
                    });
                    return result;
                }
                if (typeof obj.author !== 'undefined') {
                    books.forEach(function (book) {
                        if (book.author === obj.author) {
                            result.push(book);
                        }
                    });
                    return result;
                }
            }
            return books.slice();
        }

        function addBook(book) {
            books.forEach(function (existingBook) {
                if (book.title === existingBook.title ||
                    book.isbn === existingBook.isbn) {
                    throw new Error();
                }
            });
            if (!book.category) {
                book.category = 'unknown';
            }
            if (book.title.length < 2 || book.title.length > 100) {
                throw new Error();
            }
            if (book.author.trim().length === 0 || typeof book.author !== 'string') {
                throw new Error();
            }
            var isbn = book.isbn + '';
            if (isbn.length !== 10 && isbn.length !== 13) {
                throw new Error();
            }
            book.ID = books.length + 1;
            books.push(book);
            addCategory(book.category);
            return book;
        }

        function listCategories() { // must take only names
            return categories.slice().map(function (category) {
                return category.name;
            });
        }

        function addCategory(categoryName) {
            var shouldAddCategory = true;
            categories.forEach(function (existingCategory) {
                if (categoryName === existingCategory.name) {
                    shouldAddCategory = false;
                }
            });
            if (categoryName.length < 2 || categoryName.length > 100) {
                shouldAddCategory = false;
            }
            if (shouldAddCategory) {
                var category = {
                    ID: categories.length + 1,
                    name: categoryName
                };
                categories.push(category);
            }
            return category;
        }

        return {
            books: {
                list: listBooks,
                add: addBook
            },
            categories: {
                list: listCategories,
                add: addCategory
            }
        };
    }());
    return library;
}
module.exports = solve;
