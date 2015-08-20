function solve() {
    function isStringValid(string) {
        return typeof string === 'string' &&
            string.length >= 3 &&
            string.length <= 25;
    }

    var player = (function () {
        var lastId = 0,
            player = {
                init: function (name) {
                    this.id = lastId += 1;
                    this.name = name;
                    this.playlists = [];
                    return this;
                },
                get name() {
                    return this._name;
                },
                set name(name) {
                    if (!isStringValid(name)) {
                        throw new Error('Invalid name -> player');
                    }
                    this._name = name;
                },
                addPlaylist: function (playlistToAdd) {
                    if (playlistToAdd.id === undefined || playlistToAdd.name === undefined || playlistToAdd.addPlayable === undefined) {
                        throw new Error('playlistToAdd must be of type playlist');
                    }
                    this.playlists.push(playlistToAdd);
                    return this;
                },
                getPlaylistById: function (id) {
                    var i,
                        len;
                    for (i = 0, len = this.playlists.length; i < len; i += 1) {
                        if (this.playlists[i].id === id) {
                            return this.playlists[i];
                        }
                    }
                    return null;
                },
                removePlaylist: function (value) {
                    var id = value;
                    if (typeof value === 'undefined') {
                        throw new Error('undefined value -> removePlaylist');
                    }
                    if (typeof value !== 'number') {
                        if (value.id) {
                            id = value.id;
                        } else {
                            id = +value;
                        }
                    }
                    var index;
                    this.playlists.forEach(function (playlist, i) {
                        if (playlist.id === id) {
                            index = i;
                        }
                    });
                    if (typeof index === 'undefined') {
                        throw new Error('not existing playlist with that ID -> removePlaylist');
                    }
                    this.playlists.splice(index, 1);
                    return this;
                },
                listPlaylists: function (page, size) {
                    if (typeof page === 'undefined' ||
                        typeof size === 'undefined' ||
                        page * size >= this.playlists.length || page < 0 || size <= 0) {
                        throw new Error('wrong page size values -> listPlaylists');
                    }
                    this.playlists.sort(function (pl1, pl2) {
                        return pl1.name > pl2.name;
                    }).sort(function (pl1, pl2) {
                        return pl1.id - pl2.id;
                    });
                    var from = page * size,
                        to = (page + 1) * size;
                    return this.playlists.slice(from, to);
                },
                contains: function (playable, playlist) {
                    if (typeof playlist === 'undefined' ||
                        typeof playable === 'undefined' ||
                        typeof playlist.id === 'undefined' ||
                        typeof playable.id === 'undefined') {
                        throw new Error('wrong playable,playlist -> contains');
                    }
                    var result = playlist.getPlayableById(playable);
                    return result && true;
                },
                search: function (pattern) {
                    pattern = pattern.toLowerCase();
                    return this.playlists.filter(function (playlist) {
                        return playlist.getAllPlayables().some(function (playable) {
                            return playable.title.toLowerCase().indexOf(pattern) >= 0;
                        })
                    });
                }
            };

        return player;
    }());

    var playlist = (function () {
        var nextId = 0,
            playlist = {
                init: function (name) {
                    this.id = nextId += 1;
                    this.name = name;
                    this.playables = [];
                    return this;
                },
                get name() {
                    return this._name;
                },
                set name(name) {
                    if (!isStringValid(name)) {
                        throw new Error('invalid name -> playlist init');
                    }
                    this._name = name;
                },
                addPlayable: function (playableToAdd) {
                    if (playableToAdd.id === undefined) {
                        throw new Error('playableToAdd must be of type playlist');
                    }
                    this.playables.push(playableToAdd);
                    return this;
                },
                getPlayableById: function (id) {
                    var i,
                        len;
                    for (i = 0, len = this.playables.length; i < len; i += 1) {
                        if (this.playables[i].id === id) {
                            return this.playables[i];
                        }
                    }
                    return null;
                },
                removePlayable: function (value) {
                    var id = value;
                    if (typeof value === 'undefined') {
                        throw new Error('undefined value -> removePlayable');
                    }
                    if (typeof value !== 'number') {
                        if (value.id) {
                            id = value.id;
                        } else {
                            id = +value;
                        }
                    }
                    if (typeof id === 'undefined') {
                        throw new Error('Something went wrong');
                    }
                    var index;
                    this.playables.forEach(function (playable, i) {
                        if (playable.id === id) {
                            index = i;
                        }
                    });
                    if (typeof index === 'undefined') {
                        throw new Error('not existing playlist with that ID -> removePlaylist');
                    }
                    this.playables.splice(index, 1);
                    return this;
                },
                listPlayables: function (page, size) {
                    if (typeof page === 'undefined' ||
                        typeof size === 'undefined' ||
                        page * size >= this.playables.length || page < 0 || size <= 0) {
                        throw new Error('wrong page size values -> listPlayables');
                    }
                    this.playables.sort(function (pl1, pl2) {
                        return pl1.title > pl2.title;
                    }).sort(function (pl1, pl2) {
                        return pl1.id - pl2.id;
                    });
                    var from = page * size,
                        to = (page + 1) * size;
                    return this.playables.slice(from, to);
                },
                getAllPlayables: function () {
                    return this.playables.slice();
                }
            };

        return playlist;
    }());

    var playable = (function () {
        var nextId = 0,
            playable = {
                init: function (title, author) {
                    this.id = nextId += 1;
                    this.title = title;
                    this.author = author;
                    return this; // VERRRYYYYYYYYYY IMPORTANT
                },
                get title() {
                    return this._title;
                },
                set title(title) {
                    if (!isStringValid(title)) {
                        throw new Error('Invalid Title -> playable');
                    }
                    this._title = title;
                },
                get author() {
                    return this._author;
                },
                set author(author) {
                    if (!isStringValid(author)) {
                        throw new Error('Invalid Author -> playable');
                    }
                    this._author = author;
                },
                play: function () {
                    return this.id + '. ' + this.title + ' - ' + this.author;
                }
            };

        //playable.prototype.play = function () {
        //    return this.id + '. ' + this.title + ' - ' + this.author;
        //};

        return playable;
    })();

    var audio = (function (parent) {
        var audio = Object.create(parent);

        audio.init = function (title, author, length) {
            parent.init.call(this, title, author);
            this.length = length;
            return this;
        };

        Object.defineProperty(audio, 'length', {
            get: function () {
                return this._length;
            },
            set: function (length) {
                if (typeof length !== 'number') {
                    throw new Error('Length Must be of type number!');
                }
                if (length <= 0) {
                    throw new Error('Length must be greater than 0');
                }
                this._length = length;
            }
        });

        audio.play = function () {
            return parent.play.call(this) + ' - ' + this.length;
        };

        return audio;
    }(playable));

    var video = (function (parent) {
        var video = Object.create(parent);

        video.init = function (title, author, imdbRating) {
            parent.init.call(this, title, author);
            this.imdbRating = imdbRating;
            return this;
        };

        Object.defineProperty(video, 'imdbRating', {
            get: function () {
                return this._imdbRating;
            },
            set: function (imdbRating) {
                if (typeof imdbRating !== 'number') {
                    throw new Error('imdbRating Must be of type number!');
                }
                if (imdbRating < 1 || imdbRating > 5) {
                    throw new Error('imdbRating must be between 1 and 5');
                }
                this._imdbRating = imdbRating;
            }
        });

        video.play = function () {
            return parent.play.call(this) + ' - ' + this.imdbRating;
        };

        return video;
    }(playable));

    var module = {
        getPlayer: function (name) {
            return Object.create(player).init(name);
        },
        getPlaylist: function (name) {
            return Object.create(playlist).init(name);
        },
        getAudio: function (title, author, length) {
            return Object.create(audio).init(title, author, length);
        },
        getVideo: function (title, author, imdbRating) {
            return Object.create(video).init(title, author, imdbRating);
        }
    };
    return module;
}

