var io = require('socket.io')(8080);//websocket server
var drone = require('ar-drone');
var client = drone.createClient();//controllable aspect of drone