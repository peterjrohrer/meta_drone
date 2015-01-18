var io = require('socket.io')({
	transports: ['websocket'],
});

var arDrone = require('ar-drone');
var client  = arDrone.createClient();
console.log("Server started");

io.attach(4567);
acount = 0;//altitude counter
pcount = 0;//pitch counter
ycount = 0;
max = 40;
killed = false;
var up = true;
client.setMaxListeners(100000000000000);

process.on('SIGINT', function(){
	console.log("land");
	client.land(function(){
		process.exit(0);
	})
	
})

io.on('connection', function(socket){
	console.log("CONNECTED");

	client.takeoff(function(){
		up = true;
		console.log("Taken off")

		setTimeout(function(){
			client.land();
			console.log("Landed");
		}, 45*1000);

	});

	socket.on('rise', function(){
		//console.log("RISE");
		if(!up)
			return;
		acount++;
		if(acount > max){
			acount = 0;
			client.up(0.8)
			client.after(500, function(){
				if(up)
					client.up(0);
			})
			console.log("Rise");
		}
	})

	socket.on('fall', function(){
		//console.log("RISE");
		if(!up)
			return;
		acount++;
		if(acount > max){
			acount = 0;
			client.down(0.5)
			client.after(500, function(){
				if(up)
					client.down(0);
			})
			console.log("Fall");
		}
	})


	socket.on('forwards', function(){
		//console.log("RISE");
		if(!up)
			return;
		pcount++;
		if(pcount > max){
			pcount = 0;
			client.front(0.2)
			client.after(200, function(){
				if(up)
					client.front(0);
			})
			console.log("Forwards");
		}
	})

	socket.on('backwards', function(){
		//console.log("RISE");
		if(!up)
			return;
		pcount++;
		if(pcount > max){
			pcount = 0;
			client.back(0.2)
			client.after(200, function(){
				if(up)
					client.back(0);
			})
			console.log("Backwards");
		}
	})

	socket.on('right', function(){
		//console.log("RISE");
		if(!up)
			return;
		ycount++;
		if(ycount > max){
			ycount = 0;
			client.clockwise(0.2)
			client.after(200, function(){
				if(up)
					client.clockwise(0);
			})
			console.log("Right");
		}
	})

	socket.on('left', function(){
		//console.log("RISE");
		if(!up)
			return;
		ycount++;
		if(ycount > max){
			ycount = 0;
			client.counterClockwise(0.2)
			client.after(200, function(){
				if(up)
					client.counterClockwise(0);
			})
			console.log("Left");
		}
	})

	socket.on('kill', function(){//land drone
		if(killed){//already triggered this...
			return;
		}
		up = false;//this is so the other methods don't fire...
		killed = true;
		console.log("KILL");
		client.stop();

		client.land(function(){
			console.log("Landed");
		});


	})

	socket.on('disconnect', function(){
		client.stop();
		client.land();
		console.log("Disconnected");
	})

	// socket.on('land', function(){
	// 	if(!up)
	// 		return;
	// 	client.land(function(){
	// 		up = false;
	// 	});
	// })

	
})
