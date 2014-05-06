<?php
// include Pusher PHP library
require_once( 'lib/Pusher.php' );

// Replace with auth information for your app
$auth_key = "";
$secret_key = "";
$app_id = "";

// read channel name and socket id from request
$channel_name = trim($_REQUEST['channel_name']);
$socket_id = trim($_REQUEST['socket_id']);

// use Pusher PHP library to generate auth signature and echo as response to client
$pusher = new Pusher( $auth_key, $secret_key, $app_id );
$auth_sig = $pusher->socket_auth( $channel_name, $socket_id );

echo $auth_sig;
