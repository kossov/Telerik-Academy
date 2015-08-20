function solve() {
    var toothpasteNames = [],
        shampooNames = [];
    var validator = {
        validateIfUndefined: function (val, name) {
            name = name || 'Value';
            if (typeof val === 'undefined') {
                throw new Error(name + ' cannot be undefined');
            }
        },
        validateIfNull: function (val, name) {
            name = name || 'Value';
            this.validateIfUndefined(val, name);
            if (val === null) {
                throw new Error(name + ' cannot be null');
            }
        },
        validateIfString: function (val, name) {
            name = name || 'Value';
            this.validateIfNull(val, name); // also checks for undefined
            if (typeof val !== 'string') {
                throw new Error(name + ' must be of type string');
            }
        },
        validateIfNumber: function (val, name) {
            name = name || 'Value';
            this.validateIfNull(val, name); // also checks for undefined
            if (typeof val !== 'number') {
                throw new Error(name + ' must be of type number');
            }
        },
        validateIfPositive: function (val, name) {
            name = name || 'Value';
            if (val <= 0) {
                throw new Error(name + ' must be greater than 0');
            }
        },
        validateProductName: function (val, name) {
            name = name || 'Value';
            this.validateIfNull(val, name); // also checks for undefined
            this.validateIfString(val, name);
            if (val.length < 3 || val.length > 10) {
                throw new Error('Product name must be between 3 and 10 symbols long!');
            }
        },
        validateBrandName: function (val, name) {
            name = name || 'Value';
            this.validateIfNull(val, name); // also checks for undefined
            this.validateIfString(val, name);
            if (val.length < 2 || val.length > 10) {
                throw new Error('Product brand must be between 2 and 10 symbols long!');
            }
        },
        validateGender: function (val, name) {
            name = name || 'Value';
            this.validateIfNull(val, name); // also checks for undefined
            if (val != '1' && val != '2' && val != '3') {
                this.validateIfString(val, name);
                val = val.toLowerCase();
                if (val !== 'men' && val !== 'women' && val !== 'unisex') {
                    throw new Error(name + ' cannot be other than 1-men, 2-women, 3-unisex');
                }
            }
        },
        validateType: function (val, name) {
            name = name || 'Value';
            this.validateIfNull(val, name); // also checks for undefined
            if (val != '1' && val != '2') {
                this.validateIfString(val, name);
                val = val.toLowerCase();
                if (val !== 'everyday' || val !== 'medical') {
                    throw new Error(name + ' cannot be other than 1-everyday, 2-medical');
                }
            }
        },
        validateIngredientsName: function (val, name) {
            name = name || 'Value';
            this.validateIfNull(val, name); // also checks for undefined
            this.validateIfString(val, name);
            if (val.length < 4 || val.length > 12) {
                throw new Error('Each ingredient must be between 4 and 12 symbols long!');
            }
        },
        validateCategoryName: function(val,name) {
            name = name || 'Value';
            this.validateIfNull(val,name);
            this.validateIfNumber(val,name);
            if(val < 2 || val > 15) {
                throw new Error(name+'must be between 2 and 15 symbols long!');
            }
        }
    };

    var category = (function () {
        var category = {
            init: function(name) {
                this.name = name;
                this.products = [];
            },

        }
    }());

    var product = (function () {
        var product = {
            init: function (name, brand, price, gender) {
                this.name = name;
                this.brand = brand;
                this.price = price;
                this.gender = gender;
                return this;
            },
            get name() {
                return this._name;
            },
            set name(val) {
                validator.validateBrandName(val, 'Product');
                this._name = val;
            },
            get brand() {
                return this._brand;
            },
            set brand(val) {
                validator.validateBrandName(val, 'Brand');
                this._brand = val;
            },
            get price() {
                return this._price;
            },
            set price(val) {
                validator.validateIfNumber(val, 'Price');
                validator.validateIfPositive(val, 'Price');
                this._price = val;
            },
            get gender() {
                return this._gender;
            },
            set gender(val) {
                validator.validateGender(val, 'Product Gender');
                this._gender = val;
            },
            print: function () {
                return '- ' + this.brand + ' - ' + this.name + ':\n' + '  * Price: $' + this.price + '\n  * For gender: ' + this.gender;
            }
        };

        return product;
    }());

    var toothpaste = (function (parent) {
        var toothpaste = Object.create(parent);

        //Object.defineProperty(toothpaste,'init', {
        //   value: function (name, brand, price, gender, ingredients) {
        //       debugger;
        //       parent.init.call(this, name, brand, price, gender);
        //       this.ingredients = ingredients;
        //       return this;
        //   }
        //});
        toothpaste.init = function (name, brand, price, gender, ingredients) {
            parent.init.call(this, name, brand, price, gender);
            this.ingredients = ingredients;
            return this;
        };

        Object.defineProperty(toothpaste, 'ingredients', {
            get: function () {
                return this._ingredients;
            },
            set: function (value) {
                validator.validateIfNull(value, 'Ingredients');
                validator.validateIfString(value, 'Ingredients');
                var ingredientsSplitted = value.split(',');
                ingredientsSplitted.forEach(function (ingredient) {
                    validator.validateIngredientsName(ingredient);
                });
                this._ingredients = ingredientsSplitted.join(', ');
            }
        });

        return toothpaste;
    }(product));

    var shampoo = (function(parent) {
        var shampoo = Object.create(parent);

        shampoo.init = function(name, brand, price, gender, milliliters, usage) {
            parent.init.call(this, name, brand, price, gender);
            this.milliliters = milliliters;
            this.usage = usage;
            this.price = this.price * this.milliliters;
            return this;
        };

        Object.defineProperty(shampoo,'milliliters', {
            get: function() {
                return this._milliliters;
            },
            set: function(val) {
                //VALIDATE
                this._milliliters = val;
            }
        });

        Object.defineProperty(shampoo,'usage',{
           get: function() {
               return this._usage;
           },
            set: function(val) {
                //VALIDATE
                this._usage = val;
            }
        });

        return shampoo;
    }(product));

    var module = {
        createToothpaste: function (name, brand, price, gender, ingredients) {
            var flag = true;
            toothpasteNames.forEach(function (toothpasteName) {
                if (toothpasteName === name) {
                    flag = false;
                }
            });
            if (flag) {
                toothpasteNames.push(name);
                return Object.create(toothpaste).init(name, brand, price, gender, ingredients);
            }
        },
        createShampoo: function (name, brand, price, gender, milliliters, usage) {
            var flag = true;
            shampooNames.forEach(function (shampooName) {
                if (shampooName === name) {
                    flag = false;
                }
            });
            if (flag) {
                shampooNames.push(name);
                return Object.create(shampoo).init(name, brand, price, gender, milliliters, usage);
            }
        },
        createCategory: function (name) {

        },
        createShoppingCart: function () {

        }
    };
    return module;
}

var cosmeticsShop = solve();
var colgateWhite = cosmeticsShop.createToothpaste('White+', 'Colgate', 15.50, 'men', 'fluor,bqla,golqma');
var headNSholders = cosmeticsShop.createShampoo('Chilled','HeadNSho',0.5,'men',500,'everyday');
console.log(headNSholders.print());
console.log(colgateWhite.print());
//console.log(colgateWhite.hasOwnProperty('_name'));

