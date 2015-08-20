function Solve() {
    var module = (function () {
        function getSortingFunction(firstParameter, secondParameter) { // .sort(getSortingFunction('name', 'id'))
            return function (first, second) {
                if (first[firstParameter] < second[firstParameter]) {
                    return -1;
                }
                else if (first[firstParameter] > second[firstParameter]) {
                    return 1;
                }

                if (first[secondParameter] < second[secondParameter]) {
                    return -1;
                }
                else if (first[secondParameter] > second[secondParameter]) {
                    return 1;
                }
                else {
                    return 0;
                }
            }
        }

        validator = {
            validateIfUndefined: function (val, name) {
                var flag = true;
                name = name || 'Value';
                if (val === undefined) {
                    flag = false;
                    throw new Error(name + ' cannot be undefined');
                }
                return flag;
            },
            validateIfObject: function (val, name) {
                name = name || 'Value';
                if (typeof val !== 'object') {
                    throw new Error(name + ' must be an object');
                }
            },
            validateIfNumber: function (val, name) {
                name = name || 'Value';
                if (typeof val !== 'number') {
                    throw new Error(name + ' must be a number');
                }
            },
            validateString: function (val, name) {
                name = name || 'Value';
                this.validateIfUndefined(val, name);

                if (typeof val !== 'string') {
                    throw new Error(name + ' must be a string');
                }
            },
            validatePositiveNumber: function (val, name) {
                name = name || 'Value';
                this.validateIfUndefined(val, name);
                this.validateIfNumber(val, name);

                if (val <= 0) {
                    throw new Error(name + ' must be positive number');
                }
            },
            validateId: function (id) {
                var flag = this.validateIfUndefined(id, 'Object id');
                if (typeof id !== 'number') {
                    flag = false;
                    throw new Error('Object id must be a number');
                }
                return flag;
            },
            validateItemDescription: function (val, name) {
                name = name || 'Value';
                this.validateString(val, name);
                if (val.length === 0) {
                    throw new Error(name + ' cannot be an empty string');
                }
            },
            validateName: function (val, name) {
                name = name || 'Value';
                this.validateString(val, name);
                if (val.length < 2 || val.length > 40) {
                    throw new Error(name + ' must be between 2 and 40'); // MIGHT BE <= 2 || >= 40
                }
            },
            validateBookIsbn: function (val, name) {
                name = name || 'Value';
                this.validateString(val, name);
                var isbnOnlyDigits = val.match(/([0-9])+/g)[0];
                if (val.length !== 10 && val.length !== 13) {
                    throw new Error(name + ' length must be exactly 10 or 13');
                }
                if (isbnOnlyDigits.length !== val.length) {
                    throw new Error(name + ' can contain only digits');
                }
            },
            validateBookGenre: function (val, name) {
                name = name || 'Value';
                this.validateString(val, name);
                if (val.length < 2 || val.length > 20) {
                    throw new Error(name + ' must be between 2 and 20');
                }
            },
            validateMediaRating: function (val, name) {
                name = name || 'Value';
                this.validateIfUndefined(val, name);
                this.validateIfNumber(val, name);
                if (val < 1 || val > 5) {
                    throw new Error(name + ' must be between 1 and 5 inclusive');
                }
            },
            validateArrayToAdd: function (val, prototypeParent, name) {
                var flag = true;
                if (val.length === 0) {
                    flag = false;
                    throw new Error(name + ' must have atleast 1 argument');
                }
                val.forEach(function (item) {
                    if (!prototypeParent.isPrototypeOf(item)) {
                        if (!item.hasOwnProperty('id') && !item.hasOwnProperty('description') && !item.hasOwnProperty('name')) {
                            flag = false;
                            throw new Error(name + ' must be an ' + prototypeParent + ' instance or an ' + prototypeParent + '-like object');
                        } else {
                            if (!this.validateId(item.id) || !this.validateItemDescription(item.description) || !this.validateName(item.name)) {
                                flag = false;
                                throw new Error(name + '\'s item has wrong id or description or name')
                            }
                        }
                    }
                });

                return flag;
            },
            validatePattern: function (pattern, name) {
                name = name || 'Value';
                this.validateString(pattern, name);
                if (pattern.length < 1) {
                    throw new Error(name + ' must have atleast 1 character');
                }
            },
            validateCount: function(val,name) {
                name = name || 'Value';
                this.validateIfNumber(val,name);
                if(val < 1) {
                    throw new Error(name + ' cannot be less than 1');
                }
            }
        };

        function makeAllLettersToLower(searchTerm) {
            var result = '',
                i,
                len;
            for (i = 0, len = searchTerm.length; i < len; i += 1) {
                result += searchTerm[i].toLowerCase();
            }
            return result;
        }

        var item = (function () {
            var currentId = 0,
                item = {
                    init: function (name, description) {
                        this._id = currentId += 1;
                        this.description = description;
                        this.name = name;
                        return this;
                    },
                    get id() {
                        return this._id;
                    },
                    get description() {
                        return this._description;
                    },
                    set description(val) {
                        validator.validateItemDescription(val, 'Item description');
                        this._description = val;
                    },
                    get name() {
                        return this._name;
                    },
                    set name(val) {
                        validator.validateName(val, 'Item name');
                        this._name = val;
                    }
                };
            return item;
        }());

        var book = (function (parent) {
            var book = Object.create(parent);

            book.init = function (name, isbn, genre, description) {
                parent.init.call(this, name, description);
                this.isbn = isbn;
                this.genre = genre;
                return this;
            };

            Object.defineProperty(book, 'isbn', {
                get: function () {
                    return this._isbn;
                },
                set: function (val) {
                    validator.validateBookIsbn(val, 'Book ISBN');
                    this._isbn = val;
                }
            });

            Object.defineProperty(book, 'genre', {
                get: function () {
                    return this._genre;
                },
                set: function (val) {
                    validator.validateBookGenre(val, 'Book Genre');
                    this._genre = val;
                }
            });

            return book;
        }(item));

        var media = (function (parent) {
            var media = Object.create(parent);

            media.init = function (name, rating, duration, description) {
                parent.init.call(this, name, description);
                this.duration = duration;
                this.rating = rating;
                return this;
            };

            Object.defineProperty(media, 'duration', {
                get: function () {
                    return this._duration;
                },
                set: function (val) {
                    validator.validatePositiveNumber(val, 'Media Duration');
                    this._duration = val;
                }
            });

            Object.defineProperty(media, 'rating', {
                get: function () {
                    return this._rating;
                },
                set: function (val) {
                    validator.validateMediaRating(val, 'Media Rating');
                    this._rating = val;
                }
            });

            return media;
        }(item));

        var catalog = (function () {
            var nextCatalogId = 0,
                catalog = {
                    init: function (name) {
                        this._id = nextCatalogId += 1;
                        this.name = name;
                        this.items = [];
                        return this;
                    },
                    get id() {
                        return this._id;
                    },
                    get name() {
                        return this._name;
                    },
                    set name(val) {
                        validator.validateName(val, 'Catalog Name');
                        this._name = val;
                    },
                    add: function (toBeInstanceOf, whichCatalog) {
                        var val = Array.prototype.slice.call(arguments);
                        if (val.length === 3 && Array.isArray(val[2])) {
                            val = val[2];
                        } else {
                            val = val.splice(2);
                        }
                        var toBeAdded = validator.validateArrayToAdd(val, toBeInstanceOf, 'Catalog ' + whichCatalog + ' Add');
                        if (toBeAdded) {
                            for(var j = 0,lent = val.length; j<lent; j+=1) {
                                this.items.push(val[j]);
                            }
                            //val.forEach(function (item) {
                            //    this.items.push(item);
                            //});
                        }
                    },
                    find: function (val) {
                        var id,
                            name,
                            genre,
                            result = [];
                        if (typeof val === 'object') {
                            var keys = Object.keys(val);
                            keys.forEach(function (key) {
                                if (key === 'id') {
                                    id = val.id;
                                } else if (key === 'name') {
                                    name = makeAllLettersToLower(val.name);
                                } else if (key === 'genre') {
                                    genre = makeAllLettersToLower(val.genre);
                                }
                            });
                        } else {
                            validator.validateId(val);
                            id = val;
                        }
                        if (name === undefined && genre === undefined) {
                            this.items.forEach(function (item) {
                                if (item.id === id) {
                                    result.push(item);
                                }
                            });
                        } else {
                            if(name !== undefined && genre !== undefined && id !== undefined) {
                                this.items.forEach(function (item) {
                                    var itemName = makeAllLettersToLower(item.name),
                                        itemGenre = makeAllLettersToLower(item.genre);
                                    if (itemName === name && item.id === id && itemGenre === genre) {
                                        result.push(item);
                                    }
                                });
                            } else if (name !== undefined && genre === undefined && id === undefined) {
                                this.items.forEach(function (item) {
                                    var itemName = makeAllLettersToLower(item.name);
                                    if (itemName === name) {
                                        result.push(item);
                                    }
                                });
                            } else if (genre !== undefined && name === undefined && id === undefined) {
                                this.items.forEach(function (item) {
                                    var itemGenre = makeAllLettersToLower(item.genre);
                                    if (itemGenre === genre) {
                                        result.push(item);
                                    }
                                });
                            } else if (genre !== undefined && id !== undefined && name === undefined) {
                                this.items.forEach(function (item) {
                                    var itemGenre = makeAllLettersToLower(item.genre);
                                    if (itemGenre === genre && item.id === id) {
                                        result.push(item);
                                    }
                                });
                            } else if (name !== undefined && id !== undefined && genre === undefined) {
                                this.items.forEach(function (item) {
                                    var itemName = makeAllLettersToLower(item.name);
                                    if (itemName === name && item.id === id) {
                                        result.push(item);
                                    }
                                });
                            }
                        }

                        if (typeof val === 'object') { // if is an object return result whether or not it is an empty string
                            return result;
                        } else {
                            if (result.length === 0) {
                                return null;
                            } else {
                                return result[0]; // gets the first element found with this id
                            }
                        }
                    },
                    search: function (pattern) {
                        validator.validatePattern(pattern, 'Pattern');
                        var result = [],
                            i,
                            len,
                            lowerCasePattern = makeAllLettersToLower(pattern);
                        this.items.forEach(function (item) {
                            var itemName = makeAllLettersToLower(item.name),
                                itemDescription = makeAllLettersToLower(item.description);
                            if (itemName.indexOf(lowerCasePattern) >= 0 || itemDescription.indexOf(lowerCasePattern) >= 0) {
                                result.push(item);
                            }
                        });
                        return result;
                    }
                };
            return catalog;
        }());

        var bookCatalog = (function (parent) {
            var bookCatalog = Object.create(parent);

            bookCatalog.init = function (name) {
                parent.init.call(this, name);
                return this;
            };

            bookCatalog.add = function (elements) {
                parent.add.call(this, book, 'Book', elements);
            };

            bookCatalog.getGenres = function () {
                var lowerCaseUniqueGenres = [];
                this.items.forEach(function(item) {
                    var lowerCaseItemGenre = makeAllLettersToLower(item.genre),
                        shouldGenreBeAdded = true;
                    lowerCaseUniqueGenres.forEach(function(genre) {
                        if(genre === lowerCaseItemGenre) {
                            shouldGenreBeAdded = false;
                        }
                    });
                    if(shouldGenreBeAdded) {
                        lowerCaseUniqueGenres.push(lowerCaseItemGenre);
                    }
                });
                return lowerCaseUniqueGenres;
            };

            bookCatalog.find = function(options) {
                return parent.find.call(this,options);
            };

            return bookCatalog
        }(catalog));

        var mediaCatalog = (function(parent) {
            var mediaCatalog = Object.create(parent);

            mediaCatalog.init = function (name) {
                parent.init.call(this, name);
                return this;
            };

            mediaCatalog.add = function (elements) {
                parent.add.call(this, media, 'Media', elements);
            };

            mediaCatalog.getTop = function (count) {
                var i,
                    result;
                validator.validateCount(count,'MediaCatalog getTop count');
                var sortedMediaByRating = this.items.sort(function(item1,item2) {
                    return item2.rating - item1.rating;
                });
                result = sortedMediaByRating.slice(0,count).map(function(item) {
                    return {
                        id: item.id,
                        name: item.name
                    };
                });
                return result;
            };

            mediaCatalog.getSortedByDuration = function () {
                var result = this.items.sort(function(item1,item2) {
                    return item2.duration - item1.duration;
                }).sort(function(item1,item2) {
                   return item1.id - item2.id;
                });
                return result;
            };

            return mediaCatalog;
        }(catalog));

        return {
            getBook: function (name, isbn, genre, description) {
                return Object.create(book).init(name, isbn, genre, description);
            },
            getMedia: function (name, rating, duration, description) {
                return Object.create(media).init(name, rating, duration, description);
            },
            getBookCatalog: function (name) {
                return Object.create(bookCatalog).init(name);
            },
            getMediaCatalog: function (name) {
                return Object.create(mediaCatalog).init(name);
            }
        };
    }());

    return module;
}

