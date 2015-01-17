var io = require('socket.io')(8080);//websocket server
var drone = require('ar-drone');
var client = drone.createClient();//controllable aspect of drone



io.on('connection', function (socket) {//when we get a connection, presumably from the Unity client

	console.log("Unity connected");

	socket.on('message', function (data) {
		console.log(data);//command passed from unity
		handleMessage(data);//this runs the code on the drone
	});

});


function handleMessage(message){//process the message passed from the wss to this server, act accordingly

	/*
		Current messages to deal with
		As the entire message must be a string, args will be passed as such
		"command-arg1,arg2,arg3..."

		*	"takeoff"		- takes off
		*	"land"			- lands
		*	"stop"			- stops moving & rotating
		*	"move-[0-1]"	- moves at a speed from 0 to 1
		*	"turncw-[0-1]"	- moves clockwise at a speed from 0 to 1
		*	"turnccw-[0-1]"	- moves counterclockwise at a speed from 0 to 1

	*/

	var parts = message.split("-");
	var command = parts[0].toLowerCase();//first part, the command passed

	switch(command){
		case "takeoff"://for this method and the one below, we should add callbacks so that the oculus knows when it landed
			client.takeoff();
			break;
		case "land":
			client.land();
			break;
		case "stop":
			client.stop();
			break;
		case "move":
			if(parts.length<2)//not enough args...
				break;
			var speed = parseFloat(parts[1]);
			client.move(speed);
		case "turncw":
			if(parts.length<2)
				break;
			var speed = parseFloat(parts[1]);
			client.clockwise(speed);
		case "turnccw":
			if(parts.length<2)
				break;
			var speed = parseFloat(parts[1]);
			client.counterclockwise(speed);


	}

}