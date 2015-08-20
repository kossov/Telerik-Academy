/* Task Description */
/*
 * Create an object domElement, that has the following properties and methods:
 * use prototypal inheritance, without function constructors
 * method init() that gets the domElement type
 * i.e. `Object.create(domElement).init('div')`
 * property type that is the type of the domElement
 * a valid type is any non-empty string that contains only Latin letters and digits
 * property innerHTML of type string
 * gets the domElement, parsed as valid HTML
 * <type attr1="value1" attr2="value2" ...> .. content / children's.innerHTML .. </type>
 * property content of type string
 * sets the content of the element
 * works only if there are no children
 * property attributes
 * each attribute has name and value
 * a valid attribute has a non-empty string for a name that contains only Latin letters and digits or dashes (-)
 * property children
 * each child is a domElement or a string
 * property parent
 * parent is a domElement
 * method appendChild(domElement / string)
 * appends to the end of children list
 * method addAttribute(name, value)
 * throw Error if type is not valid
 * method removeAttribute(attribute)
 * throw Error if attribute does not exist in the domElement
 */


/* Example

 var meta = Object.create(domElement)
 .init('meta')
 .addAttribute('charset', 'utf-8');

 var head = Object.create(domElement)
 .init('head')
 .appendChild(meta)

 var div = Object.create(domElement)
 .init('div')
 .addAttribute('style', 'font-size: 42px');

 div.content = 'Hello, world!';

 var body = Object.create(domElement)
 .init('body')
 .appendChild(div)
 .addAttribute('id', 'cuki')
 .addAttribute('bgcolor', '#012345');

 var root = Object.create(domElement)
 .init('html')
 .appendChild(head)
 .appendChild(body);

 console.log(root.innerHTML);
 Outputs:
 <html><head><meta charset="utf-8"></meta></head><body bgcolor="#012345" id="cuki"><div style="font-size: 42px">Hello, world!</div></body></html>
 */


function solve() {
    var domElement = (function () {
        var domElement = {
            init: function (type) {
                this.children = [];
                this.attributes = [];
                this.type = type;
                return this;
            },
            appendChild: function (child) {
                if (typeof child.type === 'undefined' && typeof child !== 'string') {
                    throw new Error();
                }
                Array.prototype.push.call(this.children, child);
                child.parent = this;
                return this
            },
            addAttribute: function (name, value) {
                var validName = name.match(/[A-Za-z0-9-]+/)[0];
                if (name.length === 0 || name.length !== validName.length) {
                    throw new Error();
                }
                this.attributes[name] = value;
                if (this.attributes.indexOf(name) === -1) {
                    this.attributes.push(name);
                }
                return this;
            },
            removeAttribute: function (attribute) {
                if (!this.attributes[attribute]) {
                    throw new Error();
                } else {
                    this.attributes.splice(this.attributes.indexOf(attribute), 1);
                    return this;
                }
            }
        };

        Object.defineProperty(domElement, 'children', {
            get: function () {
                return this._children;
            },
            set: function (value) {
                this._children = value;
            }
        });

        Object.defineProperty(domElement, 'attributes', {
            get: function () {
                return this._attributes;
            },
            set: function (value) {
                this._attributes = value;
            }
        });

        Object.defineProperty(domElement, 'parent', {
            get: function () {
                return this._parent;
            },
            set: function (value) {
                this._parent = value;
            }
        });

        Object.defineProperty(domElement, 'content', {
            get: function () {
                return this._content;
            },
            set: function (value) {
                if (this.children.length === 0) {
                    this._content = value;
                }
            }
        });

        Object.defineProperty(domElement, 'innerHTML', {
            get: function () {
                var result = '<' + this.type;
                result += findAttributes(this);

                if (this.children.length > 0) {
                    var i,
                        len = this.children.length,
                        child;
                    for (i = 0; i < len; i += 1) {
                        if (typeof this.children[i] === 'string') {
                            result += this.children[i];
                        } else {
                            child = this.children[i];
                            if(typeof child === 'string') {
                                result += child;
                            } else {
                                result += child.innerHTML;
                            }
                        }
                    }

                }
                if (this.content) {
                    result += this.content;
                }

                return result + '</' + this.type + '>';
            }
        });

        Object.defineProperty(domElement, 'type', {
            get: function () {
                return this._type;
            },
            set: function (value) {
                throwIfInvalidType(value);
                this._type = value;
            }
        });

        function throwIfInvalidType(type) {
            if (typeof type === 'undefined' || type.length === 0) {
                throw new Error();
            }
            var validType = type.match(/[A-Za-z0-9]+/)[0];
            if (type.length !== validType.length) {
                throw new Error();
            }
        }

        function findAttributes(object) {
            var result = '';
            if (object.attributes && object.attributes.length > 0) {
                object.attributes.sort();
                var tempAttributes = object.attributes;
                tempAttributes.forEach(function (attribute) {
                    result += ' ' + attribute + '="';
                    result += tempAttributes[attribute] + '"'
                });
                result += '>';
            } else {
                result += '>';
            }
            return result;
        }

        return domElement;
    }());
    return domElement;
}

module.exports = solve;
