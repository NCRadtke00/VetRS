var pusher = new Pusher('a8e8c58dc5d53b967a82', {
    cluster: 'us3',
    encrypted: true
});

var channel = pusher.subscribe('my-channel');
channel.bind('my-event', function (data) {
    reloadGroup();
});