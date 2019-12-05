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
	doc["r1"].set<long>(random());
	doc["r2"].set<long>(random());
	doc["r3"].set<long>(random());
	doc["r4"].set<long>(random());

	serializeJson(doc, Serial);
	Serial.println();
}