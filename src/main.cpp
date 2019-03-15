#include <Arduino.h>
#include <OBD2UART.h>

#define OBD_RX 3
#define OBD_TX 2
#define LED_PIN 13


SoftwareSerial obdSerialPort(OBD_RX, OBD_TX);
COBD obd;

char Vin[64];

void setup() {
  Serial.begin(115200);
  obd.begin();

  // Init Pins
  pinMode(LED_PIN, OUTPUT);
  digitalWrite(LED_PIN, LOW);
  // Init OBD2
  while (!obd.init())
  {
    Serial.println("Failed to init OBD2, trying again...");
    digitalWrite(LED_PIN, HIGH);
    delay(1000);
    digitalWrite(LED_PIN, LOW);
  }
  Serial.println("OBD2 initialized! Ready!");
  digitalWrite(LED_PIN, HIGH);
  
  Serial.println("Requesting Car VIN Number...");
  while(!obd.getVIN(Vin, sizeof(Vin))) {}
  Serial.print("Car Vin Number: ");
  Serial.print(Vin);
  Serial.println();

}


// Parameters
int Engine_RPM;
int Throttle_Pos;

void loop() {

  // RPM Output
  if(obd.readPID(PID_RPM, Engine_RPM))
  {
    Serial.print("RPM: ");
    Serial.println(Engine_RPM);
  }

  // Throttle Position
  if(obd.readPID(PID_THROTTLE, Throttle_Pos))
  {
    Serial.print("Throttle Pos: ");
    Serial.println(Throttle_Pos);
  }

}