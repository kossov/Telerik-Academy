/* Task Description */
/* 
 Create a function constructor for Person. Each Person must have:
 *	properties `firstname`, `lastname` and `age`
 *	firstname and lastname must always be strings between 3 and 20 characters, containing only Latin letters
 *	age must always be a number in the range 0 150
 *	the setter of age can receive a convertible-to-number value
 *	if any of the above is not met, throw Error
 *	property `fullname`
 *	the getter returns a string in the format 'FIRST_NAME LAST_NAME'
 *	the setter receives a string is the format 'FIRST_NAME LAST_NAME'
 *	it must parse it and set `firstname` and `lastname`
 *	method `introduce()` that returns a string in the format 'Hello! My name is FULL_NAME and I am AGE-years-old'
 *	all methods and properties must be attached to the prototype of the Person
 *	all methods and property setters must return this, if they are not supposed to return other value
 *	enables method-chaining
 */
function solve() {
    var Person = (function () {

        function validateName(name) {
            var validName = name.match(/[A-Za-z]+/)[0];
            if (name.length < 3 || name.length > 20 || validName.length !== name.length) {
                throw new Error();
            }
        }

        function validateAge(age) {
            if (age.toString() === '' || !Number(age)) {
                    throw new Error();
            }
            var tempAge = +age;
            if (tempAge < 0 || tempAge > 150) {
                throw new Error();
            }
        }

        function Person(firstname, lastname, age) {
            var _firstName, _lastName, _agee;
            this.firstname = firstname;
            this.lastname = lastname;
            this.age = age;
        }

        Object.defineProperty(Person.prototype, 'firstname', {
            get: function () {
                return this._firstName;
            },
            set: function (value) {
                validateName(value);
                this._firstName = value;
                return this;
            }
        });

        Object.defineProperty(Person.prototype, 'lastname', {
            get: function () {
                return this._lastName;
            },
            set: function (value) {
                validateName(value);
                this._lastName = value;
                return this;
            }
        });

        Object.defineProperty(Person.prototype, 'age', {
            get: function () {
                return this._agee;
            },
            set: function (value) {
                validateAge(value);
                this._agee = value;
                return this;
            }
        });

        Object.defineProperty(Person.prototype, 'fullname', {
            get: function () {
                return this.firstname + ' ' + this.lastname;
            },
            set: function (value) {
                var temp = value.split(' ');
                this.firstname = temp[0];
                this.lastname = temp[1];
                return this;
            }
        });

        Person.prototype.introduce = function () {
            return 'Hello! My name is ' + this.firstname + ' ' + this.lastname + ' and I am ' + this.age + '-years-old';
        };

        return Person;
    }());

    //var p = new Person('gosho','ivanov',23);
    //console.log(p);
    return Person;


}
module.exports = solve;