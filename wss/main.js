var io = require('socket.io')({
	transports: ['websocket'],
});

io.attach(4567);

io.on('connection', function(socket){
	console.log("CONNECTED");
	socket.on('beep', function(){
		socket.emit('boop');
	});
	socket.on('message',function(d){
		console.log("Received message",d)
	})
})
