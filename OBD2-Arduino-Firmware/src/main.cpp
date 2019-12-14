#include <Arduino.h>
#include <ArduinoJson.h>

unsigned int readInterval = 100; // Every 10 milliseconds

// int
// 	r = 3,
// 	g = 4,
// 	b = 5;

void setup()
{
	Serial.begin(115200);
	randomSeed(analogRead(A0));

	// pinMode(r, OUTPUT);
	// pinMode(g, OUTPUT);
	// pinMode(b, OUTPUT);
}

long lastReadTime = 0;
void loop()
{
	readInterval = map(analogRead(A2), 0, 1023, 10, 500);

	if (millis() - lastReadTime > readInterval)
	{
		StaticJsonDocument<200> doc;
		doc["time_millis"].set<long>(millis());
		doc["temp"].set<int>(analogRead(A0));
		doc["light"].set<int>(analogRead(A1));
		doc["aux"].set<int>(analogRead(A2)); 

		serializeJson(doc, Serial);
		Serial.println();
		lastReadTime = millis();
	}


	// if(Serial.available() > 0) 
	// {
	// 	String data = Serial.readStringUntil('\n');

	// 	StaticJsonDocument<200> doc;

	// 	deserializeJson(doc, data);

	// 	String mode = doc["mode"];
	// 	int d1 = doc["d1"];
	// 	int d2 = doc["d2"];
	// 	int d3 = doc["d3"];

	// 	analogWrite(r, 255 - d1);
	// 	analogWrite(g, 255 - d2); 
	// 	analogWrite(b, 255 - d3);
	// }
}