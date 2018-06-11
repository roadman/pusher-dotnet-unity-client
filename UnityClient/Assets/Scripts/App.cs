using UnityEngine;
using System.Collections;

public class App : MonoBehaviour {
	// isntance of pusher client
	PusherClient.Pusher pusherClient = null;
	PusherClient.Channel pusherChannel = null;

	// Initialize
	void Start () {
		// TODO: Replace these with your app values
		PusherSettings.Verbose = true;
		PusherSettings.AppKey  = "KEY";
		PusherSettings.Host    = "HOST";   // ws-[CLUSTER].pusher.com

		pusherClient = new PusherClient.Pusher();
		pusherClient.Connected += HandleConnected;
		pusherClient.ConnectionStateChanged += HandleConnectionStateChanged;
		pusherClient.Connect();
	}

	void HandleConnected (object sender) {
		Debug.Log ( "Pusher client connected, now subscribing to private channel" );
		pusherChannel = pusherClient.Subscribe( "my-channel" );
		pusherChannel.BindAll( HandleChannelEvent );
	}

	void OnDestroy() {
		if( pusherClient != null )
			pusherClient.Disconnect();
	}

	void HandleChannelEvent( string eventName, object evData ) {
		Debug.Log ( "Received event on channel, event name: " + eventName + ", data: " + JsonHelper.Serialize(evData) );
	}

	void HandleConnectionStateChanged (object sender, PusherClient.ConnectionState state) {
		Debug.Log ( "Pusher connection state changed to: " + state );
	}
}
