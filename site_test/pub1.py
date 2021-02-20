from paho.mqtt import publish
from time import sleep
from datetime import datetime
from db1 import DB

db = DB()

def send_data():
    data = db.last_data()
    data = data[1:]
    data = data[:1]+data[2:]
    sleep(1)
    publish.single("user_33e0a052/test", " ".join(data), hostname="srv1.clusterfly.ru", port=9124, auth={'username':'user_33e0a052','password':'pass_88cf2f67'})

while True:
    try:
        send_data()
    except KeyboardInterrupt:
        break
    except Exception as e:
        print(repr(e))