var module = Solve();
//var book1 = module.getBook('The secrets of the JavaScript Ninja', '1234567890', 'IT', 'A book about JavaScript');
//var book2 = module.getBook('JavaScript: The Good Parts', '0123456789', 'IT', 'A good book about JS');
//var media1 = module.getMedia('The secrets of the JavaScript Ninja', 4, 5, 'A video about JavaScript');
//var media2 = module.getMedia('The secrets of the JavaScript Ninja2', 3.5, 2.1, 'A video about JavaScript');

var catalog = module.getBookCatalog('John\'s catalog');

var book1 = module.getBook('The secrets of the JavaScript Ninja', '1234567890', 'IT', 'A book about JavaScript');
var book2 = module.getBook('JavaScript: The Good Parts', '0123456789', 'IT', 'A good book about JS');
catalog.add([book1,book2]);
console.log(catalog.find(book1.id));
////returns book1
//
//console.log(catalog.find({id: book2.id, genre: 'IT'}));
////returns book2
//
//console.log(catalog.search('js'));
//// returns book2
//
//console.log(catalog.search('javascript'));
////returns book1 and book2
//
//console.log(catalog.search('Te sa zeleni'));
////returns []
var mediaCatalog = module.getMediaCatalog('My mediacatalog');
var media1 = module.getMedia('id1 duration5', 4.3, 5, 'A book about JavaScript');
var media2 = module.getMedia('id2 duration10', 5, 10, 'A book about JavaScript');
mediaCatalog.add([media1,media2]);
console.log(mediaCatalog.getTop(3));
console.log(mediaCatalog.getSortedByDuration());