using UnityEngine;
using System.Collections;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using System;
using UnityEngine.UI;

public class mqttTest : MonoBehaviour {
	public string soso;
	public Text che;
	public Text temp;
	public Text hum;
	public Text light;
	public Text mov;
	public Text noise;
	public Text gas;
	private MqttClient client;
	// Use this for initialization
	string[] words;
	void Start() {
		// create client instance 
		client = new MqttClient("srv1.clusterfly.ru", 9124, false, null);

		// register to message received 
		client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

		string clientId = Guid.NewGuid().ToString();
		string username = "user_33e0a052";
		string password = "pass_88cf2f67";

		client.Connect(clientId, username, password);

		// subscribe to the topic "/home/temperature" with QoS 2 
		client.Subscribe(new string[] { "user_33e0a052/test" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });


	}
	void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
	{
		soso = "Received: " + System.Text.Encoding.UTF8.GetString(e.Message);
	   Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(e.Message));
		words = soso.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);



	}




	void OnGUI(){

		
		
		

		temp.text = words[3].ToString();
		hum.text = words[4].ToString();
		light.text = words[5].ToString();
		mov.text = words[6].ToString();
		noise.text = words[7].ToString();
		gas.text = words[8].ToString();
	}
	
	// Update is called once per frame
	void Update () {



	}
}
