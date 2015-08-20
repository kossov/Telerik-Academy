var canvas = document.getElementById('the-canvas');
var ctx = canvas.getContext('2d');
ctx.strokeStyle = 'red';
ctx.lineWidth = 2;
//ctx.strokeRect(0,20,20,20);

var newX,
    newY,
    finalResult;

var snake = function snake() {
    var body;
    return {
        init: function (d, x, y) {
            body = [];
            this.direction = d;
            this.insert(x, y);
        },
        insert: function (x, y) {
            body.unshift(snakePiece(x, y));
        },
        remove: function () {
            body.pop();
        },
        getBody: function () {
            return body;
        },
        getHead: function () {
            return body[0];
        }
    }
}();

function snakePiece(x, y) {
    return {
        x: x,
        y: y
    };
}

var food = {
    x: undefined,
    y: undefined
};

function moveSnake() {
    switch (snake.direction) {
        case 'right':
            moveHorizontally('right');
            break;
        case 'left':
            moveHorizontally('left');
            break;
        case 'up':
            moveVertically('up');
            break;
        case 'down':
            moveVertically('down');
            break;
    }
    snake.insert(newX, newY);
    snake.remove();
}

function extendSnake() {
    snake.insert(snake.getHead().x, snake.getHead().y);
}

function newGame() {
    newX = 0;
    newY = 0;
    finalResult = 0;
    snake.init('right', 0, 0);
    getFoodPosition(snake.getHead().x, snake.getHead().y);
    drawFood(food.x, food.y, 10);
}

newGame();

function checkIfDead() {
    if (snake.getHead().x + 20 > canvas.width || snake.getHead().x < 0) {
        newGame();
    }
    if (snake.getHead().y + 20 > canvas.height || snake.getHead().y < 0) {
        newGame();
    }
    var i, len,
        snakeBody = snake.getBody(),
        snakePiece;
    if (snakeBody.length > 1) {
        for (i = 1, len = snakeBody.length; i < len; i += 1) {
            snakePiece = snakeBody[i];
            if (snake.getHead().x === snakePiece.x && snake.getHead().y === snakePiece.y) {
                newGame();
            }
        }
    }
}

function play() {
    drawSnake(snake, 20, 20);
    moveSnake();
    checkIfDead();
    var headCenterX = snake.getHead().x + 10,
        headCenterY = snake.getHead().y + 10,
        appleCenterX = food.x + 5,
        appleCenterY = food.y + 5,
        distance = Math.sqrt(Math.pow((headCenterX - appleCenterX), 2) + Math.pow((headCenterY - appleCenterY), 2));
    if (distance < Math.sqrt(2) * (10 + 10)) {
        extendSnake();
        finalResult += 1;
        getFoodPosition(snake.getHead().x, snake.getHead().y);
    }
    drawFood(food.x, food.y, 10);
    ctx.font = '20px bold Consolas';
    ctx.fillText('Score: ' + finalResult, 50, canvas.height - 50);
    requestAnimationFrame(play);
}
play();
//setInterval(play, 100);

function drawFood(x, y, radius) {
    ctx.beginPath();
    ctx.fillStyle = 'lime';
    ctx.arc(x, y, radius, 0, 2 * Math.PI);
    ctx.fill();
    ctx.stroke();
}

function drawSnake(snake, width, height) {

    var i,
        red = 30,
        green = 40,
        blue = 20,
        snakeBody = snake.getBody(),
        blueFlag = true,
        redFlag = true,
        greenFlag = true;

    ctx.clearRect(0, 0, canvas.width, canvas.height);
    ctx.fillStyle = 'black';

    function generateColor(color, value, flag) {
        if (flag) {
            color += value;
        } else {
            color -= value;
        }
        return color;
    }

    for (i = snakeBody.length - 1; i >= 0; i -= 1) {
        if (i === 0) {
            ctx.fillRect(snakeBody[i].x, snakeBody[i].y, width, height);
            ctx.strokeRect(snakeBody[i].x, snakeBody[i].y, width, height);
        } else {
            ctx.save();
            if (blue > 255) {
                blueFlag = false;
            } else if (blue < 0) {
                blueFlag = true;
            }
            blue = generateColor(blue, 4, blueFlag);
            if (green > 255) {
                greenFlag = false;
            } else if (green < 0) {
                greenFlag = true;
            }
            green = generateColor(green, 10, greenFlag);
            if (red > 255) {
                redFlag = false;
            } else if (red < 0) {
                redFlag = true;
            }
            red = generateColor(red, 16, redFlag);
            ctx.fillStyle = 'rgb(' + red + ',' + green + ',' + blue + ')';
            ctx.fillRect(snakeBody[i].x, snakeBody[i].y, width, height);
            ctx.restore();
        }
    }
}


function getFoodPosition(snakeX, snakeY) {
    var randomX,
        randomY,
        i,
        len,
        snakeBody = snake.getBody();
    randomX = Math.floor(Math.random() * canvas.width);
    randomY = Math.floor(Math.random() * canvas.height);
    if (randomX === snakeX || randomY === snakeY || randomX + 10 >= canvas.width || randomY + 10 >= canvas.height || randomX - 10 <= 0 || randomY - 10 <= 0) {
        getFoodPosition(snakeX, snakeY);
    } else {
        for (i = 0, len = snakeBody.length; i < len; i += 1) {
            var snakePiece = snakeBody[i];
            if (snakePiece.x === randomX || snakePiece.y === randomY) {
                getFoodPosition(snakeX, snakeY);
            }
        }
        food.x = randomX;
        food.y = randomY;
    }
}

function moveHorizontally(direction) {
    if (direction === 'right') {
        newX += 5;
    } else {
        newX -= 5;
    }
}

function moveVertically(direction) {
    if (direction === 'up') {
        newY -= 5;
    } else {
        newY += 5;
    }
}

function left() {
    if (snake.direction !== 'right') {
        snake.direction = 'left';
    }
}

function down() {
    if (snake.direction !== 'up') {
        snake.direction = 'down';
    }
}

function right() {
    if (snake.direction !== 'left') {
        snake.direction = 'right';
    }
}

function up() {
    if (snake.direction !== 'down') {
        snake.direction = 'up';
    }
}

function controls(evt) {
    switch (evt.keyCode) {
        case 27:
            alert('Game paused, press Enter or OK to resume');
            break;
        case 37:
            left();
            break;
        case 39:
            right();
            break;
        case 38:
            up();
            break;
        case 40:
            down();
            break;
    }
}

document.getElementById('start').addEventListener('click',newGame);

function docReady() {
    window.addEventListener('keydown', controls);
}
