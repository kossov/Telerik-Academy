//region 1. Planar coordinates
console.log('~~1.Planar coordinates~~');

function createPoint(x, y) {
    var point = {
        x: x,
        y: y,
        toString: function () {
            return '[' + this.x + ', ' + this.y + ']';
        }

    };
    return point;
}

function createLine(beginningPoint, endingPoint) {
    var line = {
        begin: beginningPoint,
        end: endingPoint,
        getDistance: function () {
            var x = (beginningPoint.x - endingPoint.x) * (beginningPoint.x - endingPoint.x);
            var y = (beginningPoint.y - endingPoint.y) * (beginningPoint.y - endingPoint.y);

            return Math.sqrt(x + y);
        },
        toString: function () {
            return '[' + this.begin + ', ' + this.end + ']';
        }
    };
    return line;
}

function calculateDistanceBetweenPoints(pointA, pointB) {
    var x = (pointA.x - pointB.x) * (pointA.x - pointB.x);
    var y = (pointA.y - pointB.y) * (pointA.y - pointB.y);

    return Math.sqrt(x + y);
}

function canFormTriangle(a, b, c) {
    return a.getDistance() < b.getDistance() + c.getDistance() &&
        b.getDistance() < c.getDistance() + a.getDistance() &&
        c.getDistance() < a.getDistance() + b.getDistance();
}

var pointA = createPoint(2, 3),
    pointB = createPoint(5, 6),
    pointC = createPoint(3, 8),
    lineA = createLine(pointA, pointB),
    lineB = createLine(pointB, pointC),
    lineC = createLine(pointC, pointA);

console.log('pointA = ' + pointA.toString());
console.log('pointB = ' + pointB.toString());
console.log('pointC = ' + pointC.toString());
console.log('lineA = ' + lineA.toString());
console.log('lineB = ' + lineB.toString());
console.log('lineC = ' + lineC.toString());
console.log('Can form triangle from lineA, lineB and lineC? ' + canFormTriangle(lineA, lineB, lineC));

//endregion

//region 2. Remove elements
/* Write a function that removes all elements with a given value.
 Attach it to the array type.
 Read about prototype and how to attach methods.

 var arr = [1,2,1,4,1,3,4,1,111,3,2,1,'1'];
 arr.remove(1); //arr = [2,4,3,4,111,3,2,'1']; */
console.log('~~2.Remove elements~~');

Array.prototype.removeElements = function (element) {
    var i,
        len,
        tempArr = [];
    for (i = 0, len = this.length; i < len; i += 1) {
        if (this[i] === element) {
            this.splice(i, 1);
        }
    }
};

var arr = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1'];
arr.removeElements(1); //arr = [2,4,3,4,111,3,2,'1'];
console.log(arr);

//endregion

//region 3. Deep copy
/* Write a function that makes a deep copy of an object.
 The function should work for both primitive and reference types. */
console.log('~~3.Deep copy~~');

function deepCopy(obj) {
    var tempObj = {};

    if (typeof obj !== 'object') {
        return obj;
    }
    for (var prop in obj) {
        tempObj[prop] = deepCopy(obj[prop]);
    }

    return tempObj;
}

console.log(deepCopy(5));
console.log(deepCopy({name: 'Ninja', age: Infinity}));

//endregion

//region 4. Has property
/* Write a function that checks if a given object contains a given property.

 var obj  = …;
 var hasProp = hasProperty(obj, 'length'); */
console.log('~~4.Has property~~');

function hasProperty(obj, property) {
    //for (var prop in obj) {
    //    if (prop === property) {
    //        return true;
    //    }
    //}
    if (obj.hasOwnProperty(property)) {
        return true;
    } else {
        return false;
    }
}

var obj = {x: 25.6, y: 56.2};
var hasProp = hasProperty(obj, 'z');
console.log('hasProperty({x: 25.6, y: 56.2},"z") -> ' + hasProp);
console.log('hasProperty({x: 20},"x") -> ' + hasProperty({x: 20}, 'x'));
console.log('hasProperty([1,2,3],"length") -> ' + hasProperty([1, 2, 3], 'length'));

//endregion

//region 5. Youngest person
/* Write a function that finds the youngest person in a given array of people and prints his/hers full name
 Each person has properties firstname, lastname and age.

 Example:

 var people = [
 { firstname : 'Gosho', lastname: 'Petrov', age: 32 },
 { firstname : 'Bay', lastname: 'Ivan', age: 81},… ]; */
console.log('~~5.Youngest Person~~');

function Person(firstName, lastName, age) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
}

Person.prototype.fullName = function () {
    return this.firstName + ' ' + this.lastName + ' aged: ' + this.age;
};

var people = [
    new Person('Gosho', 'Petrov', 32),
    new Person('Bay', 'Ivan', 81)
];

for (var i = 0; i < people.length; i += 1) {
    console.log(people[i]);
    console.log('FullName: ' + people[i].fullName());
}

//endregion

//region 6. Unknown
/* Write a function that groups an array of people by age, first or last name.
 The function must return an associative array, with keys - the groups, and values - arrays with people in this groups
 Use function overloading (i.e. just one function)

 Example:

 var people = {…};
 var groupedByFname = group(people, 'firstname');
 var groupedByAge= group(people, 'age'); */
console.log('~~6.Unknown~~');

function group(people, groups) {
    var result = [];

    result[groups] = people;

    return result;
}

var morePeople = [
    {firstname: 'Gosho', lastname: 'Goshev', age: 21},
    {firstname: 'Mariika', lastname: 'Mariicheva', age: 18}];

var groupedByFname = group(morePeople, 'firstname');
var groupedByAge = group(morePeople, 'age');

var groupedPeople = [
    groupedByFname,
    groupedByAge
];

groups = ['firstname', 'lastname', 'age'];

for (var i = 0; i < groups.length; i += 1) {
    console.log('Grouped by:' + groups[i]);
    for(var j = 0; j<groupedPeople.length; j+=1) {
        if(typeof groupedPeople[j][groups[i]]=== 'undefined') {
            continue;
        } else {
            console.log(groupedPeople[j][groups[i]]);
        }
    }
}
//endregion