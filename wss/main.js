var io = require('socket.io')({
	transports: ['websocket'],
});

var arDrone = require('ar-drone');
var client  = arDrone.createClient();


io.attach(4567);
acount = 0;//altitude counter
pcount = 0;//pitch counter
max = 40;
var up = false;
client.setMaxListeners(100000000000000);

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
				client.back(0);
			})
			console.log("Backwards");
		}
	})

	socket.on('kill', function(){//land drone
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
