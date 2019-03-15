#include <Arduino.h>
#include <OBD2UART.h>

COBD obd;

char Vin[64];

void setup() {
  Serial.begin(115200);
  obd.begin();

  // Init Pins
  pinMode(LED_BUILTIN, OUTPUT);
  digitalWrite(LED_BUILTIN, LOW);
  // Init OBD2
  while (!obd.init())
  {
    Serial.println("Failed to init OBD2, trying again...");
    digitalWrite(LED_BUILTIN, HIGH);
    delay(1000);
    digitalWrite(LED_BUILTIN, LOW);
  }
  Serial.println("OBD2 initialized! Ready!");
  digitalWrite(LED_BUILTIN, HIGH);

  // initialize MEMS with sensor fusion enabled
  bool hasMEMS = obd.memsInit(true);
  Serial.print("Motion sensor is ");
  Serial.println(hasMEMS ? "present" : "not present");
  if (!hasMEMS) {
    for (;;) delay(1000);
  }
  

}


// Parameters
int Engine_RPM;
int Throttle_Pos;
int16_t acc[3] = {0};
int16_t gyro[3] = {0};
int16_t mag[3] = {0};
float yaw, pitch, roll;

void loop() {

  // RPM Output
  if(obd.readPID(PID_RPM, Engine_RPM))
  {
    Serial.print("RPM:");
    Serial.println(Engine_RPM);
  }

  // Throttle Position
  if(obd.readPID(PID_THROTTLE, Throttle_Pos))
  {
    Serial.print(" TP:");
    Serial.println(Throttle_Pos);
  }

  if (!obd.memsRead(acc, gyro, mag)) return;

  if (obd.memsOrientation(yaw, pitch, roll)) {
    Serial.print(" Orientation: ");
    Serial.print(yaw, 2);
    Serial.print('/');
    Serial.print(pitch, 2);
    Serial.print('/');
    Serial.println(roll, 2);
  }

  delay(50);
}