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


		setTimeout(function(){
			client.land();
		}, 45*1000);

	});

	socket.on('rise', function(){
		//console.log("RISE");
		if(!up)
			return;
		acount++;
		if(acount > max){
			acount = 0;
			client.stop();
			client.up(0.8)
			client.after(500, function(){
				client.stop();
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
			client.stop();
			client.down(0.5)
			client.after(500, function(){
				client.stop();
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
			client.stop();
			client.front(0.5)
			client.after(300, function(){
				client.stop();
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
			client.stop();
			client.back(0.5)
			client.after(300, function(){
				client.stop();
			})
			console.log("Backwards");
		}
	})

	// socket.on('land', function(){
	// 	if(!up)
	// 		return;
	// 	client.land(function(){
	// 		up = false;
	// 	});
	// })

	
})
