#include <Arduino.h>
#include <ArduinoJson.h>

void setup()
{
	Serial.begin(115200);
	randomSeed(analogRead(A0));
}

void loop()
{
	StaticJsonDocument<200> doc;
	doc["time"].set<long>(millis());
	doc["rpm"].set<int>(analogRead(A0));

	serializeJson(doc, Serial);
	Serial.println();

	delay(100);
}