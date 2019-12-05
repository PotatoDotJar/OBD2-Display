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
int Engine_Load;
int Coolent_Temp;
int Oil_Temp;
int Fuel_Level;
int Fuel_Pressure;
int Air_Flow;
int Speed_KPH;
int16_t acc[3] = {0};
int16_t gyro[3] = {0};
int16_t mag[3] = {0};
float yaw, pitch, roll;

void loop() {

  if (!obd.memsRead(acc, gyro, mag)) return;

  if (obd.readPID(PID_RPM, Engine_RPM) 
    && obd.readPID(PID_SPEED, Speed_KPH)
    && obd.readPID(PID_THROTTLE, Throttle_Pos)
    && obd.readPID(PID_ENGINE_LOAD, Engine_Load)
    && obd.readPID(PID_COOLANT_TEMP, Coolent_Temp)
    && obd.readPID(PID_FUEL_LEVEL, Fuel_Level)

    ) {

    Serial.print("RPM:");
    Serial.print(Engine_RPM);

    Serial.print("\tSpeed(MPH):");
    Serial.print(Speed_KPH / 1.609);

    Serial.print("\tCoolnt Tmp(°C):");
    Serial.print(Coolent_Temp);

    Serial.print("\tThrot_Pos(%):");
    Serial.print(Throttle_Pos);

    Serial.print("\tLoad(%):");
    Serial.print(Engine_Load);

    Serial.print("\tFuel(%):");
    Serial.print(Fuel_Level);

    if (obd.memsOrientation(yaw, pitch, roll)) {
      Serial.print("\tOrientation: ");
      Serial.print(yaw, 2);
      Serial.print('/');
      Serial.print(pitch, 2);
      Serial.print('/');
      Serial.println(roll, 2);
    }
    }

  delay(50);
}