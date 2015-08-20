/* Task Description */
/* 
 * Create a module for a Telerik Academy course
 * The course has a title and presentations
 * Each presentation also has a title &&&&&&&&&&&&&&&&&&&&&&&&&&&&
 * There is a homework for each presentation &&&&&&&&&&&&&&&&&&&&
 * There is a set of students listed for the course
 * Each student has firstname, lastname and an ID
 * IDs must be unique integer numbers which are at least 1
 * Each student can submit a homework for each presentation in the course
 * Create method init
 * Accepts a string - course title
 * Accepts an array of strings - presentation titles
 * Throws if there is an invalid title
 * Titles do not start or end with spaces
 * Titles do not have consecutive spaces
 * Titles have at least one character
 * Throws if there are no presentations
 * Create method addStudent which lists a student for the course
 * Accepts a string in the format 'Firstname Lastname'
 * Throws if any of the names are not valid
 * Names start with an upper case letter
 * All other symbols in the name (if any) are lowercase letters
 * Generates a unique student ID and returns it
 * Create method getAllStudents that returns an array of students in the format:
 * {firstname: 'string', lastname: 'string', id: StudentID}
 * Create method submitHomework
 * Accepts studentID and homeworkID
 * homeworkID 1 is for the first presentation
 * homeworkID 2 is for the second one
 * ...
 * Throws if any of the IDs are invalid
 * Create method pushExamResults
 * Accepts an array of items in the format {StudentID: ..., Score: ...}
 * StudentIDs which are not listed get 0 points
 * Throw if there is an invalid StudentID
 * Throw if same StudentID is given more than once ( he tried to cheat (: )
 * Throw if Score is not a number
 * Create method getTopStudents which returns an array of the top 10 performing students
 * Array must be sorted from best to worst
 * If there are less than 10, return them all
 * The final score that is used to calculate the top performing students is done as follows:
 * 75% of the exam result
 * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
 */

function solve() {
    var Course = {
        init: function (title, presentations) {
            this.students = [];
            this.submittedHomeworks = [];
            this.listedStudents = [];
            this.title = title;
            this.presentations = presentations;
            return this;
        },
        addStudent: function (name) {
            var names = name.split(' ');
            checkStudentNames(names);
            var student = createStudent(names, this.students);
            this.students.push(student);
            return student.id;
        },
        getAllStudents: function () {
            debugger;
            return this.students.slice(); // MIGHT NEED SOMETHING EXTRA
        },
        submitHomework: function (studentID, homeworkID) {
            validateHomeworkIDs(studentID, homeworkID, this.students, this.presentations);
            if (this.submittedHomeworks[studentID] === undefined) {
                this.submittedHomeworks[studentID] = [];
            }
            var homeworkAlreadySubmitted = this.submittedHomeworks.filter(function (homework) {
                return homework === homeworkID
            });
            if (homeworkAlreadySubmitted.length === 0) {
                this.submittedHomeworks[studentID].push(homeworkID);
            }
        },
        pushExamResults: function (results) {
            /*
             * Create method pushExamResults
             * Accepts an array of items in the format {StudentID: ..., Score: ...}
             * StudentIDs which are not listed get 0 points
             * Throw if there is an invalid StudentID
             * Throw if same StudentID is given more than once ( he tried to cheat (: )
             * Throw if Score is not a number */
            var i,
                len;
            for (i = 0, len = results.length; i < len; i += 1) {
                var studentResult = results[i],
                    studentID = studentResult['StudentID'],
                    studentScore = studentResult['Score'];
                validateStudentExamResultsID(studentID,this.students);
                validateStudentExamResultsScore(studentScore);
                if(this.listedStudents[studentID]) {
                    throw new Error();
                }
                this.listedStudents[studentID] = studentScore;
            }
        },
        getTopStudents: function () {
            /* Create method getTopStudents which returns an array of the top 10 performing students
             * Array must be sorted from best to worst
             * If there are less than 10, return them all
             * The final score that is used to calculate the top performing students is done as follows:
             * 75% of the exam result
             * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
             */
            var i,
                len,
                allScores = [],
                allScoresSorted = [],
                topStudents = [];

            this.students.forEach(function(student) {
                var score = (0.75 * this.listedStudents[student.id]) + (0.25 * this.submittedHomeworks[student.id].length);
                allScores.push({id: student.id, score: score});
            });
            allScoresSorted = allScores.sort(function(prev,next) {
                return next.score - prev.score;
            });
            if(allScoresSorted.length <= 10) {
                len = allScoresSorted.length;
            } else {
                len = 10;
            }
            for(i = 0; i<len; i+=1) {
                var student = this.students.forEach(function(student) {
                    if(student.id === allScoresSorted[i].id) {
                        return student;
                    }
                });
                topStudents.push(student);
            }
            return topStudents;
        }
    };

    Object.defineProperties(Course, {
        title: {
            get: function () {
                return this._title;
            },
            set: function (value) {
                checkTitle(value);
                this._title = value;
            }
        },
        presentations: {
            get: function () {
                return this._presentations;
            },
            set: function (value) {
                if (!Array.isArray(value)) {
                    throw new Error();
                }
                if (value.length === 0) {
                    throw new Error();
                }
                value.forEach(function (title) {
                    checkTitle(title);
                });
                this._presentations = value;
            }
        }
    });

    function validateStudentExamResultsID(id,arr) {
        if(typeof id === 'string') {
            id = +id;
        }
        if(isNan(id)) {
            throw new Error();
        }
        if(id >= arr.length) {
            throw new Error();
        }
    }

    function validateStudentExamResultsScore(score) {
        if(typeof score !== 'number') {
            throw new Error();
        }
    }

    function validateHomeworkIDs(studentID, homeworkID, students, presentations) {
        //studentID = +studentID;
        //homeworkID = +homeworkID;
        if (/*typeof studentID !== 'number' || typeof homeworkID !== 'number' || */ studentID <= 0 || homeworkID <= 0) {
            throw new Error();
        }
        if (students.length < studentID || presentations.length < homeworkID) {
            throw new Error();
        }
    }

    function createStudent(names, arr) {
        var student = {};
        student.firstname = names[0];
        student.lastname = names[1];
        student.id = arr.length + 1;
        return student;
    }

    function checkTitle(title) {
        if (typeof title !== 'string') {
            throw new Error();
        }
        if (title.length !== title.trim().length) {
            throw new Error();
        }
        if (title.length === 0) {
            throw new Error();
        }
        if (title.match(/ + /g) !== null) {
            throw new Error();
        }
    }

    function checkStudentNames(names) {
        if (names.length > 2 || names.length < 2) {
            throw new Error();
        }
        if (names[0][0] !== names[0][0].toUpperCase()) {
            throw new Error();
        }
        if (names[1][0] !== names[1][0].toUpperCase()) {
            throw new Error();
        }
        names.forEach(function (name) {
            for (var i = 1; i < name.length; i += 1) {
                if (name[i] !== name[i].toLowerCase()) {
                    throw new Error();
                }
            }
        });
    }


    return Course;
}
//solve();

module.exports = solve;