var module = solve(),
    audio1,
    audio2,
    video1,
    video2;
audio1 = module.getAudio('Gosho','Goshev',1.13);
audio2 = module.getAudio('Ivan','Ivanov',2.2);

video1 = module.getVideo('Kosho','Koshev',1.24);
video2 = module.getVideo('Bosho','Boshev',2.64);
console.log(audio1,audio2);
console.log(video1,video2);

//module.exports = solve;
//var result = solve();
//var gotten,
//    name = 'Rock and roll',
//    plName = 'Banana Rock',
//    plAuthor = 'Wombles',
//    playlist = result.getPlaylist(name),
//    playable = {id: 1, name: plName, author: plAuthor};
//
//playlist.addPlayable(playable);
//debugger;
//playlist.removePlayable(playable);
//debugger;
//gotten = playlist.getPlayableById(1);
//console.log(gotten); // null
//playlist.addPlayable(playable);
//playlist.removePlayable(1);
//gotten = playlist.getPlayableById(1);
//console.log(gotten); // null
//playlist.removePlayable(10);

//var video = module.getVideo('Gosho','Ivanov',3.53);
//var player = module.getPlayer('John\'s Player');
//var playlist = module.getPlaylist('The BG');
//playlist.addPlayable(module.getAudio('Te sa zeleni', 'Keranov', 3.37))
//    .addPlayable(module.getAudio('Te sa cherni', 'Chernio', 45));
//player.addPlaylist(playlist);
//var idk = player.listPlaylists(0,100);
//console.log(idk);
//var playlist2 = module.getPlaylist('GOsho\' Playlist');
//playlist2.addPlayable(module.getAudio('Te sa zeleni', 'Keranov', 3.37));
//player.addPlaylist(playlist2);
//// console.log(player.listPlaylists(0, 100));
//
//console.log(player.search('cherni'));
//console.log('***********');
//console.log(player.search('te sa'));
//
////player.removePlaylist('5a');
////player.removePlaylist('5');
//console.log(player.listPlaylists(0,5));
//player.removePlaylist(playlist);
//idk = player.listPlaylists(0,1);
//console.log(idk);