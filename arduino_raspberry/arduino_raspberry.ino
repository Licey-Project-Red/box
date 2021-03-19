#include<math.h>
#include <DHT.h>
#include <DHT_U.h>
#include "DHT.h"
#define DHTPIN 2  
#define DHTTYPE DHT11 
DHT dht(DHTPIN, DHTTYPE);
// подключение dht11

#include <TroykaLight.h>
TroykaLight sensorLight(A4);
// подключение сенсора света 

#include <NewPing.h>
#define TRIGGER_PIN  8
#define ECHO_PIN     7
#define MAX_DISTANCE 400
NewPing sonar(TRIGGER_PIN, ECHO_PIN, MAX_DISTANCE);
// подключение   уз-дальномера

#include <TroykaMQ.h>
#define PIN_MQ135  A5
MQ135 mq135(PIN_MQ135);
const int RO = 28.82;
// подключение mq-135

const int dgt = 3; 
const int anlg = A3;
// подключение датчика шума
void setup() 
{
  delay(30000);
  pinMode(anlg, INPUT);
  Serial.begin(9600);
  dht.begin();
  mq135.calibrate(RO);
}
int movedetect()
{
  int ping1 = sonar.ping_cm();
  delay(200);
  int ping2 = sonar.ping_cm();
  if(ping1!=ping2 && ping1 != 375 && ping2 != 375)  return 1;
  return 0;
}
void loop() {
  int hum = dht.readHumidity();
  int temp = dht.readTemperature();
  int light = sensorLight.getLightLux()/5;
  if(light>100) light = 100;
  int CO2 = mq135.readCO2();
  int noise = abs((analogRead(anlg)-500));
  noise = abs(noise);
  if(noise > 100) noise = 100;
  int moved = movedetect();
  sensorLight.read();
  Serial.print(temp);
  Serial.print(" ");
  Serial.print(hum);
  Serial.print(" ");
  Serial.print(light);
  Serial.print(" ");
  Serial.print(moved);
  Serial.print(" ");
  Serial.print(noise);
  Serial.print(" ");
  Serial.println(CO2);
  delay(0);
} 
