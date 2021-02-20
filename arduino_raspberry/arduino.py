import serial
import datetime
import time
from paho.mqtt import publish
ser = serial.Serial('/dev/ttyACM0',9600)
s = [0]
now1 = datetime.datetime.now()
now2 = -1
f = open("/home/pi/MQTT/"+str(now1.strftime("%d-%m-%Y")),'a')
while True:
    try:
        read_serial = ser.readline()
        read_serial = read_serial.decode('UTF-8')
        words = read_serial.split()
        co2 = int(words[5])//10
        co2 = str(co2)
        read_serial = read_serial.replace(words[5], co2)
        s[0] = str(ser.readline())
        now = datetime.datetime.now()
        print (now.strftime("%d-%m-%Y %H:%M:%S")+' '+read_serial)
        if(int((now1.second) - int(now.second))%10 == 0 and now2 != now.second):
            f.write(now.strftime("%d-%m-%Y %H:%M:%S")+' '+str(read_serial)+'\n')
            publish.single("user_33e0a052/1", str(now.strftime("%d-%m-%Y %H:%M:%S")+' '+str(read_serial)+'\n'), hostname="srv1.clusterfly.ru", port=9124, auth={'username':'user_33e0a052','password':'pass_88cf2f67'}) 
            f.close()
            f = open("/home/pi/MQTT/"+str(now.strftime("%d-%m-%Y")),'a')
            now2 = int(now.second)
        else:
            now2 = -1
    except:
        continue