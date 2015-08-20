//region 1. Make person
/* Write a function for creating people.
 Each person must have firstname, lastname, age and gender (true is female, false is male)
 Generate an array with ten person with different names, ages and genders */
console.log('~~1.Make person~~');

var people = Array.apply(null, Array(10));

people = people.map(function (_, index) {
    var fName = 'firstName' + index,
        lName = 'lastName' + index,
        age = 15 + index,
        gender = !!(index % 2) === true ? 'female' : 'male';
    return {
        fName: fName,
        lName: lName,
        age: age,
        gender: gender
    }
});

people.forEach(function (person) {
    console.log(person)
});
//endregion

//region 2. People of age
/* Write a function that checks if an array of person contains only people of age (with age 18 or greater)
 Use only array methods and no regular loops (for, while) */
console.log('~~2.People of age~~');

var people18OrGreater = people.every(function (person) {
    return person.age >= 18;
});

people.forEach(function (person, index) {
    console.log('person' + index + ' age:' + person.age);
});
console.log('all are above 18 -> ' + people18OrGreater);

//endregion

//region 3. Underage people
/* Write a function that prints all underaged persons of an array of person
 Use Array#filter and Array#forEach
 Use only array methods and no regular loops (for, while) */
console.log('3.Underage people~~');
var underagedPeople = people.filter(function (person) {
    return person.age < 18;
});

underagedPeople.forEach(function (person) {
    console.log(person);
});
//endregion

//region 4. Average age of females
/* Write a function that calculates the average age of all females, extracted from an array of persons
 Use Array#filter
 Use only array methods and no regular loops (for, while) */
console.log('~~4.Average age of females~~');

var femalePeople = people.filter(function (person) {
        return person.gender === 'female';
    }),
    sumOfFemaleAges = femalePeople.reduce(function (sum, person) {
        return sum += person.age;
    }, 0);

console.log(sumOfFemaleAges / femalePeople.length);

//endregion

//region 5. Youngest Person
/* Write a function that finds the youngest male person in a given array of people and prints his full name
 Use only array methods and no regular loops (for, while)
 Use Array#find */
console.log('~~5.Youngest person~~');

if (!Array.prototype.find) {
    Array.prototype.find = function (callback) {
        var i,
            len;
        for (i = 0, len = this.length; i < len; i += 1) {
            if (callback(this[i], i, this)) {
                return this[i];
            } else {
                return undefined;
            }
        }
    }
}

var youngestMalePerson = people.filter(function (person) {
    return person.gender === 'male';
}).find(function (person) {
    return person.age;
});
console.log(people.filter(function (person) {
    return person.gender === 'male';
}));
console.log(youngestMalePerson);

//endregion

//region 6. Group people
/* Write a function that groups an array of persons by first letter of first name and returns the groups as a JavaScript Object
 Use Array#reduce
 Use only array methods and no regular loops (for, while)
 Example:

 result = {
 'a': [{
 firstname: 'Asen',
 /* ... */ /*
}, {
    firstname: 'Anakonda',
    /* ... */ /*
}],
'j': [{
    firstname: 'John',
    /* ... */ /*
}]
}; */
console.log('~~6.Group people~~');

var morePeople = [
    {
        firstName: 'Asen'
    }, {
        firstName: 'Anakonda'
    }, {
        firstName: 'John'
    }, {
        firstName: 'Joni'
    }
];

var groupedByFName = morePeople.reduce(function(group, person) {
    var firstLetter = person.firstName[0];
    if(group[firstLetter]) {
        group[firstLetter].push(person);
    } else {
        group[firstLetter] = [person];
    }
    return group;
}, {});

console.log(groupedByFName);

//endregion